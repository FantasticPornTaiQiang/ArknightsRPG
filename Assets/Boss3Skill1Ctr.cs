using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Skill1Ctr : MonoBehaviour
{
    private float timer;
    private float Timer;
    private bool flag = false;
    private int count;

    // Use this for initialization
    void Start()
    {
        transform.Translate(new Vector3(transform.position.x,-6,0));
    }



    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 2.5f)
        {
            Destroy(gameObject);
        }

        if (System.Math.Abs(transform.position.x - GameObject.FindGameObjectWithTag("Player").transform.position.x) <= 0.9)
        {
            if (count == 0 || flag)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<hero_move>()
                    .GetHurt(GameObject.FindGameObjectWithTag("boss3").GetComponent<Boss3Ctr>().BossSkill1Attack);
                count++;
                flag = false;
            }
            timer += Time.deltaTime;
            if (timer > 0.3f)//如果一直站在范围内，则0.3s算一次判定受伤
            {
                timer = 0;
                flag = true;
            }
        }

    }
}

