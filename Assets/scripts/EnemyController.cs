using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    protected SpriteRenderer sprite;
    protected Rigidbody2D rb2d;
    protected Transform player;
    protected Animator anim;

    public float distanceAttack;

    public float speed;
    protected bool MovingEnemy = false;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("player").GetComponent<Transform>();
    }

    protected float PlayerDistance()
    {
        return Vector2.Distance(player.position, transform.position);
    }

    protected void Flip()
    {
        sprite.flipX = !sprite.flipX;
        speed *= -1;
    }

    protected virtual void Update()
    {
        float distance = PlayerDistance ();
        MovingEnemy = (distance <= distanceAttack);

        if (MovingEnemy)
        {
            if ((player.position.x > transform.position.x && sprite.flipX) ||
                (player.position.x < transform.position.x && !sprite.flipX)) {
                    Flip ();
                }
        }
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }
}
