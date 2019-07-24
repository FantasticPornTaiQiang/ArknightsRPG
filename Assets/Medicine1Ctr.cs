using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medicine1Ctr : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Translate(Vector2.up * 400 * 1 * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Destroy(GetComponent<Rigidbody2D>());
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
