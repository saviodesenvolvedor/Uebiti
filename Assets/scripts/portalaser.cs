using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalaser : MonoBehaviour
{
    public Transform[] pos;
    public float velocidade;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(botao.pisou == true || transform.position.y <= pos[1].position.y)
        {
            transform.Translate(Vector2.up * Time.deltaTime * velocidade);
        }
        
        if (botao.pisou == false || transform.position.y >= pos[0].position.y)
        {
            transform.Translate(Vector2.down * Time.deltaTime * velocidade);
        }
    }
}
