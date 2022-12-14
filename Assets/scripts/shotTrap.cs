using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotTrap : MonoBehaviour
{
    public GameObject tiro;

    public int velocidadeTiro;
    private float tempoTiro;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
