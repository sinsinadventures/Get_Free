using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float _timeToStay = 1f;

    private void Start() 
    {
        Destroy(this.gameObject, _timeToStay);    
    }
}
