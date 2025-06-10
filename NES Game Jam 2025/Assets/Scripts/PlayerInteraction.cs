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
   

    [SerializeField] public bool pickingUp;
    [SerializeField] InteractWithPrincess interactWithPrincess;

    public Animator anim;
    //picking princess up

    private void Start()
    {
        interactWithPrincess = GameObject.FindGameObjectWithTag("Princess").GetComponent<InteractWithPrincess>();
        anim = GetComponent<Animator>();
        playerController = new PlayerController();
        var all = GameObject.FindGameObjectsWithTag("Princess");
        playerController.Player.Enable();
        playerController.Player.PickUp.performed += PickUp_performed;
        playerController.Player.Throw.performed += Throw_performed;
    }

    private void Throw_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Throw();
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

    private void Update()
    {
        pickingUp = interactWithPrincess.beingPickedUp;

        if (pickingUp)
        {
            anim.SetBool("Carrying", true);
        }
        else
        {
            anim.SetBool("Carrying", false);
        }
    }
}
