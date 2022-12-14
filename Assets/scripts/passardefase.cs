using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class passardefase : MonoBehaviour
{
    public int totalNext;
    public GameObject telaNext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (GameController.instance.totalScore >= totalNext)
            {
                telaNext.SetActive(true);
            }
            
        }
        PlayerPrefs.SetInt("faseAtual", SceneManager.GetActiveScene().buildIndex);
        //GameController.save = true;
    }

     public void NextGame(string lvlname)
    {
        Debug.Log("foi");
        SceneManager.LoadScene(lvlname);
    }
}
