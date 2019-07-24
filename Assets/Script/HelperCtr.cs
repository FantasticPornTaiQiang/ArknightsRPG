using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperCtr : MonoBehaviour
{

    public Animator anim;
    public Slider HelperHPSlider;
    public int Health;
    public GameObject Baseball;
    public float SkillTime;
    public float BaseballExistTime;
    public int BaseballSpeed;
    public int BaseballAttack;
    private float SkillTimer;
    internal bool isDie;
    private float redTimer;
    public AudioClip 挥棒球棒;
    internal int count;
    private float Angletimer;


    // Use this for initialization
    void Start()
    {

    }

    public void GetHurt(int BossAttack)
    {
        if (!isDie)
        {
            Health -= BossAttack;
            GetComponent<SpriteRenderer>().color = Color.red;
            if (Health <= 0)
            {
                isDie = true;
                anim.SetBool("attack", false);
                transform.rotation = Quaternion.Euler(0, 0, -90);
                transform.Translate(Vector2.up * 130 * 3 * Time.deltaTime, Space.World);
                Destroy(gameObject, 1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDie)
        {
            anim.SetBool("attack", true);
            SkillTimer += Time.deltaTime;
            if (SkillTimer > SkillTime)
            {
                GetComponent<AudioSource>().Play();
                Instantiate(Baseball, transform.position + transform.right, transform.rotation);
                SkillTimer = 0;
            }
        }

        //if (GameObject.FindGameObjectWithTag("boss3").GetComponent<Boss3Ctr>().isDie  && GameObject.FindGameObjectWithTag("boss4").GetComponent<Boss4Ctr>().isDie)
        //    Destroy(GameObject.FindGameObjectWithTag("helper1"));

        if (GetComponent<SpriteRenderer>().color == Color.red)
        {
            redTimer += Time.deltaTime;
            if (redTimer >= 0.15f)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                redTimer = 0;
            }
        }

        if (!GameObject.FindGameObjectWithTag("boss4") && GameObject.FindGameObjectWithTag("boss3"))
        {
            Angletimer += Time.deltaTime;
            if (Angletimer > 0.5f)
            {
                Angletimer = 0;
                count++;
                if (count >= 6)
                {
                    count = 0;
                }
            }
      
        }

        HelperHPSlider.value = Health;
    }
}
