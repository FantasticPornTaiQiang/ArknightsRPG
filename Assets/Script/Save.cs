using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    #region 游戏数据
    public int lv;
    public int hp;
    public int attack;
    public int stage;
    public int MaxHealthWithLv;
    public int LvExperience;
    public int MaxLvExperience;
    public int LvCount;
    public bool[]num = new bool[18];
    public bool U;

    #endregion


}
