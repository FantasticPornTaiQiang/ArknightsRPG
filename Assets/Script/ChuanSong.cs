using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChuanSong : MonoBehaviour
{
    public bool x = false;
    private GameCtr ctr;


    void Start()
    {
        ctr = GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).GetComponent<GameCtr>();
        if (SceneManager.GetActiveScene().buildIndex == 25)
        {
            ctr.LoadGame();
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("enemy") == null && x)
            {
                for (int i = 0; i < 3; i++)
                {
                    collision.gameObject.GetComponent<hero_move>().num[i] = true;
                }
                for (int i = 13; i < 16; i++)
                {
                    collision.gameObject.GetComponent<hero_move>().num[i] = true;
                }

                collision.gameObject.GetComponent<hero_move>().stage = 4;
                ctr.SaveGame();
                SceneManager.LoadScene(5);
            }
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            x = true;
        }
    }

}
