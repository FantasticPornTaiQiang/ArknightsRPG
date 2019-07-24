using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Fight3Ctr : MonoBehaviour
{
    private int count;
    private GameObject Player;
    public GameObject Bandit;
    private float timer;

    // Use this for initialization
    void Start () {
		Player=GameObject.FindGameObjectWithTag("Player");

	}
	


	// Update is called once per frame
	void Update () {
        if (Player.transform.position.x > 72 )
        {
            timer += Time.deltaTime;
            if (timer > 3f && count <= 3)
            {
                Instantiate(Bandit, new Vector3(73, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
                Instantiate(Bandit, new Vector3(75, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
                Instantiate(Bandit, new Vector3(77, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
                Instantiate(Bandit, new Vector3(79, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
                count++;
                timer = 0;
            }
        }
        
    }
}
