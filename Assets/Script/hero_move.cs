using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hero_move : MonoBehaviour
{
    public float speed;
    public int stage;
    public bool[]num = new bool[18];

    #region 攻击
    public PolygonCollider2D isAttacking;
    public int Attack;
    public int AttackMedicine;
    #endregion

    #region 布尔值和计时器
    private bool UpFlag = true;
    private bool isU = false;
    private float timer;
    internal bool isDie = false;
    private float redTimer;
    private float MpTimer;
    //private int count;
    private float USkillTimer;
    internal int LvCount;
    #endregion

    #region 血量
    private int MinHP = 0;
    public int MaxHealthBasic;
    public Slider HpSlider;
    private int Health;
    private int MaxHealthWithLv;
    public int HealthMedicine;
    #endregion

    #region 音效和动画
    public Animator anim;
    public AudioClip 挥剑;
    public AudioClip 捡东西;
    public AudioClip 跳;
    #endregion

    #region K瞬移
    private int KSumer;
    public int KSum;
    private float KTimer;
    public float KTime;
    public Slider KSlider;
    #endregion

    #region 等级
    public Slider LvSlider;
    private int Lv;
    public int BasicLvExperience;
    internal int LvExperience;
    public Text LvText;
    internal int MaxLvExperience;
    internal int LvTemp;
    #endregion

    #region U/I技能
    public Slider MpSlider;
    public int MagicPower;
    public int MagicAddSpeedPerSecond;
    private float MP;
    public int USkillMP;
    public int USkillAddAttack;
    public int USkillAddSpeed;
    public int USkillTime;
    public int ISkillMP;
    public int ISkillAttack;
    public float ISkillTime;
    public int ISkillpeed;
    public GameObject ISkill;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        if(LvCount == 0)
        {
            Lv = 1;
            LvText.text = "Lv " + Lv;
            LvExperience = 0;
            MaxLvExperience = BasicLvExperience;
            LvSlider.minValue = 0;
            LvCount++;
        }

        KSumer = 0;
        KSlider.maxValue = KSum;
        KSlider.minValue = 0;

        if(Lv == 1)
        {
            MaxHealthWithLv = MaxHealthBasic;
            Health = MaxHealthWithLv;
            HpSlider.maxValue = Health;
            HpSlider.minValue = 0;
        }   

        MpSlider.maxValue = MagicPower;
        MpSlider.minValue = 0;
        MP = MagicPower;

        anim = GetComponent<Animator>();
    }

    void Skill()
    {
        if (Input.GetKeyDown(KeyCode.U) && USkillMP <= MP && !isU)
        {
            MP -= USkillMP;
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(true);
            Attack += USkillAddAttack;
            speed += USkillAddSpeed;
            isU = true;
        }
        if (Input.GetKeyDown(KeyCode.I) && ISkillMP <= MP)
        {
            MP -= ISkillMP;
            Instantiate(ISkill, transform.position + transform.right, transform.rotation);
        }
    }

    void walk()
    {
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed * Time.deltaTime, Space.World);
        anim.SetInteger("RunDir", (int)Input.GetAxisRaw("Horizontal"));
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.K) && KSumer < KSum)
        {
            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal"), 0) * 60 * speed * Time.deltaTime, Space.World);
            KSumer++;
        }
        if (KSumer == KSum)
        {
            KTimer += Time.deltaTime;
            if (KTimer >= KTime)
            {
                KSumer = 0;
                KTimer = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (UpFlag)
            {
                transform.Translate(new Vector2(0, Input.GetAxisRaw("Vertical")) * 60 * speed * Time.deltaTime, Space.World);
                GetComponent<AudioSource>().clip = 跳;
                GetComponent<AudioSource>().Play();
            }
            UpFlag = false;
        }
      
    }

    void attack()
    {
        anim.SetBool("attack", false);
        if (Input.GetKeyDown(KeyCode.J))
        {
            GetComponent<AudioSource>().clip = 挥剑;
            GetComponent<AudioSource>().Play();
            anim.SetBool("attack", true);
            isAttacking.enabled = true;//控制Inspector那里的勾，与Setactive作用一样，只不过setactive用于Gameobj
        }
    }

    private void OnTriggerStay2D(Collider2D other)//捡血药和攻击力药剂
    {
        if (other.gameObject.tag == "medicine")
        {
            GetComponent<AudioSource>().clip = 捡东西;
            GetComponent<AudioSource>().Play();
            Health = Mathf.Clamp(Health + HealthMedicine, 0, MaxHealthWithLv);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "weapon")
        {
            GetComponent<AudioSource>().clip = 捡东西;
            GetComponent<AudioSource>().Play();
            Attack += AttackMedicine;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "ground")
        {
            UpFlag = true;
        }
    }

    public void GetHurt(int EnemyAttack)
    {
        if (!isDie)
        {
            Health -= EnemyAttack;
            GetComponent<SpriteRenderer>().color = Color.red;
            if (Health <= 0)
            {
                isDie = true;
                anim.SetBool("run", false);
                anim.SetBool("attack", false);
                anim.SetBool("wait", false);
                MpSlider.value = 0;
                transform.rotation = Quaternion.Euler(0, 0, -90);
                transform.Translate(Vector2.up * 130 * speed * Time.deltaTime, Space.World);
                Destroy(gameObject, 5f);
            }
        }
    }

    public void LvUP()
    {
        LvExperience = LvTemp;
        MaxLvExperience += 200;//每升一级加200经验
        Lv++;
        LvText.text = "Lv " + Lv;
        MaxHealthWithLv += (int)(HpSlider.maxValue * 0.05);
        HpSlider.maxValue = MaxHealthWithLv;
        Attack += AttackMedicine;
        MpSlider.value = MpSlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDie)
        {
            SceneManager.LoadScene(29);
        }
        if (gameObject.transform.position.y < -10 )
        {
            SceneManager.LoadScene(29);
        }
        if (!GameCtr._instance.isPause)
        {
            if (!isDie)
            {
                walk();
                attack();
                Skill();
            }
            if (isAttacking.enabled)
            {
                timer += Time.deltaTime;
                if (timer > 0.04f)
                {
                    timer = 0;
                    isAttacking.enabled = false;
                }
            }
            if (GetComponent<SpriteRenderer>().color == Color.red)
            {
                redTimer += Time.deltaTime;
                if (redTimer >= 0.15f)
                {
                    GetComponent<SpriteRenderer>().color = Color.white;
                    redTimer = 0;
                }
            }

            HpSlider.value = Health;

            KSlider.value = KSum - KSumer;

            LvSlider.maxValue = MaxLvExperience;
            LvSlider.value = LvExperience;

            MpTimer += Time.deltaTime;
            if (MpTimer >= 0.05f)
            {
                MpTimer = 0;
                if (MP < MpSlider.maxValue && !isU)
                {
                    MP = Mathf.Clamp(MP + (float)(MagicAddSpeedPerSecond * 0.05), 0, MpSlider.maxValue);
                }
            }

            if (isU)
            {
                USkillTimer += Time.deltaTime;
                if (USkillTimer >= USkillTime)
                {
                    isU = false;
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(false);
                    Attack -= USkillAddAttack;
                    speed -= USkillAddSpeed;

                    USkillTimer = 0;
                }
            }

            //if (gameObject.transform.position.y < -10 && count == 0)
            //{
            //    isDie = true;
            //    count++;
            //    Destroy(gameObject,1f);
            //}

            MpSlider.value = MP;
        }
    }
    //数据导出函数
    public int getHP()
    {
        return Health;
    }
    public int getLv()
    {
        return Lv;
    }
    public float getMP()
    {
        return MP;
    }
    public int getMaxHealthWithLv()
    {
        return MaxHealthWithLv;
    }

    public bool getU()
    {
        return isU;
    }
    //数据导入函数
    public void setHP(int hp,int MaxHealthWithLv)
    {
        this.MaxHealthWithLv = MaxHealthWithLv;
        HpSlider.maxValue = MaxHealthWithLv;
        Health = hp;
        HpSlider.value = Health;

    }
    public void setLv(int lv,int LvExperience)
    {
        Lv = lv;
        LvSlider.value = LvExperience;
        LvText.text = "Lv " + Lv;
    }
    public void setMP(float mp)
    {
        MP = mp;
    }
   
}