using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BaseballCtrBoss3 : MonoBehaviour
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
        if (collision.gameObject.tag == "boss3")
        {
            collision.gameObject.GetComponent<Boss3Ctr>().GetHurt(GameObject.FindGameObjectWithTag("helper1").GetComponent<HelperCtr>().BaseballAttack);
        }
        if (collision.gameObject.tag == "boss4")
        {
            collision.gameObject.GetComponent<Boss4Ctr>().GetHurt(GameObject.FindGameObjectWithTag("helper1").GetComponent<HelperCtr>().BaseballAttack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        BaseballTimer += Time.deltaTime;
        if (GameObject.FindGameObjectWithTag("boss3").GetComponent<Boss3Ctr>().isDie)
        {
            Destroy(gameObject);
        }
        if (BaseballTimer >= GameObject.FindGameObjectWithTag("helper1").GetComponent<HelperCtr>().BaseballExistTime)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * GameObject.FindGameObjectWithTag("helper1").GetComponent<HelperCtr>().BaseballSpeed * Time.deltaTime);
        if (!GameObject.FindGameObjectWithTag("boss4"))
        {
                transform.Translate(Vector2.up * GameObject.FindGameObjectWithTag("helper1").GetComponent<HelperCtr>().count * Time.deltaTime);
        }
    }
}
