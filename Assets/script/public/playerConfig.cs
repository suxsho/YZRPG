using UnityEngine;
using System.Collections;

public class playerConfig : MonoBehaviour {
    float nextTime = 0.0f;                //下次时间计时
    float nextSpeed = 1.0f;               //频率，可手动修改
    //-----------------------------------------------------------------
    //          玩家数据显示设置，拖放到每一页的摄像机上
    //-----------------------------------------------------------------
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        gameConfig.Vit =  PlayerPrefs.GetInt("Vit");                            //获取当前体力
        gameConfig.level = PlayerPrefs.GetInt("level");                         //获取当前等级
        gameConfig.exp = PlayerPrefs.GetInt("exp");                             //获取当前经验
        gameConfig.maxExp = (gameConfig.level + 5) * (gameConfig.level * 8);    //计算经验
        gameConfig.money = PlayerPrefs.GetInt("money");                         //获得金币 
        if(gameConfig.web)
            vitPlus();                                   //调用体力增加功能
        levelUP();                                       //调用升级功能
	}
    //-----------------------------------------------------------------
    //          一分钟增加1点体力的设置
    //-----------------------------------------------------------------
    void vitPlus()
    {
        //时间频率控制器，不要随意修改
        if (Time.time > nextTime)
        {
            nextTime = Time.time + nextSpeed;
            // 下面是每次可执行的脚本
            gameConfig.viTime -= 1;
        }
        //时间到了后体力增加1
        if (gameConfig.viTime <= 0)
        {
            gameConfig.viTime = 60;                     //将时间还原到60秒
            if (gameConfig.Vit < 300)                   //限制体力到300
            {
                gameConfig.Vit += 1;                    //体力增加1
            }
            PlayerPrefs.SetInt("Vit", gameConfig.Vit);  //存档
        }
    }
    //-----------------------------------------------------------------
    //          升级
    //-----------------------------------------------------------------
    void levelUP()
    {
        if (gameConfig.exp >= gameConfig.maxExp)
        {
            int moreExp = gameConfig.exp - gameConfig.maxExp;
            gameConfig.level += 1;
            PlayerPrefs.SetInt("level", gameConfig.level);  //存档
            gameConfig.exp = moreExp;
            PlayerPrefs.SetInt("exp", gameConfig.exp);
        }
    }
}
