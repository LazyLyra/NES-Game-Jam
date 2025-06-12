using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorScript : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] Vector3 OpenPos;
    [SerializeField] Vector3 ClosePos;

    public bool Opening;

    [Header("Movement")]
    [SerializeField] float MoveSpeed;

    [Header("References")]
    public Rigidbody2D RB;
    public AudioSource AS;
    public GameObject OpenChild; //rmb to drag these
    public GameObject CloseChild;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        RB = GetComponent<Rigidbody2D>();
        OpenPos = OpenChild.transform.position;
        ClosePos = CloseChild.transform.position;
        Opening = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Opening)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    public void Open()
    {
        Vector3 dir = OpenPos - transform.position;
        transform.position += dir * MoveSpeed * Time.deltaTime;
        
    }

    public void Close()
    {

        Vector3 dir = ClosePos - transform.position;
        transform.position += dir * MoveSpeed * Time.deltaTime;
        AS.Play();
    }
}
