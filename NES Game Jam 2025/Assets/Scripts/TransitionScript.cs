using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] int SceneIndex;
    [SerializeField] PlayerInteraction PIS;
    public event EventHandler OnTransition;

    private void Start()
    {
        PIS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneIndex == 2 && collision.CompareTag("Player")) {
            SceneIndex++;
            SceneManager.LoadScene(SceneIndex);
        }
        if (collision.CompareTag("Player") && PIS.pickingUp)
        {
            SceneIndex++;
            SceneManager.LoadScene(SceneIndex);
        }
        else if (collision.CompareTag("Player") && !PIS.pickingUp)
        {
            OnTransition?.Invoke(this, EventArgs.Empty);
        }
        
    }
}
