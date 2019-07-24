using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 传送boss2 : MonoBehaviour {

    private GameCtr ctr;
    void Start()
    {
        ctr = GameObject.FindGameObjectWithTag("Player").transform.GetChild(5).GetComponent<GameCtr>();
        ctr.LoadGame();
    }
    public void OnTriggerEnter2D(Collider2D collision)
	{
        if(GameObject.FindGameObjectWithTag("enemy") == null)
        {
            collision.gameObject.GetComponent<hero_move>().stage = 16;
            ctr.SaveGame();
            SceneManager.LoadScene(26);
        }
    }
	void Update()
	{
	}

}

