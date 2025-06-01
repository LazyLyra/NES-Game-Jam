using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Profiling;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class InteractWithPrincess: MonoBehaviour
{
    [Header("Variables view")]
    [SerializeField] float interactionDis =2f;
    [SerializeField] bool canInteract = false;
    [SerializeField] bool pickingUp = false;
    [SerializeField] bool throwing = false; 
    [SerializeField] float carryOffSetX = -0.1f;
    [SerializeField] float carryOffSetY = 1.5f;
    [SerializeField] float throwVelocity = 0.4f;
    [SerializeField] float deceleration = 0.3f;
    private Vector3 throwDirection;
    private float velocity;

    [Header("References")]
    [SerializeField] PlayerMovementScript PMS;
    [SerializeField] PlayerInteraction playerInteraction;

    private float currentDistance;
    void Start()
    {
        PMS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        playerInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();
        playerInteraction.OnPickUp += PlayerInteraction_OnPickUp;
        playerInteraction.OnThrow += PlayerInteraction_OnThrow;
    }

    private void PlayerInteraction_OnThrow(object sender, System.EventArgs e)
    {
        if (pickingUp) {
            throwing = true;
            pickingUp = false;
            velocity = throwVelocity;
            float angle = 45f;
            float rad = angle * Mathf.Deg2Rad;
            if (PMS.IsFacingRight) { 
                throwDirection = new Vector3(Mathf.Cos(rad), Mathf.Sin(rad), 0).normalized;
            }
            else
            {
                throwDirection = new Vector3(-Mathf.Cos(rad), Mathf.Sin(rad), 0).normalized;
            }

        }
    }

    private void PlayerInteraction_OnPickUp(object sender, System.EventArgs e)
    {
        pickingUp = !pickingUp;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(transform.position, PMS.transform.position);
        if (currentDistance < interactionDis) {
            Vector2 Direction = PMS.transform.position - transform.position;
            Vector2 CurrentPosition = new Vector2(transform.position.x, transform.position.y);
            RaycastHit2D Hit = Physics2D.Raycast(CurrentPosition, Direction);
            Debug.Log(Hit.collider.name);
            if (Hit.collider.CompareTag("Player"))
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }
        }
        if (canInteract && pickingUp)
        {
            followPlayer();
        }

    }

    private void FixedUpdate()
    {
        if (throwing) {
            transform.position += throwDirection * velocity;
            velocity -= deceleration * Time.deltaTime;
            if (velocity < 0.01 && velocity > -0.01) { 
                velocity= 0f;
                throwing = false;
            }
        }
    }
    private void followPlayer()
    {
        transform.position = PMS.transform.position + new Vector3(carryOffSetX, carryOffSetY, 0);
    }
}
