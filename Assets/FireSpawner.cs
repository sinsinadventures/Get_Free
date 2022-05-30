using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : Spawner
{
    protected override void InstantiatingTargets()
    {
        _randomPos = new Vector3(Random.Range(-6.9f, 6.9f), -1.58f, 0f);
        if (_canStart) { StartCoroutine(InstantiationRoutin()); }
    }
}
