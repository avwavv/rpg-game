using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
   [SerializeField] public Transform target;
   [SerializeField] private Collider weapon;
   [SerializeField] private float attackInterval = 0.5f;
   private SoundManager soundManager;

   private float lastAttackTime;
   
   private NavMeshAgent meshAgent;
   private Animator animator;
   private bool enemyAlive = true;

   private void Start()
   {
      soundManager = FindObjectOfType<SoundManager>();
      weapon.enabled = false;
      animator = GetComponent<Animator>();
      meshAgent = GetComponent<NavMeshAgent>();
   }

   public void StartAttack()
   {
      soundManager.PlaySFX(soundManager.enemyAttack);
      weapon.enabled = true;
   }

   public void EndAttack()
   {
      weapon.enabled = false;
   }

   public void OnDeath()
   {
      soundManager.PlaySFX(soundManager.enemyDeath);
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
