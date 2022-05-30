using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlade : MonoBehaviour
{
    [SerializeField] public float _spinVelocity = 100f;
    private Rigidbody2D _rgbd;


    void Start()
    {
        _rgbd = GetComponent<Rigidbody2D>();
        _spinVelocity = _spinVelocity * ((Random.Range(0,2) * 2) - 1);
    }

    void Update()
    {
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
