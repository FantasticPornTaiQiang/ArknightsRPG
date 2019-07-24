using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 计时 : MonoBehaviour {
	private float timer;
	public GameObject skip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 3f)
			skip.SetActive (true);
	}
}
