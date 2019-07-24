using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fight4Ctr : MonoBehaviour
{

    internal bool isBlock = false;
    private float EnemyTimer;
    public float EnemyTime;
    public GameObject Magicsword;
    public GameObject Tramp;

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
        if (!isBlock)
        {
            GameObject.FindGameObjectWithTag("well1").GetComponent<SpriteRenderer>().color = Color.red;
            EnemyTimer += Time.deltaTime;
            if(EnemyTimer > EnemyTime)
            {
                System.Random ran = new System.Random(DateTime.Now.Millisecond);
                if (ran.Next(0, 100) <= 50)
                {
                    Instantiate(Magicsword, new Vector3(27, -3, 0), Quaternion.identity);
                }
                else
                {
                    Instantiate(Tramp, new Vector3(27, -3, 0), Quaternion.identity);
                }

                EnemyTimer = 0;

            }
        }

        if (Player.transform.position.x > 74)
        {
            timer += Time.deltaTime;
            if (timer > 2f && count <= 3)
            {
                Instantiate(Bandit, new Vector3(73, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
                Instantiate(Tramp1, new Vector3(77, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
                Instantiate(Bandit, new Vector3(81, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
                count++;
                timer = 0;
            }
        }
    }
}
