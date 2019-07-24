using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballCtr : MonoBehaviour
{

    private float BaseballTimer;

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<enemy_ctr>().GetHurt(GameObject.FindGameObjectWithTag("helper1").GetComponent<HelperCtr>().BaseballAttack);
        }
        if (collision.gameObject.tag == "boss1")
        {
            collision.gameObject.GetComponent<Boss_Ctr>().GetHurt(GameObject.FindGameObjectWithTag("helper1").GetComponent<HelperCtr>().BaseballAttack);
        }
    }

    // Update is called once per frame
    void Update()
    {
            BaseballTimer += Time.deltaTime;
            if (GameObject.FindGameObjectWithTag("boss1").GetComponent<Boss_Ctr>().isDie)
            {
                Destroy(gameObject);
            }
            if (BaseballTimer >= GameObject.FindGameObjectWithTag("helper1").GetComponent<HelperCtr>().BaseballExistTime)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector2.right * GameObject.FindGameObjectWithTag("helper1").GetComponent<HelperCtr>().BaseballSpeed * Time.deltaTime);
        
    }
}
