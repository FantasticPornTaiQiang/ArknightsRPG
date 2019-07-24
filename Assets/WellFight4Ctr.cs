using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellFight4Ctr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "rock1")
        {
            GameObject.FindGameObjectWithTag("fight4").GetComponent<Fight4Ctr>().isBlock = true;
            GameObject.FindGameObjectWithTag("well1").GetComponent<SpriteRenderer>().color = Color.white;
            GameObject.FindGameObjectWithTag("well1").GetComponent<PolygonCollider2D>().isTrigger = false;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
