using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeChildScript : MonoBehaviour
{
    [SerializeField] bool Left;
    [SerializeField] float Offset;
    // Start is called before the first frame update
    void Start()
    {
        if (Left)
        {
            transform.position = new Vector3(transform.parent.transform.position.x - Offset, transform.parent.transform.position.y, transform.parent.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.parent.transform.position.x + Offset, transform.parent.transform.position.y, transform.parent.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
