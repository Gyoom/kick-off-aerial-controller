using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChunkLoading : MonoBehaviour
{
    [SerializeField] private ObjectChunkLoading objectChunkLoading;
    [SerializeField] private GameObject chunkObj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DisableChunk();
            objectChunkLoading.DisplayChunk();
        }
    }

    public void DisplayChunk()
    {
        chunkObj.SetActive(true);
    }

    private void DisableChunk()
    {
        chunkObj.SetActive(false);
    }
}
