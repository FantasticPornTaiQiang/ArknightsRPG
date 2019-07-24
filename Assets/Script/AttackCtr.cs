using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCtr : MonoBehaviour
{
    private int PlayerAttack;

    // Use this for initialization
    void Start()
    {
        PlayerAttack = GameObject.FindGameObjectWithTag("Player").GetComponent<hero_move>().Attack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<enemy_ctr>().GetHurt(PlayerAttack);
        }
        if (collision.gameObject.tag == "boss1")
        {
            collision.gameObject.GetComponent<Boss_Ctr>().GetHurt(PlayerAttack);
        }
        if (collision.gameObject.tag == "boss2")
        {
            collision.gameObject.GetComponent<Boss2Ctr>().GetHurt(PlayerAttack);
        }
        if (collision.gameObject.tag == "boss3")
        {
            collision.gameObject.GetComponent<Boss3Ctr>().GetHurt(PlayerAttack);
        }
        if (collision.gameObject.tag == "boss4")
        {
            collision.gameObject.GetComponent<Boss4Ctr>().GetHurt(PlayerAttack);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
