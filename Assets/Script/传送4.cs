using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 传送4 : MonoBehaviour
{

    private GameCtr ctr;
    void Start()
    {
        ctr = GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).GetComponent<GameCtr>();
        ctr.LoadGame();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (GameObject.FindGameObjectWithTag("boss1") == null)
            {
                collision.gameObject.GetComponent<hero_move>().num[12] = true;
                collision.gameObject.GetComponent<hero_move>().stage = 26;
                ctr.SaveGame();
                SceneManager.LoadScene(17);
            }

        }
    }
    void Update()
    {
    }

}

