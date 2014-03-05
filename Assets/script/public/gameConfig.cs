using UnityEngine;
using System.Collections;
//-----------------------------------------------------------------
//游戏发布设置，这个脚本加载到LOGO读取的地方，启动游戏的时候加载一次
//-----------------------------------------------------------------
public class gameConfig : MonoBehaviour {
    //-----------------------------------------------------------------
    //     平台选择，根据平台手动修改内容以确定加载发布版本的代码
    //-----------------------------------------------------------------
    static public bool windows      = false;         //WINDOWS 平台 默认是 true
    static public bool web          = true;         //web平台
    static public bool ios          = false;        //IOS平台 模式false
    static public bool android      = false;        //android平台 默认false
    static public bool winRT        = false;        //Windows store 默认false
    static public bool WP           = false;        //WP平台 默认false
    //-----------------------------------------------------------------
    //                          游戏的加载信息
    //-----------------------------------------------------------------
    static public int ver = 9;            //当前游戏的版本
    static public int Vit;                          //体力值
    static public int viTime        = 60;           //体力值倒计时，时间到了后体力增加1
    int totalGame;                                  //获取总共游戏的次数
    static public int level;                        //获取等级
    static public int exp;                          //获取经验
    static public int maxExp;                       //总经验   
    static public int money;                        //金币   
    // Use this for initialization
	void Start () 
    {
        //-----------------------------------------------------------------
        //                          设置存档信息
        //-----------------------------------------------------------------
        //WEB版本
       if(web)
       {
            //检测是否有体力存档，没有就赋值
            if (!PlayerPrefs.HasKey("Vit"))
            {
                PlayerPrefs.SetInt("Vit", 100);         
            }
            //检查版本是否存储，没有就存储玩家游戏的版本，方便以后维护解决一些问题
            if (!PlayerPrefs.HasKey("ver"))
            {
                PlayerPrefs.SetInt("ver", ver);         
            }
           //给玩家设定初始版本
            if (!PlayerPrefs.HasKey("totalGame"))
            {
                PlayerPrefs.SetInt("totalGame", 0);
            }
            //给玩家设定等级
            if (!PlayerPrefs.HasKey("level"))
            {
                PlayerPrefs.SetInt("level", 1);
            }
            //给玩家设定经验
            if (!PlayerPrefs.HasKey("exp"))
            {
                PlayerPrefs.SetInt("exp", 0);
            }
            //给玩家设定金币
            if (!PlayerPrefs.HasKey("money"))
            {
                PlayerPrefs.SetInt("money", 500);
            }
       }
	}
	
	// Update is called once per frame
	void Update () 
    {
        //-----------------------------------------------------------------
        //                          读取存档信息
        //-----------------------------------------------------------------
        //判断玩家新版本是否来玩了，如果来了总游戏次数就增加1次，以后做活动用
        if (PlayerPrefs.GetInt("ver") < ver)
        {
            totalGame = PlayerPrefs.GetInt("totalGame");        //获得当前总共游戏的次数
            totalGame += 1;                                         //增加一次
            PlayerPrefs.SetInt("ver", ver);                         //将玩家玩过的最新版本存储更新
            PlayerPrefs.SetInt("totalGame", totalGame);             //更新总共游戏次数
            /**加载活动*/
           Vit_500UP();                                            //8888活动
        }
	}
    //-----------------------------------------------------------------
    //                          奖励钱和体力活动
    //-----------------------------------------------------------------
    void Vit_500UP()
    {
        if (PlayerPrefs.GetInt("totalGame") > 1)
        {
            if (PlayerPrefs.GetInt("money") - 8888 < 0)
            {
                money = 8888;
                PlayerPrefs.SetInt("money",money);
            }
            Vit = 500;
            PlayerPrefs.SetInt("Vit", Vit);
        }
    }
}
