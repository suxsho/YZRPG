using UnityEngine;
using System.Collections;

public class battleUI : MonoBehaviour {
    //-----------------------------------------------------------------
    //          战斗功能
    //-----------------------------------------------------------------
    public GUISkin batUISkin;               //加载顶部UI显示文字部分的皮肤
    public GUISkin damageUISkin;            //加载伤害显示皮肤
    float nextTime = 0.0f;                  //下次时间计时
    public float shakeSpeed = 0.2f;         //频率，可手动修改
    bool playerAtt = true;                  //是否为主角攻击阶段（否则怪攻击
    int damegeValue = 0;                //伤害显示
    bool battleCon = false;                  //判断战斗是否开启
    int record = 0;                //奖励显示
    //-----------------------------------------------------------------
    //         模拟数据，这个只是模拟的
    //-----------------------------------------------------------------
    public float playerHP, playerStr, playerDef, monsterHP, monsterStr, monsterDef, monsterHpMax, playerHpMax, damage;
    int monsterLevel,monsterExp,monsterMoney,times,lostMoney;
    static public bool buySword = false;      //模拟买剑
     void OnGUI()
    {
        GUI.skin = batUISkin;                                                                                                                               //加载皮肤
        /**血条*/
        GUI.Box(new Rect(Screen.width / 2 - 110, 60, (Screen.width - 650) * (monsterHP / monsterHpMax), Screen.height / 2 - 240), "");                      //怪物血条
        GUI.Box(new Rect(20, Screen.height - 50, (Screen.width - 650) * (playerHP / playerHpMax), Screen.height / 2 - 240), "");                      //玩家血条
        /**数值显示*/
        GUI.Label(new Rect(Screen.width / 2 - 150, 60, Screen.width - 600, Screen.height / 2 - 240), "Lv:" + monsterLevel + "方块怪 HP:" + monsterHP + "/" + monsterHpMax);    //怪物描述
        GUI.Label(new Rect(0, Screen.height - 50, Screen.width - 600, Screen.height / 2 - 240), "Lv:"+gameConfig.level+"亚布力 HP:" + playerHP + "/" + playerHpMax);          //玩家描述
        /**伤害显示*/
        GUI.skin = damageUISkin;           //加载伤害显示皮肤
        if (damegeValue == 1)
            GUI.Label(new Rect(Screen.width / 2, 90, 80, Screen.height / 2 - 240), "-" + damage);          //怪物伤害
        else if (damegeValue == 2)
            GUI.Label(new Rect(250, Screen.height - 80, 80, Screen.height / 2 - 240), "-" + damage);         //玩家伤害
        /**结算显示*/
         if (record == 1)
             GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 100), "战斗胜利，获得经验：" + monsterExp + " 获得金币：" + monsterMoney);         //胜利
         if (record == 2)
             GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 100), "战斗失败，丢失金钱：" + lostMoney);         // 失败
         if (record == 0)
             GUI.Label(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 100), "战斗开始");         // 失败
        /**逃走（测试*/
         if (times > 0 && battleCon)
         {
             if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height - 100, 300, 50), "扔掉" + lostMoney + "金币逃走"))
             {
                 /*
                 if (gameConfig.money - Mathf.Round(monsterMoney / 5 * times) >= 0)
                 {
                     gameConfig.money -= lostMoney;
                     PlayerPrefs.SetInt("money", gameConfig.money);  //存档
                 }
                 else
                 {
                     gameConfig.money = 0;
                     PlayerPrefs.SetInt("money", gameConfig.money);  //存档
                 }*/
                 gameConfig.money -= lostMoney;
                 PlayerPrefs.SetInt("money", gameConfig.money);  //存档
                 record = 2;                 //显示UI
                 battleCon = false;
                 StartCoroutine(battleOver());
             }   
         }
         
    } 
	// Use this for initialization
	void Start () 
    {
        //-----------------------------------------------------------------
        //         怪物等级模拟
        //-----------------------------------------------------------------
        //出怪等级
        if (gameConfig.level == 1)
            monsterLevel = Random.Range(1, 1);
        if (gameConfig.level == 2)
            monsterLevel = Random.Range(1, 3);
        if (gameConfig.level == 3)
            monsterLevel = Random.Range(1, 4);
        if (gameConfig.level >= 4 && gameConfig.level <= 8)
            monsterLevel = Random.Range(gameConfig.level - 3, gameConfig.level +3);
        if (gameConfig.level >= 9 && gameConfig.level <= 13)
            monsterLevel = Random.Range(gameConfig.level - 5, gameConfig.level + 5);
        if (gameConfig.level >= 14 && gameConfig.level <= 18)
            monsterLevel = Random.Range(gameConfig.level - 10, gameConfig.level + 10);
        if (gameConfig.level >= 19 && gameConfig.level <= 23)
            monsterLevel = Random.Range(gameConfig.level - 15, gameConfig.level + 15);
        if (gameConfig.level >= 24 && gameConfig.level <= 28)
            monsterLevel = Random.Range(gameConfig.level - 20, gameConfig.level + 20);
        if (gameConfig.level >= 29 && gameConfig.level <= 35)
            monsterLevel = Random.Range(gameConfig.level - 20, gameConfig.level + 20);
        if (gameConfig.level >= 36 && gameConfig.level <= 49)
            monsterLevel = Random.Range(gameConfig.level - 25, gameConfig.level + 25);
        if (gameConfig.level >= 50)
            monsterLevel = Random.Range(45, 99);
        //加成
        times = 0;
        monsterStr = monsterStr * monsterLevel * 1.05f + Random.Range(-monsterLevel * 10, monsterLevel * 10);
        monsterDef = monsterDef * monsterLevel * 1.02f + Random.Range(-monsterLevel * 10, monsterLevel * 10);
        monsterHP = Mathf.Round(monsterHP * monsterLevel * 1.03f);
        if(!buySword)
            playerStr = playerStr * gameConfig.level * 1.04f;
        if (buySword)
            playerStr = 200 + playerStr * gameConfig.level * 1.04f;
        playerDef = playerDef * gameConfig.level * 1.04f;
        playerHP = Mathf.Round(playerHP * gameConfig.level * 1.05f);
        monsterExp = (monsterLevel + 1) * (monsterLevel * 2);
        monsterMoney = (monsterLevel + 2) * (monsterLevel * 3);
        //-----------------------------------------------------------------
        //         模拟数据，这个只是模拟的
        //-----------------------------------------------------------------
        monsterHpMax = monsterHP;                               //存储怪满血量
        playerHpMax = playerHP;                                 //存储玩家满血量，以上都是计算血条用的
        StartCoroutine(battleStart());                          //加载战斗开始类
	}
	
	// Update is called once per frame
	void Update () 
    {

	     //时间频率控制器，不要随意修改
        if (Time.time > nextTime && battleCon)
        {
            nextTime = Time.time + shakeSpeed;
            //-----------------------------------------------------
            //  下面是每次可执行的脚本
            //-----------------------------------------------------
            if (playerAtt)
            {
                times += 1;
                damage = Mathf.Round(100 * (playerStr + Random.Range(gameConfig.level * -5, gameConfig.level * 5)) / (monsterDef + 30 + Random.Range(-5, 5)));
                monsterHP -= damage;
                gameConfig.Vit -= 1;
                PlayerPrefs.SetInt("Vit", gameConfig.Vit);  //存档
                print(gameConfig.Vit);
                playerAtt = false;
                lostMoney = monsterMoney / 15 * times;
                damegeValue = 1;
                //胜利奖励
                if (monsterHP <= 0)
                {
                    monsterHP = 0;
                    record = 1;                                 //加载胜利内容
                    gameConfig.exp += monsterExp;
                    PlayerPrefs.SetInt("exp", gameConfig.exp);  //存档
                    monsterMoney *= Random.Range(1, 10);
                    gameConfig.money += monsterMoney;
                    PlayerPrefs.SetInt("money", gameConfig.money);  //存档
                    StartCoroutine(battleOver());
                }
            }
            else
            {
                damage = Mathf.Round(100 * (monsterStr + Random.Range(monsterLevel * -5, monsterLevel * 5)) / (playerDef + 30 + Random.Range(-5, 5)));
                playerHP =Mathf.Round( playerHP -  damage);
                playerAtt = true;
               damegeValue = 2;
                //战斗失败
                if (playerHP <= 0)
                {
                    playerHP = 0;
                    lostMoney *= Random.Range(1,10);
                    record = 2;                 //显示UI
                    //扣钱
                    gameConfig.money -= lostMoney;
                    PlayerPrefs.SetInt("money", gameConfig.money);  //存档
                    StartCoroutine(battleOver());
                }
            }
        }
	}
    //-----------------------------------------------------
    //                      战斗结束
    //-----------------------------------------------------
    IEnumerator battleOver()
    {
        battleCon = false;
        yield return new WaitForSeconds(2.0f);
        Camera.main.SendMessage("fadeOut"); //发送黑屏信息
        yield return new WaitForSeconds(0.4f);
        Application.LoadLevel(6);           //加载对应的场景

    }
    //-----------------------------------------------------
    //                      战斗开始
    //-----------------------------------------------------
    IEnumerator battleStart()
    {
        yield return new WaitForSeconds(0.5f); //等待2秒，用于切换场景以及显示文字等
        nextTime = Time.time + shakeSpeed;
        record = 3;                             //隐藏战斗开始文字
        battleCon = true;
    }
}
