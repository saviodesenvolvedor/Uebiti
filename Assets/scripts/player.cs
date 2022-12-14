using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // MOVIMENTA��O //
    public Rigidbody2D rb; // Detecta a fisica
    public int moveSpeed; // velocidade para se mover
    private float direcao; // bot�o de movimento
    private Vector3 Odireita; // olhando para direita
    private Vector3 Oesquerda; // olhando para esquerda

    //pulo
    public bool taNoChao; // detecta se est� encostando no ch�o
    public Transform detectaChao; // fisica do detector
    public float jumpForce = 12f;
    private int jumps;
    public LayerMask oQueEhChao; // define o que � o ch�o no cenario
    public int DoubleJump = 1; // valor de soma para dois pulos
    private Animator animacaoP;

    private SpriteRenderer sprite;
    
    // Start is called before the first frame update
    void Start()
    {
       // Odireita = transform.localScale;
        //Oesquerda = transform.localScale;
        Oesquerda.x = Oesquerda.x * -1;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animacaoP = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // pega o pulo
        puloPlayer();
        // pega movimentação
        movePlayer();
    }

        
    public void movePlayer()
    {
        // movimenta��o x,y,z //
        if(Input.GetAxis("Horizontal") != 0)
        {
            //esta correndo(andando)
            animacaoP.SetBool("taCorrendo", true);
        }
        else
        {
            //esta parado
            animacaoP.SetBool("taCorrendo", false);
        }

        direcao = Input.GetAxis("Horizontal");
        
     //   if(direcao > 0)
    //    {
            //olhando para a direita
      //      transform.localScale = Odireita;
      //  }
       // if(direcao < 0)
       // {
           // olhando para a esquerda
       //     transform.localScale = Oesquerda;
      //  }
        // pega o input
        float horizontal = Input.GetAxis("Horizontal");
        // processa o input
        Flip(horizontal);
        
        rb.velocity = new Vector2(direcao * moveSpeed, rb.velocity.y); // movimentar do player
    }

    public void puloPlayer()
    {
        taNoChao = Physics2D.OverlapCircle(detectaChao.position, 0.2f, oQueEhChao); // cria um circulo em volta do objeto que detecta o chao

     //   if(Input.GetButtonDown("Jump") && taNoChao == true) // um pulo
      //      {
       //       rb.velocity = Vector2.up * 12;
            //ativar anima��o do pulo
      //      animacaoP.SetBool("taPulando", true);
      //  }
      //  if (Input.GetButtonDown("Jump") && taNoChao == false && DoubleJump > 0) // doubl epulo
      //  {
         //   rb.velocity = Vector2.up * 12;
         //   DoubleJump--;
            //ativar anima��o do pulo duplo
         //   animacaoP.SetBool("deuDoisPulo", true);
      //  }
       // if(taNoChao && rb.velocity.y == 0)
       // {
         //   DoubleJump = 1;
             //desligando animacao do pulo
          //  animacaoP.SetBool("taPulando", false);
          //  animacaoP.SetBool("deuDoisPulo", false);
       // }

      if(taNoChao)
       {
           jumps = 1;
            if(Input.GetButtonDown("Jump"))
            {
                Jump();
                Debug.Log("a");
                animacaoP.SetBool("taPulando", true);
            }
       }
       else
       {
            if(Input.GetButtonDown("Jump") && jumps > 0)
            {
                jumps--;
                Jump();
                animacaoP.SetBool("deuDoisPulo", true);
            }
       }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "spike") // game over espinhos
        {
            Debug.Log("tocou o espinho!");
            moveSpeed = 0;
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "caixaEX") // game over espinhos
        {
            Debug.Log("tocou o espinho!");
            moveSpeed = 0;
            Destroy(gameObject);
        }

        if(collision.transform.tag == "Plataforma")
        {
            transform.parent = collision.transform;
       //     taNoChao = true;
       //     animacaoP.SetBool("taPulando", false);
       //     animacaoP.SetBool("deuDoisPulo", false);
        }

        if(collision.gameObject.layer == 3 || collision.gameObject.tag == "Plataforma")
        {
            taNoChao = true;
            animacaoP.SetBool("taPulando", false);
            animacaoP.SetBool("deuDoisPulo", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
           // if(collision.transform.tag == "Plataforma")
          //  {
           //      transform.parent = null;
          //  }     

            if(collision.gameObject.layer == 3 || collision.gameObject.tag == "Plataforma")
            {
                 taNoChao = false;
            } 
    }

    public void Flip(float horizontal)
    {
        if(horizontal > 0)
        {
            sprite.flipX = false;
        }
        else
        {
        if(horizontal < 0)
        {
            sprite.flipX = true;
        }
        }
    }

}
