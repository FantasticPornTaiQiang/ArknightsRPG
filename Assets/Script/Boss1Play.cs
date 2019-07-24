using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Play : MonoBehaviour
{
    public float EnemyTime;
    public float MedicineTime;
    private float EnemyTimer;
    private float MedicineTimer;
    public GameObject Enemy;
    public GameObject Medicine;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameObject.FindGameObjectWithTag("boss1").GetComponent<Boss_Ctr>().isDie)
        {
            EnemyTimer += Time.deltaTime;
            if (EnemyTimer > EnemyTime)
            {
                EnemyTimer = 0;
                Instantiate(Enemy, transform.position + transform.up, Quaternion.identity);
            }

            MedicineTimer += Time.deltaTime;
            if (MedicineTimer > MedicineTime)
            {
                MedicineTimer = 0;
                float x = new System.Random().Next(-1140, 950);
                x /= 100;
                Instantiate(Medicine, new Vector3(x, transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("item").transform);
            }
            
        }
	}
}
