using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [Header("References")]
    public GameObject DoorAssigned;
    public SlidingDoorScript SDS;
    public BoxCollider2D BC;
    public Animator anim;

    [Header("States")]
    [SerializeField] bool Pressed;
    // Start is called before the first frame update
    void Start()
    {
        BC = GetComponent<BoxCollider2D>();
        SDS = DoorAssigned.GetComponent<SlidingDoorScript>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            SDS.Opening = true;
            anim.SetBool("Pressed", true);
        }
        else
        {
            SDS.Opening = false;
            anim.SetBool("Pressed", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Princess")
        {
            Pressed = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Pressed = false;
    }
}
