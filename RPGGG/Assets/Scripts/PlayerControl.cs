
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Collider[] weapons;
    [SerializeField] private SoundManager soundManager;
    
    private CharacterController charController;
    private Vector3 targetPosition;
    private Animator animator;
    
    void Start()
    {
        charController = GetComponent<CharacterController>();
        targetPosition = transform.position;
        animator = GetComponent<Animator>();
        ToggleWeapons(false);
    }

    public void BeginAttack()
    {
        soundManager.PlaySFX(soundManager.playerAttack);
        ToggleWeapons(true);
    }

    public void EndAttack()
    {
        ToggleWeapons(false);
    }

    private void ToggleWeapons(bool enable)
    {
        foreach (Collider weapon in weapons)
        {
            weapon.enabled = enable;
        }
    }
    
    void Update()
    {
        float distanceToTarget = Vector3.Distance(targetPosition, transform.position);

        if (distanceToTarget > 0.5f && playerHealth.isAlive)
        {
            animator.SetBool("isRunning", true);
            Vector3 direction = Vector3.Normalize(targetPosition - transform.position);
            charController.Move(direction * (moveSpeed * Time.deltaTime));
            transform.LookAt(targetPosition);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        
        if (Input.GetMouseButtonDown(0) && playerHealth.isAlive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500, groundLayer))
            {
                Debug.Log(hit.collider.name);
                targetPosition = hit.point;
            }
        }

        if (Input.GetMouseButtonDown(1) && playerHealth.isAlive)
        {
            animator.SetTrigger("Stab");
        }
        

        
    }
}
