using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 传送7 : MonoBehaviour
{

    // Use this for initialization
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

            collision.gameObject.GetComponent<hero_move>().num[6] = true;
            collision.gameObject.GetComponent<hero_move>().stage = 25;
            ctr.SaveGame();
            SceneManager.LoadScene(9);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            x = true;
        }
    }
}
