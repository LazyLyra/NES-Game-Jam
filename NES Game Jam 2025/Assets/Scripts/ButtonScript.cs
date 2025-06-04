using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [Header("References")]
    public GameObject DoorAssigned;
    public BoxCollider2D BC;

    [Header("States")]
    [SerializeField] bool Pressed;
    // Start is called before the first frame update
    void Start()
    {
        BC = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
