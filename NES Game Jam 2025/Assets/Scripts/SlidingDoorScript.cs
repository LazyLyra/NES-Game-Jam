using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorScript : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] Vector3 OpenPos;
    [SerializeField] Vector3 ClosePos;

    [SerializeField] bool IsOpen;

    [Header("Movement")]
    [SerializeField] float MoveSpeed;

    [Header("References")]
    public Rigidbody2D RB;
    public GameObject OpenChild; //rmb to drag these
    public GameObject CloseChild;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        OpenPos = OpenChild.transform.position;
        ClosePos = CloseChild.transform.position;
        IsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
        if (!IsOpen)
        {
            Vector3.MoveTowards(transform.position, OpenPos, MoveSpeed);
        }
    }

    public void Close()
    {
        if (IsOpen)
        {
            Vector3.MoveTowards(transform.position, ClosePos, MoveSpeed);
        }
    }
}
