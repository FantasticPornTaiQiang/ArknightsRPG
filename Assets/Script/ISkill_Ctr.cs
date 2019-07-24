using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISkill_Ctr : MonoBehaviour
{
    private int ISpeed;
    private float ISkillTimer;

    // Use this for initialization
    void Start()
    {
        ISpeed = GameObject.FindGameObjectWithTag("Player").GetComponent<hero_move>().ISkillpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<enemy_ctr>().GetHurt(GameObject.FindGameObjectWithTag("Player").GetComponent<hero_move>().ISkillAttack);
        }
        if (collision.gameObject.tag == "boss1")
        {
            collision.gameObject.GetComponent<Boss_Ctr>().GetHurt(GameObject.FindGameObjectWithTag("Player").GetComponent<hero_move>().ISkillAttack);
        }
        if (collision.gameObject.tag == "boss2")
        {
            collision.gameObject.GetComponent<Boss2Ctr>().GetHurt(GameObject.FindGameObjectWithTag("Player").GetComponent<hero_move>().ISkillAttack);
        }
        if (collision.gameObject.tag == "boss3")
        {
            collision.gameObject.GetComponent<Boss3Ctr>().GetHurt(GameObject.FindGameObjectWithTag("Player").GetComponent<hero_move>().ISkillAttack);
        }
        if (collision.gameObject.tag == "boss4")
        {
            collision.gameObject.GetComponent<Boss4Ctr>().GetHurt(GameObject.FindGameObjectWithTag("Player").GetComponent<hero_move>().ISkillAttack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ISkillTimer += Time.deltaTime;
        if (ISkillTimer >= GameObject.FindGameObjectWithTag("Player").GetComponent<hero_move>().ISkillTime)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * ISpeed * Time.deltaTime);
    }
}
