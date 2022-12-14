using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShot : MonoBehaviour
{
   private Rigidbody2D tiro;

   public int veloT;
   
    // Start is called before the first frame update
    void Start()
    {
        tiro = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        tiro.velocity = new Vector2(veloT, 0);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer==6)
        {
            Destroy(this.gameObject);
        }
        if(col.gameObject.layer==3)
        {
            Destroy(this.gameObject);
        }
    }
}
