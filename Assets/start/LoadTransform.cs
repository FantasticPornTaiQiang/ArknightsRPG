using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTransform : MonoBehaviour
{
    private int i;

    private Save save;
    // Use this for initialization
    void Start () {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.OpenRead(Application.dataPath + "/SaveData" + "/data.txt");
        save = (Save)bf.Deserialize(fileStream);
        fileStream.Close();
    }

    public void Onclick()
    {
        SceneManager.LoadScene(save.stage);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
