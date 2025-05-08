using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objToSpawn;
    [SerializeField] protected int spawnCount = 1;
    [SerializeField] protected float spawnInterval = 2f;
    [SerializeField] private Transform playerTarget;

    private void Start()
    {
        StartSpawn();
    }

    public virtual void StartSpawn()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Invoke("SpawnObject", i * spawnInterval );
        }
    }

    private void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(objToSpawn, transform.position, Quaternion.identity);
        Enemy enemy =  spawnedObject.GetComponent<Enemy>();
        enemy.target = playerTarget;

    }
}
