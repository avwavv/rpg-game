using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private float hitInterval = 0.5f;

    private float currentHealth;
    private float lastHitTime = 0f;


    private void Awake()
    {
        currentHealth = startHealth;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EnemyWeapon") && Time.time - lastHitTime > hitInterval) 
        {
           TakeDamage(5);
        }
    }

    private void TakeDamage(float damage)
    {
        lastHitTime = Time.time; 
        currentHealth -= damage;
        Debug.Log("Health: " + currentHealth);
    }
}
