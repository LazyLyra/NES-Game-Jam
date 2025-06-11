using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor.VersionControl;

public class UIManager : MonoBehaviour
{
    public Text WarningMsg;
    [SerializeField] float duration = 1f;

    public void ShowMessage(string message)
    {
        StartCoroutine(DisplayMessage(message, duration));
    }

    private IEnumerator DisplayMessage(string message, float duration)
    {
        WarningMsg.text = message;
        WarningMsg.enabled = true;
        yield return new WaitForSeconds(duration);
        WarningMsg.enabled = false;
    }
}