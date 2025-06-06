using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBoxScript : MonoBehaviour
{

    public BoxCollider2D BC;
    public PolygonCollider2D PC;
    public PlayerLifeScript PLS;
    // Start is called before the first frame update
    void Start()
    {
        BC = GetComponent<BoxCollider2D>();
        PC = GetComponent<PolygonCollider2D>();
        PLS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLifeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PLS.Die();
        }
    }
}
