using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Net;
using UnityEngine.VR.WSA;

public class Boss4Ctr : MonoBehaviour
{
    public float Speed;//人物速度

    #region 游戏物体和组件
    public GameObject Player;
    public GameObject HurtEffect;
    public GameObject Medicine;
    public Transform HurtPos;//特效
    public Animator anim;
    public Slider EnemyHPSlider;
    #endregion

    #region 血量和攻击
    public int Health;
    #endregion

    #region 布尔值和计时器
    internal bool isDie = false;
    private float Timer;
    private float timer;
    private float Boss3AddTimer;
    #endregion

    #region 飞行系统
    private bool FlyFlag = false;
    private float FlyTimer;
    public float FlyTime;
    private float DownTimer;
    public float DownTime;
    #endregion

    public int PercantageOfMedicine;//加血药掉落概率
    public int AddLv;//增加经验值


    // Use this for initialization
    void Start()
    {
        EnemyHPSlider.maxValue = Health;
        EnemyHPSlider.minValue = 0;

        Player = GameObject.FindGameObjectWithTag("Player");

        anim.GetComponent<Animator>();

    }

    public void GetHurt(int PlayerAttack)
    {
        if (!isDie)
        {
            GetComponent<AudioSource>().Play();
            Health -= PlayerAttack;
            GetComponent<SpriteRenderer>().color = Color.red;
            //特效显示
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (Health <= 0)
            {
                isDie = true;
                Die();
            }
        }
    }

    void Down()
    {
    }

    void Fly()
    {
        gameObject.transform.position = new Vector3((float)(28.87), (float) 1.54, 0);
    }

    void Die()
    {
        Player.GetComponent<hero_move>().LvExperience += AddLv;
        if (Player.GetComponent<hero_move>().LvExperience >= Player.GetComponent<hero_move>().MaxLvExperience)
        {
            Player.GetComponent<hero_move>().LvUP();
        }

        if (Player.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else
        {
            transform.localEulerAngles = new Vector2(-1, 0);
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        anim.SetBool("run", false);
        anim.SetBool("attack", false);
        GetComponent<BoxCollider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().simulated = false;
        System.Random ran = new System.Random(DateTime.Now.Millisecond);
        if (ran.Next(0, 100) <= PercantageOfMedicine)
        {
            Instantiate(Medicine, transform.position + transform.up, Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
            Destroy(gameObject, 1f);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameCtr._instance.isPause)
        {
            if (!isDie && !Player.GetComponent<hero_move>().isDie && !GameObject.FindGameObjectWithTag("boss4").GetComponent<Boss4Ctr>().isDie)
            {
                Boss3AddTimer += Time.deltaTime;
                if (Boss3AddTimer > 1.5f)
                {
                    GameObject.FindGameObjectWithTag("boss3").GetComponent<Boss3Ctr>().Health += 15;
                    Debug.Log(Health);
                    Health += 5;
                    Debug.Log(Health);
                    Boss3AddTimer = 0;
                }
            }
            else
            {
                anim.SetBool("attack", false);
            }

            if (GameObject.FindGameObjectWithTag("boss3").GetComponent<Boss3Ctr>().Health <
                (float) (GameObject.FindGameObjectWithTag("boss3").GetComponent<Boss3Ctr>().EnemyHPSlider.maxValue * 0.15))
            {
                GameObject.FindGameObjectWithTag("boss3").GetComponent<Boss3Ctr>().Health = (int)GameObject
                    .FindGameObjectWithTag("boss3").GetComponent<Boss3Ctr>().EnemyHPSlider.maxValue;
            }


            if (!isDie && !Player.GetComponent<hero_move>().isDie)
            {
                Health = Mathf.Clamp(Health, 0, (int)EnemyHPSlider.maxValue);

                if (!FlyFlag)
                {
                    Fly();
                    FlyTimer += Time.deltaTime;
                    if (FlyTimer >= FlyTime)
                    {
                        FlyFlag = true;
                        Down();
                        FlyTimer = 0;
                    }
                }

                if (FlyFlag)
                {
                    DownTimer += Time.deltaTime;
                    if (DownTimer >= DownTime)
                    {
                        FlyFlag = false;
                        DownTimer = 0;
                    }
                }
            }

            if (GetComponent<SpriteRenderer>().color == Color.red)
            {
                timer += Time.deltaTime;
                if (timer > 0.1f)
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                    transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    timer = 0;
                }
            }
            EnemyHPSlider.value = Health;
        }
    }
}
