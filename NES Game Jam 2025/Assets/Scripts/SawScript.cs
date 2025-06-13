using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    [SerializeField] bool AtLeft;
    [SerializeField] float timer;
    [SerializeField] float moveTime;
    [SerializeField] float MoveSpeed;
    [SerializeField] PlayerMovementScript PMS;
    public Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        AtLeft = true;
        timer = 0f;
        PMS = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovementScript>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > moveTime)
        {
            if (AtLeft)
            {
                RB.velocity = Vector2.right * MoveSpeed;
                timer = 0f;
                AtLeft = !AtLeft;
            }
            else
            {
                RB.velocity = Vector2.left * MoveSpeed;
                timer = 0f;
                AtLeft = !AtLeft;
            }
        }
    }

}