using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
   [SerializeField] public Transform target;
   [SerializeField] private Collider weapon;
   [SerializeField] private float attackInterval = 0.5f;

   private float lastAttackTime;
   
   private NavMeshAgent meshAgent;
   private Animator animator;
   private bool enemyAlive = true;

   private void Start()
   {
      weapon.enabled = false;
      animator = GetComponent<Animator>();
      meshAgent = GetComponent<NavMeshAgent>();
   }

   public void StartAttack()
   {
      weapon.enabled = true;
   }

   public void EndAttack()
   {
      weapon.enabled = false;
   }

   public void OnDeath()
   {
      enemyAlive = false;
      meshAgent.isStopped = true;
      weapon.enabled = false;
   }

   private void Update()
   {
      if (!enemyAlive)
      {
         return;
      }
      if (Vector3.Distance(transform.position, target.position) > 1.5f)
      {
         meshAgent.isStopped = false;
         meshAgent.SetDestination(target.position);
         animator.SetBool("isRunning", true);
      }
      else
      {
         animator.SetBool("isRunning", false);
         meshAgent.isStopped = true;
         if (Time.time - lastAttackTime > attackInterval)
         {
            lastAttackTime = Time.time;
            animator.SetTrigger("Attack");
         }
      }
   }
}
