using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected float _spawnDelay = 0.5f;
    [SerializeField] protected int[] canSpawnWaveNumbers = { 2, 5, 7, 8};
    // [SerializeField] Timer _timer;
    protected bool _canStart = true;
    // public bool _finished = false;

    protected Vector3 _randomPos;
    protected Waves _waves;
    protected bool canSpawn = false;

    protected void Start() 
    {
        _waves = FindObjectOfType<Waves>();
    }

    void Update()
    {
        // if(_canStart == false) { return; }
        ManageSpawnPossibillity();
        if (canSpawn) InstantiatingTargets();
    }

    protected virtual void InstantiatingTargets()
    {
        _randomPos = new Vector3(Random.Range(-7.3f, 7.3f), 3.6f, 0f);
        if (_canStart) { StartCoroutine(InstantiationRoutin()); }
    }

    protected IEnumerator InstantiationRoutin()
    {
        Instantiate(_prefab, _randomPos, Quaternion.identity);
        _canStart = false;
        yield return new WaitForSeconds(_spawnDelay);
        _canStart = true;
    }

    protected void ManageSpawnPossibillity()
    {
        for (int i = 0; i < canSpawnWaveNumbers.Length; i++)
        {
            if (_waves.waveNumber == canSpawnWaveNumbers[i])
            {
                canSpawn = true;
                break;
            }
            else
            {
                canSpawn = false;
            }
        }
        // canSpawn = canSpawnWaveNumbers.Contains(_waves.waveNumber);
    }
}
