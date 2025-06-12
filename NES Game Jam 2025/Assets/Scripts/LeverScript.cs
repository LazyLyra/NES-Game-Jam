using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public event EventHandler OnLeverPull;
    private Animator animator;
    public float leverReachDist = 0.2f;
    public LeverDoorScript leverDoorScript;//drag
    public PlayerMovementScript PMS;
    public PlayerInteraction PIS;

    void Start()
    {
        animator = GetComponent<Animator>();
        PMS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        PIS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();

    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        Vector2 Direction = PMS.transform.position - transform.position;
        RaycastHit2D Hit = Physics2D.Raycast(transform.position, Direction);
        if (Direction.sqrMagnitude < leverReachDist)
        {
            if (Hit.collider.CompareTag("Player") && !PIS.pickingUp && leverDoorScript.IsStatic)
            {
                OnLeverPull?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
