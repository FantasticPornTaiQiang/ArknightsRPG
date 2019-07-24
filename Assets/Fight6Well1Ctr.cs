using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight6Well1Ctr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.transform.position = new Vector3((float)29.8, (float)4.8, 0);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3((float)29.8,(float)4.8,0);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
