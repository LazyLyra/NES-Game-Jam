using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFixScript : MonoBehaviour
{
    public BoxCollider2D BC;
    public PlayerInteraction PI;
    // Start is called before the first frame update
    void Start()
    {
        PI = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteraction>();
        BC = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PI.pickingUp = true;
        }
    }
    
    
}