using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.VersionControl;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Text WarningMsg;
    public Text DeathMsg;
    [SerializeField] PlayerLifeScript playerLifeScript;
    [SerializeField] TransitionScript transitionScript;

    private void Start()
    {
        playerLifeScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLifeScript>();
        transitionScript = GameObject.FindGameObjectWithTag("Transitioner").GetComponent<TransitionScript>();
        playerLifeScript.Ondeath += PlayerLifeScript_Ondeath;
        transitionScript.OnTransition += TransitionScript_OnTransition;
        if (SceneManager.GetActiveScene().name == "Room2")
        {

            ShowMessage("THE TEMPLE IS COLLASPING!", 3f, WarningMsg);
        }
    }

    private void TransitionScript_OnTransition(object sender, System.EventArgs e)
    {
        ShowMessage("DON'T FORGET THE PRINCESS!", 1f, WarningMsg);
    }

    private void PlayerLifeScript_Ondeath(object sender, System.EventArgs e)
    {
        ShowMessage("YOU DIED!", 4f, DeathMsg);
    }

    public void ShowMessage(string message, float duration, Text thisMsg)
    {
        StartCoroutine(DisplayMessage(message, duration, thisMsg));
    }

    private IEnumerator DisplayMessage(string message, float duration, Text thisMsg)
    {
        thisMsg.text = message;
        thisMsg.enabled = true;
        yield return new WaitForSeconds(duration);
        thisMsg.enabled = false;
    }
}