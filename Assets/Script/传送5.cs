using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 传送5 : MonoBehaviour {


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

            if ((GameObject.FindGameObjectWithTag("boss3") == null)&& (GameObject.FindGameObjectWithTag("boss3") == null))
            {
                collision.gameObject.GetComponent<hero_move>().stage = 27;
                ctr.SaveGame();
                SceneManager.LoadScene(22);
            }


        }
    }
	void Update()
	{

	}

}