using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public event EventHandler OnLeverPull;
    private PlayerController playerController;
    private Animator animator;
    public float leverReachDist = 0.2f;
    public LeverDoorScript leverDoorScript;//drag
    public PlayerMovementScript PMS;
    public PlayerInteraction PIS;

    void Start()
    {
        playerController = new PlayerController();
        playerController.Enable();
        playerController.Player.PullLever.performed += PullLever_performed;
        animator = GetComponent<Animator>();
        PMS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        PIS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();

    }

    private void PullLever_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
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
