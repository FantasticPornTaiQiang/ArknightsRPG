using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmCtr : MonoBehaviour
{
    GameObject Player;

    bool isGround = true;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Player.GetComponent<hero_move>().GetHurt(GameObject.FindGameObjectWithTag("boss3").GetComponent<Boss3Ctr>().BossSkill2Attack);
        if (collision.tag == "ground")
            isGround = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isGround)
        {
            transform.Translate(Vector3.down * 10 * Time.deltaTime);
        }
       
    }
}
