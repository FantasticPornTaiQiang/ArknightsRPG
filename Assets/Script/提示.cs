using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 提示 : MonoBehaviour {
	public GameObject message;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("enemy") == null)
			message.SetActive (true);
	}
}
