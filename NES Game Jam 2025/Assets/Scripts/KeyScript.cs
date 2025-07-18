using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public BoxCollider2D BC;
    public SpriteRenderer SR;
    public AudioSource AS;

    public GameObject KeyDoor; //drag
    public bool collected;
    // Start is called before the first frame update
    void Start()
    {
        BC = GetComponent<BoxCollider2D>();
        SR = GetComponent<SpriteRenderer>();
        AS = GetComponent<AudioSource>();
        SR.enabled = true;
        collected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Princess")
        {
            collected = true;
            SR.enabled = false;
            BC.enabled = false;
            AS.Play();

        }
    }
}
