using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public event EventHandler OnPickUp;
    public event EventHandler OnThrow;
    private PlayerController playerController;

    public Animator anim;
    //picking princess up

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = new PlayerController();
        playerController.Player.Enable();
        playerController.Player.PickUp.performed += PickUp_performed;
        playerController.Player.Throw.performed += Throw_performed;
    }

    private void Throw_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Throw();
        Debug.Log("ran");
    }

    private void PickUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        pickUp();
    }

    private void pickUp()
    {
        OnPickUp?.Invoke(this, EventArgs.Empty);
    }

    private void Throw()
    {
        OnThrow?.Invoke(this, EventArgs.Empty);
    }
        
}
