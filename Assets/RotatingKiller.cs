using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingKiller : MonoBehaviour
{
     [SerializeField] private Vector2 _centre;
     private float RotateSpeed = 5f;
     private float Radius = 1f;
 
     private float _angle;
 
     private void Start()
     {
         _centre = transform.position;
     }
 
     private void Update()
     {
 
         _angle += RotateSpeed * Time.deltaTime;
 
         var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
         transform.position = _centre + offset;
     }
}
