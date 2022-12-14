using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botao : MonoBehaviour
{
    private Animator anim;

    public static bool pisou;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Caixa")
        {
            Debug.Log("aqui");
            anim.SetBool("Botao", true);
            pisou = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Caixa")
        {
            anim.SetBool("Botao", false);
            pisou = false;
        }
    }
}
