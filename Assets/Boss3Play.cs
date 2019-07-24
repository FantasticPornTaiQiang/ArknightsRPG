using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3Play : MonoBehaviour
{
    public float MedicineTime;
    private float MedicineTimer;
    public GameObject Medicine;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MedicineTimer += Time.deltaTime;
        if (MedicineTimer > MedicineTime)
        {
            MedicineTimer = 0;
            float x = new System.Random().Next(-840, 950);
            x /= 100;
            Instantiate(Medicine, new Vector3(x, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
        }
    }
}