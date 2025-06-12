using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [Header("MovementStuffs")]
    [SerializeField] int MoveSpeed;
    [SerializeField] int JumpHeight;
    [SerializeField] float JumpTime;
    [SerializeField] float JumpTimer;
    [SerializeField] bool Jumping;
    [SerializeField] float JumpReleaseMultiplier;

    [SerializeField] float CoyoteTime;
    [SerializeField] float CoyoteTimer;
    [SerializeField] float initGravityScale;

    [Header("Grounding")]
    [SerializeField] bool Grounded;
    [SerializeField] Transform FeetPos;
    [SerializeField] float CheckRadius;
    [SerializeField] LayerMask WhatIsGround;


    [Header("Direction Management")]
    [SerializeField] public bool IsFacingRight;


    [Header("References")]
    public Rigidbody2D RB;
    public BoxCollider2D BC;
    public Animator anim;
    public InteractWithPrincess interactWithPrincess;
    public AudioSource AS;

    [Header("SFX")]
    public AudioClip[] soundClips; 

    // Start is called before the first frame update
    void Start()
    {
        interactWithPrincess = GameObject.FindGameObjectWithTag("Princess").GetComponent<InteractWithPrincess>();
        RB = GetComponent<Rigidbody2D>();
        BC = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
        
        RB.gravityScale = initGravityScale;
        IsFacingRight = true;
        Jumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = Physics2D.OverlapCircle(FeetPos.position, CheckRadius, WhatIsGround);

       
        
        Run();

        //jumping stuff only
        

        if (Grounded)
        {
            anim.SetBool("Falling", false);
            CoyoteTimer = CoyoteTime;
            JumpTimer = JumpTime;
            RB.gravityScale = initGravityScale;
        }
        else
        {
            CoyoteTimer -= Time.deltaTime;
        }

        Jump();

        //turning direction stuff only
        if (Input.GetAxisRaw("Horizontal") > 0.01)
        {
            IsFacingRight = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.01)
        {
            IsFacingRight = false;
        }

        Turn();
    }

    private void Run()
    {
        Vector3 HorizDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Vector3 HorizApplied = HorizDirection * MoveSpeed * Time.deltaTime;
        transform.position += HorizApplied;
        

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            anim.SetBool("Running", true);
            AS.clip = soundClips[0];
            AS.loop = true;
         
        }
        else
        {
            anim.SetBool("Running", false);
            AS.loop = false;
        }
    }
    
    private void Jump()
    {
        
        if (CoyoteTimer > 0 && Input.GetKeyDown(KeyCode.Z))
        {
            
            Jumping = true;
            if (interactWithPrincess.beingPickedUp)
            {
                interactWithPrincess.transform.position = Vector2.up * JumpHeight;
            }
            RB.velocity = Vector2.up * JumpHeight;
            AS.PlayOneShot(soundClips[1]);
        }

        if (Jumping && Input.GetKey(KeyCode.Z))
        {
            if (JumpTimer > 0)
            {
                RB.velocity = Vector2.up * JumpHeight;
                JumpTimer -= Time.deltaTime;
            }
            else
            {
                Jumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            Jumping = false;
            CoyoteTimer = 0;
            RB.gravityScale *= JumpReleaseMultiplier;
        }

        if (Jumping)
        {
            anim.SetBool("Jumping", true);
        }
        else if (!Jumping && RB.velocity.y < 0)
        {
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
        }
    }

   
    private void Turn()
    {
        if (IsFacingRight)
        {       
            Vector2 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            if (interactWithPrincess.beingPickedUp)
            {
                interactWithPrincess.transform.rotation = Quaternion.Euler(rotator);
            }
           
        }
        else
        {         
            Vector2 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            if (interactWithPrincess.beingPickedUp)
            {
                interactWithPrincess.transform.rotation = Quaternion.Euler(rotator);
            }

        }
    }
    
}
