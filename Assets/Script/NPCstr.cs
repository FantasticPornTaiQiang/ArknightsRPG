using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPCstr : MonoBehaviour {
	public GameObject show;
	public GameObject message;
	private bool Canchat=false;
	public string ChatName;
	//Use this for initialization
	void Start () {

	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			show.SetActive (true);
			Canchat = true;
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			show.SetActive (false);
			Canchat = false;
		}
	}
	public void say()
	{
		if(Canchat)
		{
			Flowchart flowchart=GameObject.Find("Flowchart").GetComponent<Flowchart>();
			flowchart.ExecuteBlock(ChatName);
		}
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E))
		{
			say();
			show.SetActive (false);
			message.SetActive (true);
		}
	}
}
