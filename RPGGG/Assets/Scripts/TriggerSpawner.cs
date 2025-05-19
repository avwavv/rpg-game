using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawner : Spawner
{
    private void Start()
    {
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartSpawn();
        }
    }
}
