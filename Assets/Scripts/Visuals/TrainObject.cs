using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TrainObject : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameObject Train;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform endPoint;
    
    [Header("Values")]
    [SerializeField] private float moveDuration;
    [SerializeField] private Vector2 minMaxSpawnDelay;

    private void Start()
    {
        StartCoroutine(nameof(TrainRoutine));
    }

    IEnumerator TrainRoutine()
    {
        InitTrain();

        yield return new WaitForSeconds(Random.Range(minMaxSpawnDelay.x, minMaxSpawnDelay.y));
        
        StartCoroutine(nameof(TrainRoutine));
    }

    private void InitTrain()
    {
        Train.transform.position = spawnPoint.position;
        Train.transform.DOMove(endPoint.position, moveDuration).SetEase(Ease.Linear);
    }
}
