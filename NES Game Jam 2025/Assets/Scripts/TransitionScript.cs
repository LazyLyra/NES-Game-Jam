using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    int SceneIndex = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered");
        if (collision.CompareTag("Player"))
        {
            SceneIndex++;
            SceneManager.LoadSceneAsync(SceneIndex);
        }
    }
}
