using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pVertical : MonoBehaviour
{
    public bool moveDown = true;

    public float velocidade;
    public Transform pontoA;
    public Transform pontoB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > pontoA.transform.position.y)
        moveDown=true;
        if(transform.position.y < pontoB.transform.position.y)
        moveDown=false;

        if(moveDown)
        transform.position = new Vector2(transform.position.x, transform.position.y - velocidade * Time.deltaTime);
        else
        transform.position = new Vector2(transform.position.x, transform.position.y + velocidade * Time.deltaTime);
    }
}
