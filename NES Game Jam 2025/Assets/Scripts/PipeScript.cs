using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    [SerializeField] float MoveSpeed;

    [Header("Positions")]
    [SerializeField] Vector3 OpenPos;
    [SerializeField] Vector3 ClosePos;
    [SerializeField] GameObject OpenChild; // drag
    [SerializeField] GameObject CloseChild;
    [SerializeField] bool Opened;
  
   

    [Header("References")]
    public Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        OpenPos = OpenChild.transform.position;
        ClosePos = CloseChild.transform.position;
        Opened = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckPos();

        if (Opened)
        {
            Close();
        }
        else if (!Opened)
        {
            Open();
        }
    }

    private void Open()
    {
        Vector3 dir = OpenChild.transform.position - transform.position;
        RB.velocity = dir * MoveSpeed;
        
    }

    private void Close()
    {
        Vector3 dir = CloseChild.transform.position - transform.position;
        RB.velocity = dir * MoveSpeed;
       
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
    }

    private void CheckPos()
    {
        if (transform.position == OpenPos)
        {
            Opened = true;
        }
        else if (transform.position == ClosePos)
        {
            Opened = false;
            print("ive closed");
        }
    }
}
