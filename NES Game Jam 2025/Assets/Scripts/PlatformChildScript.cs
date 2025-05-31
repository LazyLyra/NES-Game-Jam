using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChildScript : MonoBehaviour
{
    [SerializeField] bool Top;
    [SerializeField] float offset;
    // Start is called before the first frame update
    void Start()
    {
        if (Top)
        {
            transform.position = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y + offset, transform.parent.transform.position.z);
        }

        else
        {
            transform.position = new Vector3(transform.parent.transform.position.x, transform.parent.transform.position.y - offset, transform.parent.transform.position.z);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
