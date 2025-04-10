using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask groundLayer;
    private CharacterController charController;
    private Vector3 targetPosition;
    
    void Start()
    {
        charController = GetComponent<CharacterController>();
        targetPosition = transform.position;
    }
    
    void Update()
    {
        float distanceToTarget = Vector3.Distance(targetPosition, transform.position);

        if (distanceToTarget > 0.5f)
        {
            Vector3 direction = Vector3.Normalize(targetPosition - transform.position);
            charController.Move(direction * (moveSpeed * Time.deltaTime));
            transform.LookAt(targetPosition);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 500, groundLayer))
            {
                Debug.Log(hit.collider.name);
                targetPosition = hit.point;
            }
        }
        
    }
}
