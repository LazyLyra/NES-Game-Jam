using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverDoorScript : MonoBehaviour
{

    [Header("references")]

    [SerializeField] private LeverScript leverScript; //Drag 
    [SerializeField] GameObject CloseChild;
    [SerializeField] GameObject OpenChild;
    [SerializeField] public Animator animator; //drag from lever
    

    [Header("FixedPos")]
    [SerializeField] Vector3 OpenPos;
    [SerializeField] Vector3 ClosePos;

    [Header("Variables")]
    [SerializeField] Vector3 Dir;
    [SerializeField] float velocity = 0.08f;
    [SerializeField] bool opening = false;
    [SerializeField] public bool IsStatic = true;
    [SerializeField] Vector3 targetPos;
    [SerializeField] AudioSource AS;

    void Start()
    {
        leverScript.OnLeverPull += LeverScript_OnLeverPull;
        OpenPos = OpenChild.transform.position;
        ClosePos = CloseChild.transform.position;
        AS = GetComponent<AudioSource>();
    }

    private void LeverScript_OnLeverPull(object sender, System.EventArgs e)
    {
        AS.Play();
        opening = !opening;
        if (opening)
        {
            animator.SetBool("isOpening", true);
            Dir = OpenPos - transform.position;
            targetPos = OpenPos;
        }
        else
        {
            Dir = ClosePos - transform.position;
            targetPos = ClosePos;
            animator.SetBool("isClosing", true);
        }
        IsStatic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsStatic) {
            Move();
            if (opening && transform.position.y >= targetPos.y -0.1f && transform.position.y <= targetPos.y+0.1)
            {
                transform.position = targetPos;
                IsStatic = true;
                animator.SetBool("isOpening", false);
            }
            else if (!opening && transform.position.y >= targetPos.y - 0.1f && transform.position.y <= targetPos.y + 0.1)
            {
                transform.position = targetPos;
                IsStatic= true;
                animator.SetBool("isClosing", false);
            }

        }
    }


    private void Move()
    {
        transform.position += velocity * Dir * Time.deltaTime;
    }
}
