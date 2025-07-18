using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    [Header("Positioning")]
    [SerializeField] float timer;
    [SerializeField] float moveTime;
    [SerializeField] bool IsTop;

    [Header("Ref")]
    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
  

        IsTop = true;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
       

        timer += Time.deltaTime;

        if (timer >= moveTime)
        {
            if (IsTop)
            {
                RB.velocity = Vector2.down * MoveSpeed;
                timer = 0f;
                IsTop = !IsTop;
            }
            else
            {
                RB.velocity = Vector2.up * MoveSpeed;
                timer = 0f;
                IsTop = !IsTop; 
            }
        }
    }

    

}
