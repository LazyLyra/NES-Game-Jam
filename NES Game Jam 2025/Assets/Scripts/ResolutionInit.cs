using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionInit : MonoBehaviour
{
    // run this script in first scene 
    void Start()
    {
        Screen.SetResolution(512, 448, true);
    }
}
