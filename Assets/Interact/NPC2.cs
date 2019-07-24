using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class NPC2 : MonoBehaviour {
	public GameObject show;
	public GameObject character1;
	public GameObject character2;
	public string ChatName;
	//Use this for initialization
	void Start () {

	}
	public void say()
	{
			Flowchart flowchart=GameObject.Find("Flowchart").GetComponent<Flowchart>();
			flowchart.ExecuteBlock(ChatName);
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.E))
		{
			say();
			show.SetActive (false);
			character1.SetActive (true);
			character2.SetActive (true);
		}
	}
}
