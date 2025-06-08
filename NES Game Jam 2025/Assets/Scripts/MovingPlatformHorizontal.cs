using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformHorizontal : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    [Header("Positioning")]
    [SerializeField] float timer;
    [SerializeField] float moveTime;
    [SerializeField] bool IsRight;

    [Header("Ref")]
    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();


        IsRight = true;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;

        if (timer >= moveTime)
        {
            if (IsRight)
            {
                RB.velocity = Vector2.right * MoveSpeed;
                timer = 0f;
                IsRight = !IsRight;
            }
            else
            {
                RB.velocity = Vector2.left * MoveSpeed;
                timer = 0f;
                IsRight = !IsRight;
            }
        }
    }


}
