using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenBlockController : MonoBehaviour
{
    public TrackableEventHandler Target;
    public Transform GameMachine;
    public GameObject[] Prefabs;
    public float SpawnTime = 1f;
    public Transform SpawnPoint;
    public Collider OpositCollider;
    [HideInInspector]
    public bool IsSpawnAllow = false;

    public void DisableGenProcess()
    {
        IsSpawnAllow = false;
    }

    public void EnableGenProcess()
    {
        IsSpawnAllow = true;
        StartCoroutine(SpawnPrefab());
    }

    private IEnumerator SpawnPrefab()
    {
        while (IsSpawnAllow)
        {
            yield return new WaitForSecondsRealtime(SpawnTime);
            var prefab = Prefabs[UnityEngine.Random.Range(0, Prefabs.Length)];
            if (IsSpawnAllow)
            {
                var instance = Instantiate(prefab, SpawnPoint.position, Quaternion.identity)
                    .GetComponent<CanController>();
                instance.StartMove(SpawnPoint.forward, OpositCollider, Target);
            }
        }
    }
}
