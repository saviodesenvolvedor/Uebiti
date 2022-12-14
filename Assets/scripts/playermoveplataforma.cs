using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermoveplataforma : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D aad)
    {
        if(aad.transform.tag == "Plataforma")
        {
            transform.parent = aad.transform;
        }
    }

   void OnCollisionExit2D(Collision2D aad)
    {
         if(aad.transform.tag == "Plataforma")
        {
            transform.parent = null;
        }
    }
}
