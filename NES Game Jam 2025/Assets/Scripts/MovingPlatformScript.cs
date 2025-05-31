using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    [Header("Positioning")]
    [SerializeField] Vector3 TopPos;
    [SerializeField] Vector3 BottomPos;

    [SerializeField] bool IsTop;

    [Header("Finding Child")] // drag
    public GameObject TopChild;
    public GameObject BottomChild;

    [Header("Ref")]
    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        TopPos = TopChild.transform.position;
        BottomPos = BottomChild.transform.position;
        transform.position = TopPos;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPos();

        if (IsTop)
        {
            RB.velocity = Vector2.down * MoveSpeed;
        }
        else if (!IsTop)
        {
            RB.velocity = Vector2.up * MoveSpeed;
        }
    }

    private void CheckPos()
    {
        if (transform.position == TopPos)
        {
            IsTop = true;
        }

        else if (transform.position == BottomPos)
        {
            IsTop = false;
        }
    }

}
