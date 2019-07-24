using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 传送boss1 : MonoBehaviour
{
    private bool x = false;
    private GameCtr ctr;
    void Start()
    {
        ctr = GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).GetComponent<GameCtr>();
        ctr.LoadGame();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (GameObject.FindGameObjectWithTag("enemy") == null && x)
        {
            for (int i = 3; i < 6; i++)
            {
                collision.gameObject.GetComponent<hero_move>().num[i] = true;
            }
            collision.gameObject.GetComponent<hero_move>().stage = 8;
            ctr.SaveGame();
            SceneManager.LoadScene(25);
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

