using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levleManager : MonoBehaviour
{
    public void calllevels()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("faseAtual") + 1);
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
