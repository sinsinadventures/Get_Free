using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicIce : MonoBehaviour
{
    [SerializeField] public float _spinVelocity = 100f;
    private Rigidbody2D _rgbd;

    void Start()
    {
        
        _rgbd = GetComponent<Rigidbody2D>();
        _rgbd.gravityScale = 0;
        _spinVelocity = _spinVelocity * ((Random.Range(0,2) * 2) - 1);
    }

    void Update()
    {
        _rgbd.velocity = new Vector2(Random.Range(1, 3), 0);
        transform.Rotate(Vector3.forward * _spinVelocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Missed")
        {
            Destroy(this.gameObject);
        }
    }
}
