using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeScript : MonoBehaviour
{
    public bool Alive;
    public BoxCollider2D BC;
    // Start is called before the first frame update
    void Start()
    {
        Alive = true;
        BC = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        Alive = false;
        Wait();
        //reload scene
    }

    

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.2f);
    }
}
