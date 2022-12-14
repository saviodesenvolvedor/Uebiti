using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformetest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Plataforma")
        {
            transform.parent = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
         if(collision.transform.tag == "Plataforma")
        {
            transform.parent = null;
        }
    }

}
