using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipalManager : MonoBehaviour
{
    
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    [SerializeField] private GameObject painelInfo;
    [SerializeField] private GameObject painelArch;

   
   public Text Tapple;


    public void jogar()
    {
        SceneManager.LoadScene("game");
    }

    public void abriOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void fecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelInfo.SetActive(false);
        painelArch.SetActive(false);
        painelMenuInicial.SetActive(true);

    }

    public void SarJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }

    public void Info()
    {
        painelMenuInicial.SetActive(false);
        painelInfo.SetActive(true);
    }

    public void Arch()
    {
        painelMenuInicial.SetActive(false);
        painelArch.SetActive(true);  
    }

     //public void Uprecord()
   // {
   //     GameController.save = true;
   // }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
