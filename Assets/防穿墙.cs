using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 防穿墙 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.x < -10)
        {
            GameObject.FindGameObjectWithTag("Player").transform.Translate(Vector2.up * 200 * 1 * Time.deltaTime, Space.World);
            GameObject.FindGameObjectWithTag("Player").transform.Translate(Vector2.right * 200 * 1 * Time.deltaTime, Space.World);
        }
	}
}
