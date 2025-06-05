using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    [Header("Positions")]
    [SerializeField] float timer;
    [SerializeField] float moveTime;
    [SerializeField] bool AtLeft;
  
   

    [Header("References")]
    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        timer = 0f;
        AtLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= moveTime)
        {
            if (AtLeft)
            {
                Wait();
                RB.velocity = Vector2.right * MoveSpeed;
                timer = 0f;
                AtLeft = !AtLeft;
            }
            else
            {
                Wait();
                RB.velocity = Vector2.left * MoveSpeed;
                timer = 0f;
                AtLeft = !AtLeft;
            }
        }

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
    }

    
}
