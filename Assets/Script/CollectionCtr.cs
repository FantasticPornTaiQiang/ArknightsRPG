using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class CollectionCtr : MonoBehaviour
{


    private bool[] num = new bool[18];
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;

    // Use this for initialization
    void Start()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.OpenRead(Application.dataPath + "/SaveData" + "/data.txt");
        Save save = (Save)bf.Deserialize(fileStream);
        fileStream.Close();
        save.num.CopyTo(num, 0);


        for (int i = 0; i < 8; i++)
        {
            if (num[i])
            {
                page1.transform.GetChild(i).gameObject.SetActive(true);
            }

        }
        for (int i = 9; i < 16; i++)
        {
            if (num[i])
            {
                page2.transform.GetChild(i - 9).gameObject.SetActive(true);
            }

        }
        for (int i = 17; i < 18; i++)
        {
            if (num[i])
            {
                page3.transform.GetChild(i - 17).gameObject.SetActive(true);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}