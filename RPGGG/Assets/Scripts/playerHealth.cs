
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField] private int startHealth;
    [SerializeField] private float hitInterval = 0.5f;
    [SerializeField] private int healthGainedPerLevel = 20;
    [SerializeField] private SoundManager soundManager;

    private int currentHealth;
    private int currentMaxHealth;
    private float lastHitTime = 0f;
    private Animator animator;

    public static bool isAlive;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        currentMaxHealth = startHealth;
        currentHealth = startHealth;
        isAlive = true;
    }

    public float GetHealthRatio()
    {
        return (float) currentHealth / (float) currentMaxHealth;
    }

    public void OnLevelGained(int newLevel)
    {
        currentMaxHealth = startHealth + (newLevel - 1) * healthGainedPerLevel;
        currentHealth = currentMaxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyWeapon")&& isAlive && Time.time - lastHitTime > hitInterval) 
        {
           TakeDamage(20);
        }
    }

    private void TakeDamage(int damage)
    {
        lastHitTime = Time.time; 
        currentHealth -= damage;
        if (currentHealth > 0)
        {
            soundManager.PlaySFX(soundManager.playerScream);
            animator.SetTrigger("Hit");
        }
        else
        {
            soundManager.PlaySFX(soundManager.playerDeath);
            GameEvents.CallGameEnd();
            isAlive = false;
            animator.SetTrigger("Death");
        }
    }
}
