using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BladeSpawner : Spawner
{
    protected override void InstantiatingTargets()
    {
        _randomPos = new Vector3(Random.Range(-7.3f, 7.3f), 3.6f, 0f);
        if (_canStart) { StartCoroutine(InstantiationRoutin()); }
    }

}
