
using UnityEngine;
using UnityEngine.Events;

public class enemyHealth : MonoBehaviour
{
    [SerializeField] private float startHealth;
    [SerializeField] private float hitInterval = 0.5f;
    [SerializeField] private int xpToGive = 10;
    public UnityEvent OnDeath;
    private SoundManager soundManager;

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
        soundManager = FindObjectOfType<SoundManager>();
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
            soundManager.PlaySFX(soundManager.enemyScream);
            animator.SetTrigger("Hit");
        }
        else
        {
            soundManager.PlaySFX(soundManager.enemyDeath);
           LevelManager.instance.GiveXP(xpToGive); 
            animator.SetTrigger("Death");
            OnDeath.Invoke();
            enemyAlive = false;
        }
    }
}
