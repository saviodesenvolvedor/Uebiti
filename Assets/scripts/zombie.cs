using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed;

    public Transform rightCol; // Colisão direita
    public Transform leftCol; // Colisão esquerda


    public Transform heightPoint; // Cabeça do Personagem
    
    private bool colliding;

    public LayerMask layer;

    
    public CapsuleCollider2D capsuleCollider2D;

    bool playerDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y); // movimentando inimigo


        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer); // desenha um colisor invisivel em formato de linha

        if(colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;
        }
     }

     void OnCollisionEnter2D(Collision2D col)
     {
        if(col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - heightPoint.position.y;

            if(height > 0 && !playerDestroyed)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("dead");
                capsuleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.57f);
            }
            else
            {
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
        }
     }
}
