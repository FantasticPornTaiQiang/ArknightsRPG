using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 传送3 : MonoBehaviour
{
    private GameCtr ctr;
    void Start()
    {
        ctr = GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).GetComponent<GameCtr>();
        ctr.LoadGame();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameObject.FindGameObjectWithTag("enemy") == null)
        {
            for (int i = 7; i < 11; i++)
            {
                collision.gameObject.GetComponent<hero_move>().num[i] = true;
                collision.gameObject.GetComponent<hero_move>().stage = 11;
            }
            ctr.SaveGame();
            SceneManager.LoadScene(12);
        }
    }
    void Update()
    {
    }

}

