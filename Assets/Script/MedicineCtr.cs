using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineCtr : MonoBehaviour {

    public float timer;
    //private float flashtimer;

    // Use this for initialization
    void Start ()
    {
        transform.Translate(Vector2.up * 200 * 1 * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Destroy(GetComponent<Rigidbody2D>());
        }
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer > 9f && transform.parent.gameObject == GameObject.FindGameObjectWithTag("item"))
        {
            timer = 0;
            Destroy(gameObject);
        }

    }
}
