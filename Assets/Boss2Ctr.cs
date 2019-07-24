using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Boss2Ctr : MonoBehaviour
{
    public float Speed;//人物速度

    #region 游戏物体和组件
    public GameObject Player;
    public GameObject HurtEffect;
    public GameObject Medicine;
    public Transform HurtPos;//特效
    public Animator anim;
    public Slider EnemyHPSlider;
    public GameObject Boss2Skill1;
    #endregion

    #region 技能1
    public float BossSkill1Time;
    public float BossSkill1CdTime;
    public int BossSkill1Attack;
    public float BossSkill1Frequency;//指多少秒出现一次
    #endregion

    #region 血量和攻击
    public int Health;
    internal int Attack;
    public int BasicAttack;
    public float attackTime;
    #endregion

    #region 布尔值和计时器
    internal bool isDie = false;
    private bool flag = false;
    private int count;
    private int count2;
    private float Timer;
    private float timer;
    private float attackTimer;
    private bool isSkill1 = false;
    private float BossSkill1Timer;
    private float BossSkill1CdTimer;
    private bool isSflag = true;
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

    public void Skill1()
    {
        float x = new System.Random().Next(-1140, 3197);
        x /= 100;
        Instantiate(Boss2Skill1, new Vector3(x, transform.position.y, 0), Quaternion.identity);

    }
    public void Skill2()
    {
        if (Health <= (int)(EnemyHPSlider.maxValue * 0.3) && count2 == 0)
        {
            BasicAttack = (int)(BasicAttack * 1.1);
            Speed += 2;
            count2++;
            transform.GetChild(2).gameObject.SetActive(true);
        }

    }
    public void Skill3()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= 15 && Vector3.Distance(transform.position, Player.transform.position) > 2.5)
        {

            if (isSflag)
            {
                transform.GetChild(4).gameObject.SetActive(true);
                if (Player.transform.position.x < transform.position.x)
                {
                    
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    transform.Translate(Vector3.left * 5 * Speed * Time.deltaTime);
                }
                if (Player.transform.position.x > transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    transform.Translate(Vector3.left * 5 * Speed * Time.deltaTime);
                }
            }
            if ((Vector3.Distance(transform.position, Player.transform.position) <= 3) && isSflag)
            {
                Player.GetComponent<hero_move>().GetHurt(10 * BasicAttack);
                Player.transform.Translate(Vector3.left * 250 * Speed * Time.deltaTime);
                Player.transform.Translate(Vector3.up * 60 * Speed * Time.deltaTime);
                isSflag = false;
                transform.GetChild(4).gameObject.SetActive(false);
            }
        }
    }


    void Die()
    {
        Destroy(GameObject.FindGameObjectWithTag("helper1"));
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


    void Move()
    {
        //run
        anim.SetBool("run", false);
        anim.SetBool("attack", false);
        if (Vector3.Distance(transform.position, Player.transform.position) <= 10 && Vector3.Distance(transform.position, Player.transform.position) > 2.5)
        {
            anim.SetBool("run", true);

            if (Player.transform.position.x < transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.Translate(Vector3.left * Speed * Time.deltaTime);
            }
            if (Player.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                transform.Translate(Vector3.left * Speed * Time.deltaTime);
            }
        }
        if (transform.position.y < -5)
        {
            transform.Translate(Vector3.up * 150 * Time.deltaTime + Vector3.right * 2000 * Time.deltaTime);

        }
        //attack
        if (Math.Abs(transform.position.x - Player.transform.position.x) <= 3 && Math.Abs(transform.position.y - Player.transform.position.y) <= 5)
        {

            anim.SetBool("attack", true);
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackTime)
            {
                Player.GetComponent<hero_move>().GetHurt(this.Attack);
                attackTimer = 0;
            }
        }



    }

    // Update is called once per frame
    void Update()
    {    
        if (!GameCtr._instance.isPause)
        {
            Skill3();

            if (!isDie)
            {
                if (isSkill1)
                {
                    if (flag || count == 0)
                    {
                        count++;
                        flag = false;
                        Skill1();
                    }

                    Timer += Time.deltaTime;
                    if (Timer > BossSkill1Frequency)
                    {
                        flag = true;
                        Timer = 0;
                    }

                    BossSkill1Timer += Time.deltaTime;
                    if (BossSkill1Timer >= BossSkill1Time)
                    {
                        isSkill1 = false;
                        BossSkill1Timer = 0;
                    }
                }

                if (!isSkill1)
                {
                    BossSkill1CdTimer += Time.deltaTime;
                    if (BossSkill1CdTimer >= BossSkill1CdTime + 2.5f)
                    {
                        isSkill1 = true;
                        BossSkill1CdTimer = 0;
                    }
                }                
            }

            System.Random ran = new System.Random(DateTime.Now.Millisecond);
            Attack = ran.Next((int)(BasicAttack * 0.8), (int)(BasicAttack * 1.2) + 1);

            if (!isDie && !Player.GetComponent<hero_move>().isDie)
            {
                Move();
                Skill2();
              
            }
            else
            {
                anim.SetBool("attack", false);
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
