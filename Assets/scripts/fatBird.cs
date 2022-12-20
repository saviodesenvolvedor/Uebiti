using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fatBird : MonoBehaviour
{
    
    public CapsuleCollider2D capsuleCollider2D;
    private Animator anim;
    private Rigidbody2D rig;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            anim.SetTrigger("dead");
            Destroy(gameObject, 0.10f);
        }
        
        if(col.gameObject.layer == 3 || gameObject.layer == 4)
        {
            anim.SetTrigger("dead");
            Destroy(gameObject, 0.10f);
        }
    }
}
