using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour
{
    public float speed;
    public float moveTime;
    private bool dirRight = true;

    private float timer;


    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dirRight)
        {
            // se verdadeiro a serra vai para a direita
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            // se falso a serra vai para a esquerda
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if(timer>= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
