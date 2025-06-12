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
    [SerializeField] float interactionDis =1f;
    [SerializeField] bool canInteract = false;
    [SerializeField] public bool beingPickedUp = false;
    [SerializeField] bool throwing = false; 
    [SerializeField] float carryOffSetX = -0.09f;
    [SerializeField] float carryOffSetY = 0.4f;
    [SerializeField] float throwVelocity = 0.2f;
    [SerializeField] float deceleration = 0.1f;
    private Vector3 throwDirection;
    private float velocity;
    public AudioClip[] soundClips;

    [Header("References")]
    [SerializeField] PlayerMovementScript PMS;
    [SerializeField] PlayerInteraction playerInteraction;
    public AudioSource AS;

    private float currentDistance;
    void Start()
    {
        PMS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        AS = GetComponent<AudioSource>();
        playerInteraction = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();
        playerInteraction.OnPickUp += PlayerInteraction_OnPickUp;
        playerInteraction.OnThrow += PlayerInteraction_OnThrow;
    }

    private void PlayerInteraction_OnThrow(object sender, System.EventArgs e)
    {
        if (beingPickedUp) {
            throwing = true;
            beingPickedUp = false;
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

            AS.PlayOneShot(soundClips[1]);
        }
    }

    private void PlayerInteraction_OnPickUp(object sender, System.EventArgs e)
    {
        if (canInteract)
        {
            beingPickedUp = !beingPickedUp;
            AS.PlayOneShot(soundClips[0]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(transform.position, PMS.transform.position);
        if (currentDistance < interactionDis) {
            Vector2 Direction = PMS.transform.position - transform.position;
            RaycastHit2D Hit = Physics2D.Raycast(transform.position, Direction);
            if (Hit.collider.CompareTag("Player"))
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }
        }
        else
        {
            canInteract = false;
        }
        if (beingPickedUp)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            velocity = 0f;
            StartCoroutine(ReboundCD());
            
        }
    }
    IEnumerator ReboundCD()
    {
        yield return new WaitForSeconds(0.5f);
    }
}
