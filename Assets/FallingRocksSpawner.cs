using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FallingRocksSpawner : MonoBehaviour
{
    [SerializeField] private Vector2Int baseDirXZ;
    [SerializeField] private GameObject[] rocksObjects;
    [SerializeField] private Vector2Int minMaxRockSpawning;
    [SerializeField] private Vector2 minMaxSpawnDelay;
    [SerializeField] private Vector2 minMaxFallingDist;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("airplane"))
        {
            FalLRocks();
        }
    }

    private void FalLRocks()
    {
        StartCoroutine(nameof(FallRocksRoutine));
    }

    IEnumerator FallRocksRoutine()
    {
        var randomSpawnAmount = Random.Range(minMaxRockSpawning.x, minMaxRockSpawning.y + 1);
        for (int i = 0; i < randomSpawnAmount; i++)
        {
            var obj = Instantiate(rocksObjects[Random.Range(0, rocksObjects.Length)], transform.position, Quaternion.identity);
            obj.GetComponent<FallingRock>().fallingDistance = Random.Range(minMaxFallingDist.x, minMaxFallingDist.y);
            obj.GetComponent<FallingRock>().baseDirectionXZ = new Vector3(baseDirXZ.x, 0, baseDirXZ.y);
            
            yield return new WaitForSeconds(Random.Range(minMaxSpawnDelay.x, minMaxSpawnDelay.y));
        }
    }
}
