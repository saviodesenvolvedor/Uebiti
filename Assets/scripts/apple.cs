using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apple : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public GameObject collected;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        GameController.instance.totalScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);
            GameController.instance.totalScore += Score;
            GameController.instance.UpScoretxt();

            Destroy(gameObject, 0.2f);
        }
    }

    public void exibirRecord()
    {
        GameController.instance.record.text = "RECORD: " + Score;
    }
}
