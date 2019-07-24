using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameCtr : MonoBehaviour
{

    #region 组件
    public static GameCtr _instance;
    public bool isPause;
    public GameObject menuGo;
    public Toggle musicCtr;
    #endregion

    #region 音乐控制
    public AudioSource musicSource;
    public AudioSource musicSource2;
    #endregion

    public Text message;

    GameObject Player;

    public void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        _instance = this;
        if (PlayerPrefs.HasKey("MusicOn"))
        {
            if (PlayerPrefs.GetInt("MusicOn") == 1)
            {
                musicCtr.isOn = true;
                musicSource.enabled = true;
                musicSource2.enabled = true;
            }
            else
            {
                musicCtr.isOn = false;
                musicSource.enabled = false;
                musicSource2.enabled = false;
            }
        }
        else
        {
            musicCtr.isOn = true;
            musicSource.enabled = true;
            musicSource2.enabled = true;
        }

    }
    private void Pause()
    {
        isPause = true;
        menuGo.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    private void UnPause()
    {
        isPause = false;
        menuGo.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void Continue()
    {
        UnPause();
        ShowMessage("");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SaveGame()
    {
        SaveBin();
        if (File.Exists(Application.dataPath + "/SaveData" + "/data.txt"))
            ShowMessage("保存成功");
        else
            ShowMessage("保存失败");
    }

    public void LoadGame()
    {
        LoadBin();
        ShowMessage("读档成功");
    }

    //读档且设置游戏
    private void SetGame(Save save)
    {
        Player.GetComponent<hero_move>().setHP(save.hp, save.MaxHealthWithLv);
        Player.GetComponent<hero_move>().Attack = save.attack;
        Player.GetComponent<hero_move>().setLv(save.lv, save.LvExperience);
        Player.GetComponent<hero_move>().stage = save.stage;
        Player.GetComponent<hero_move>().LvExperience = save.LvExperience;
        Player.GetComponent<hero_move>().MaxLvExperience = save.MaxLvExperience;
        Player.GetComponent<hero_move>().LvCount = save.LvCount;
        save.num.CopyTo(Player.GetComponent<hero_move>().num, 0);
        if (save.U)
        {
            Player.GetComponent<hero_move>().Attack -= Player.GetComponent<hero_move>().USkillAddAttack;
        }

        UnPause();
    }


    //保存是否成功的文字赋值
    public void ShowMessage(string str)
    {
        message.text = str;
    }

    //音乐勾选
    private void musicSwitch()
    {
        if (musicCtr.isOn == false)
        {

            musicSource.enabled = false;
            musicSource2.enabled = false;
            //保存音乐开关状态 0为false
            PlayerPrefs.SetInt("MusicOn", 0);
        }
        else
        {

            musicSource.enabled = true;
            musicSource2.enabled = true;
            //保存音乐开关状态 1为true
            PlayerPrefs.SetInt("MusicOn", 1);
        }
        PlayerPrefs.Save();
    }
    //创建保存类
    private Save CreateSave()
    {
        Save save = new Save();
        save.hp = Player.GetComponent<hero_move>().getHP();
        save.lv = Player.GetComponent<hero_move>().getLv();
        save.attack = Player.GetComponent<hero_move>().Attack;
        save.stage = Player.GetComponent<hero_move>().stage;
        save.LvExperience = Player.GetComponent<hero_move>().LvExperience;
        save.MaxHealthWithLv = Player.GetComponent<hero_move>().getMaxHealthWithLv();
        save.MaxLvExperience = Player.GetComponent<hero_move>().MaxLvExperience;
        save.LvCount = Player.GetComponent<hero_move>().LvCount;
        Player.GetComponent<hero_move>().num.CopyTo(save.num, 0);
        save.U = Player.GetComponent<hero_move>().getU();
        save.stage = Player.GetComponent<hero_move>().stage;
        return save;
    }
    //序列化
    private void SaveBin()
    {
        Save save = CreateSave();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.dataPath + "/SaveData" + "/data.txt");
        bf.Serialize(fileStream, save);
        fileStream.Close();
    }
    //反序列化
    private void LoadBin()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.OpenRead(Application.dataPath + "/SaveData" + "/data.txt");
        Save save = (Save)bf.Deserialize(fileStream);
        fileStream.Close();
        SetGame(save);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        musicSwitch();
    }


}