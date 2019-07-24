using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System;

public class enemy_ctr : MonoBehaviour
{
    public GameObject Player;
    //public GameObject Helper;
    public float Speed;
    public Animator anim;
    private bool isDie = false;
    private float timer;
    public int BasicAttack;
    internal int Attack;
    public int Health;
    private float attackTimer;
    public float attackTime;
    //特效
    public Transform HurtPos;
    public GameObject HurtEffect;
    public Slider EnemyHPSlider;
    public GameObject Medicine;
    public int PercantageOfMedicine;
    public int AddLv;
    private int DieCount;

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



    void Die()
    {
        DieCount++;

        Player.GetComponent<hero_move>().LvExperience += AddLv;
        if (Player.GetComponent<hero_move>().LvExperience >= Player.GetComponent<hero_move>().MaxLvExperience)
        {
            Player.GetComponent<hero_move>().LvTemp = Player.GetComponent<hero_move>().LvExperience -
                                                      Player.GetComponent<hero_move>().MaxLvExperience;
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
            Instantiate(Medicine, transform.position + transform.up, Quaternion.identity,GameObject.FindGameObjectWithTag("item").transform);
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
        if (Vector3.Distance(transform.position, Player.transform.position) <= 5 && Vector3.Distance(transform.position, Player.transform.position) > 1)
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
        //attack
        if (Math.Abs(transform.position.x - Player.transform.position.x) <= 1.3 && Math.Abs(transform.position.y - Player.transform.position.y) <= 2)
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
            System.Random ran = new System.Random(DateTime.Now.Millisecond);
            Attack = ran.Next((int)(BasicAttack * 0.8), (int)(BasicAttack * 1.2) + 1);

            if (!isDie && !Player.GetComponent<hero_move>().isDie)
            {
                Move();
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

            if (gameObject.transform.position.y < -10 && DieCount == 0)
            {
                isDie = true;
                Die();
            }

            EnemyHPSlider.value = Health;
        }
    }
}