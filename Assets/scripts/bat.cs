using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bat : EnemyController
{
    public Transform heightPoint;
    bool playerDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update ()
    {
        base.Update ();

        if(MovingEnemy)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Mathf.Abs(speed) * Time.deltaTime);
            anim.SetTrigger("bat_action");
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
                anim.SetTrigger("bat_dead");
                rb2d.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
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
