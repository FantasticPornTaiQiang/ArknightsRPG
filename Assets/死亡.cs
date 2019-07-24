using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 死亡 : MonoBehaviour
{
    public GameObject player;
	// Use this for initialization
    public void Onclick1()
    {
        if (player.GetComponent<hero_move>().isDie)
        {
            SceneManager.LoadScene(29);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
