using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow : MonoBehaviour {

    public GameObject Player;
    public float speed;
    float OffsetX;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        OffsetX = Player.transform.position.x - transform.position.x + 2;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Player.transform.position.x - OffsetX, transform.position.y, transform.position.z),Time.deltaTime*30*speed);
	}
}
