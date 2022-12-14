using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampoline : MonoBehaviour
{

    Animator anim;

    [SerializeField] float force;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("jumpTrampoline", true);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(0f, force), ForceMode2D.Impulse);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.SetBool("jumpTrampoline", false);
        }
    }
}
