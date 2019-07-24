using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter(Collider other)   //检测函数,并将检测的结果放入other变量中.
    {
        if (other.gameObject.tag == "medicine")    //将检测结果的碰撞对象标签与player标签对比.判断是否相等
        {
            GameObject.FindGameObjectWithTag("medicine").GetComponent<Rigidbody2D>().simulated = false;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
