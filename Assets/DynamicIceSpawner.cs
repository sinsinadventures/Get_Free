using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicIceSpawner : Spawner
{
    protected override void InstantiatingTargets()
    {
        _randomPos = new Vector3(-8.04f, Random.Range(-3.56f, 3.56f), 0f);
        if (_canStart) { StartCoroutine(InstantiationRoutin()); }
    }
}
