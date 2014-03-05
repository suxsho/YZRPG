using UnityEngine;
using System.Collections;

public class cheatingDefeat : MonoBehaviour {
    //-----------------------------------------------------------------
    //          反作弊功能，加载到游戏需要检测作弊的场景里
    //-----------------------------------------------------------------
	// Use this for initialization
	void Start () 
    {
        //检测玩家是否手动调整了总游戏次数的设置，如果总游戏次数比版本大就将总游戏次数归零
        if (PlayerPrefs.GetInt("totalGame") > gameConfig.ver)
        {
            PlayerPrefs.SetInt("totalGame", 0);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
