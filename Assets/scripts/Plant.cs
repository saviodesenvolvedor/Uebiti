using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject tiro;

    public int velocidadeTiro;
    private float tempoTiro;


    private Rigidbody2D rig;
    private Animator anim;

    public float speed;
    public Transform heightPoint; // Cabeça do Personagem
    bool playerDestroyed = false;
    public CapsuleCollider2D capsuleCollider2D;

    
    private void FixedUpdate()
    {
        tempoTiro = tempoTiro + Time.deltaTime;
        if(tempoTiro > velocidadeTiro)
        {
            Instantiate(tiro, transform.position, Quaternion.Euler(0, 0, -90));
            tempoTiro = 0;
        }
    }
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
                Destroy(gameObject, 0.4f);
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
