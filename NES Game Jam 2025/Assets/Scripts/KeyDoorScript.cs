using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorScript : MonoBehaviour
{
    [Header("Positions")]
    [SerializeField] Vector3 OpenPos;
    [SerializeField] Vector3 ClosePos;

    public bool Opening;

    [Header("Movement")]
    [SerializeField] float MoveSpeed;
    [SerializeField] float openDistance;

    [Header("References")]
    public Rigidbody2D RB;
    public GameObject OpenChild; //rmb to drag these
    public GameObject CloseChild;
    public PlayerMovementScript PMS;
    public GameObject Key; //drag
    public KeyScript KS;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        PMS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();
        KS = Key.GetComponent<KeyScript>();
        OpenPos = OpenChild.transform.position;
        ClosePos = CloseChild.transform.position;
        Opening = false;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(ClosePos, PMS.transform.position);

        if (distance < openDistance && KS.collected == true)
        {
            Opening = true;
        }
        else if (distance > openDistance)
        {
            Opening = false;
        }
        
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

    }
}
