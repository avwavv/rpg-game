using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
   [SerializeField] private Transform target;
   [SerializeField] private Collider weapon;
   [SerializeField] private float attackTime;
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
   }

   private void Update()
   {
      if (!enemyAlive)
      {
         return;
      }
      if (Vector3.Distance(transform.position, target.position) > 1f)
      {
         meshAgent.isStopped = false;
         animator.SetBool("isRunning", true);
         meshAgent.SetDestination(target.position);
      }
      else
      {
         animator.SetBool("isRunning", false);
         meshAgent.isStopped = true;
      }
   }
}
