using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class Fight6Ctr : MonoBehaviour {

    private int count;
    private GameObject Player;
    public GameObject Tramp1;
    public GameObject Bandit;
    private float timer;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if (Player.transform.position.x > 74)
        {
            timer += Time.deltaTime;
            if (timer > 3f && count <= 3)
            {
                Instantiate(Bandit, new Vector3((float)87, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
                Instantiate(Tramp1, new Vector3((float)88, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
                Instantiate(Bandit, new Vector3((float)89, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
                count++;
                timer = 0;
            }
        }
    }
}
