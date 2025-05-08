using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private float hitInterval = 0.5f;
    public UnityEvent OnDeath;

    private float currentHealth;
    private float lastHitTime = 0f;
    private Animator animator;

    private bool enemyAlive;

    private bool EnemyAlive
    {
        get { return enemyAlive; }
    }

    private void Start()
    {
        enemyAlive = true;
        animator = GetComponent<Animator>();
        currentHealth = startHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerWeapon") && Time.time - lastHitTime > hitInterval && EnemyAlive) 
        {
            TakeDamage(30);
        }
    }

   
    private void TakeDamage(float damage)
    {
        lastHitTime = Time.time; 
        currentHealth -= damage;
        if (currentHealth > 0)
        {
            animator.SetTrigger("Hit");
        }
        else
        {
            animator.SetTrigger("Death");
            OnDeath.Invoke();
            enemyAlive = false;
        }
    }
}
