using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _moveSpeed = 5;
    [SerializeField] private SpriteRenderer _aliveSprite;
    [SerializeField] private SpriteRenderer _deadSprite;
    [SerializeField] private Animator _deadAnimator;
    [SerializeField] private Animator _aliveAnimator;
    public bool isDead = false;  
    public bool isDeadAgain = false;  
    private Rigidbody2D _rgbd;
    // private SpriteRenderer _spriteRenderer;
    private bool _canMove = true; 
    private float _moveDirectionX; 
    private float _moveDirectionY; 
    private Timer _timer;

    [Header("Dashing")]
    [SerializeField] private float _dashingVelocity         = 14f;
    [SerializeField] private float _dashDelay               = 0.5f;
    [SerializeField] private ParticleSystem _dashPS         = null;
    [SerializeField] private LayerMask _dashLayerMasks           = new LayerMask();
    private TrailRenderer _trailRenderer;
    // private Vector2 _dashingDir                             = new Vector2();
    private Vector3 _moveDir                                = new Vector3();
    private float _moveDirX;
    private float _moveDirY;
    private float _trailTime                                = 0f;
    private bool _readyForDashing                           = true;
    private bool _canDash                                   = true;


    // Start is called before the first frame update
    void Start()
    {
        // _spriteRenderer.sprite = _aliveSprite;
        _deadAnimator.enabled = false;
        _deadSprite.enabled = false;
        _timer = FindObjectOfType<Timer>();
        _rgbd = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
        _trailTime = (_trailRenderer.time <= _dashDelay) ? _trailRenderer.time : (_dashDelay);
        _canDash = false;
        _readyForDashing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeadAgain) return;
        AnimationSetup();
        SetMovement();
        Dashing();
    }

    private void FixedUpdate() {
        if (isDeadAgain) return;
        Movement();
        DashMovement();
    }

    private void SetMovement()
    {
        _moveDirectionX = Input.GetAxis("Horizontal");
        _moveDirectionY = Input.GetAxis("Vertical");

        Movement();
    }

    private void Movement()
    {
        if (_canMove)
        {
            if (!isDead) 
            {
                _rgbd.velocity = new Vector2(_moveDirectionX, 0) * _moveSpeed;
            }
            else
            {
                _rgbd.velocity = new Vector2(_moveDirectionX, _moveDirectionY) * _moveSpeed;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Killer")
        {
            if (isDead)
            {
                isDeadAgain = true;
                _timer.timerIsRunning = false;
                _rgbd.isKinematic = true;
                _rgbd.velocity = new Vector2(0, 0);
            }
            else
            {
                StartCoroutine(StartingRoutine());
            }
        }
    }

    private void Dashing()
    {
        if (!isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) && _readyForDashing)
        {
            StartCoroutine(DashingRoutine());
            _canDash = true;
            _readyForDashing = false;
            _trailRenderer.emitting = true;
            if (_dashPS) _dashPS.Play();
            StartCoroutine(TrailRoutine());
        }

        if (_canDash)
        {
            _moveDir = new Vector3(_moveDirectionX, _moveDirectionY);
            if (_moveDir == Vector3.zero) { _moveDir = new Vector3(transform.localScale.x, 0, 0); }
        }
    }

    private void DashMovement()
    {
        if (!isDead) return;
        if (_canDash)
        {
            var _dashPos = transform.position + (_moveDir.normalized * _dashingVelocity);

            RaycastHit2D _raycastHit2D = Physics2D.Raycast(transform.position, _moveDir, _dashingVelocity, _dashLayerMasks);
            if (_raycastHit2D.collider != null) { _dashPos = _raycastHit2D.point; }

            _rgbd.MovePosition(_dashPos);
            _canDash = false;
        }
    }

    IEnumerator DashingRoutine()
    {
        yield return new WaitForSeconds(_dashDelay);
        _readyForDashing = true;
    }

    IEnumerator TrailRoutine()
    {
        yield return new WaitForSeconds(_trailTime);
        _trailRenderer.emitting = false;
    }

    IEnumerator StartingRoutine()
    {
        _rgbd.MovePosition(new Vector2(0, 0));
        isDead = true;
        yield return new WaitForSeconds(2f);
        _timer.timerIsRunning = true;
    }


    private void AnimationSetup()
    {
        if (!isDead)
        {
            _aliveAnimator.SetBool("AliveRun" , (_moveDirectionX != 0) ? true : false);
            FlipSprite(_aliveSprite);
        }
        else
        {
            _aliveAnimator.enabled = false;
            _aliveSprite.enabled = false;
            _deadSprite.enabled = true;
            _deadAnimator.enabled = true;
            FlipSprite(_deadSprite);
        }
    }

    private void FlipSprite(SpriteRenderer spriteRenderer)
    {
        if (_moveDirectionX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (_moveDirectionX < 0)
        {
            spriteRenderer.flipX = true;
        }
        // spriteRenderer.flipX = (_moveDirectionX >= 0) ? false : true;
    }

}
