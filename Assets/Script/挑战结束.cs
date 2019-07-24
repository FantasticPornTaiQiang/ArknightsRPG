using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 挑战结束 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	public void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "Player")
		{
			if (GameObject.FindGameObjectWithTag("enemy") == null&&GameObject.FindGameObjectWithTag("boss1") == null&&GameObject.FindGameObjectWithTag("boss2") == null&&GameObject.FindGameObjectWithTag("boss3") == null)
				SceneManager.LoadScene(0);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
