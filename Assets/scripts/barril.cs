using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barril : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") // game over espinhos
        {
                anim.SetTrigger("destroyB");
                rig.bodyType = RigidbodyType2D.Kinematic;
                GameController.instance.ShowGameOver();
                Destroy(gameObject, 0.33f);
        }
    }
}
