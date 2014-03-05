using UnityEngine;
using System.Collections;
//-----------------------------------------------------------------
//                    顶部UI
//-----------------------------------------------------------------
public class topUI : MonoBehaviour {
   public GUISkin topUISkin;              //加载顶部UI显示文字部分的皮肤
   public GUISkin topUIBank;              //加载顶部UI背景的皮肤
   public Texture icon;
	// Use this for initialization
	void Start () 
    {
	
	}
    //-----------------------------------------------------------------
    //                   GUI部分
    //-----------------------------------------------------------------
    void OnGUI()
    {
        //-----------------------------------------------------------------
        //                    1280 * 720
        //-----------------------------------------------------------------
        /**1280X720
        GUI.skin = topUIBank;       //加载外部背景
        GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height-290));
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height/2 - 290), "");                                                //底层背景
        GUI.skin = topUISkin;       //加载内部背景
        GUI.Box(new Rect(2, 2, Screen.width / 2 - 144, Screen.height / 2 - 293), "Money：0");                     //显示金币
        GUI.Box(new Rect(Screen.width / 2 - 140, 2, Screen.width / 2 - 247, Screen.height / 2 - 293), "Rare：0"); //显示道具
        GUI.Box(new Rect(Screen.width / 2 + 255, 2, Screen.width / 2 - 256, Screen.height / 2 - 293), "Vit："+ gameConfig.Vit + "("+ gameConfig.viTime + ")");  //显示体力
        GUI.EndGroup();*/
        //-----------------------------------------------------------------
        //                    960 * 640
        //-----------------------------------------------------------------
        /**显示玩家的力量*/
        if (!battleUI.buySword)
            GUI.Box(new Rect(Screen.width - 150, Screen.height - 20, 150, 20), "STR:" + Mathf.Round(20 * gameConfig.level * 1.04f) + " DEF:" + Mathf.Round(18 * gameConfig.level * 1.04f));
        if (battleUI.buySword)
            GUI.Box(new Rect(Screen.width - 150, Screen.height - 20, 150, 20), "STR:" + Mathf.Round(200 + 20 * gameConfig.level * 1.04f) + " DEF:" + Mathf.Round(18 * gameConfig.level * 1.04f));
        /**显示购买的武器*/
        if (!battleUI.buySword)
            GUI.Box(new Rect(Screen.width - 100, Screen.height - 100, 50, 50),"");
        if (battleUI.buySword)
            GUI.Box(new Rect(Screen.width - 100, Screen.height - 100, 50, 50), new GUIContent(icon));
        /**960X640*/
       GUI.skin = topUIBank;       //加载外部背景
       GUI.BeginGroup(new Rect(0,0, Screen.width, Screen.height-100));
       GUI.Box(new Rect(0, 0, Screen.width, Screen.height/2 - 220), "");                                         //底层背景
       GUI.skin = topUISkin;       //加载内部背景
       GUI.Box(new Rect(2, 2, Screen.width / 2 - 144, Screen.height / 2 - 223), "Money：" + gameConfig.money);                     //显示金币
       GUI.Box(new Rect(Screen.width / 2 - 140, 2, Screen.width / 2 - 144, Screen.height / 2 - 223), "Rare：0"); //显示道具
       GUI.Box(new Rect(Screen.width / 2 + 198, 2, Screen.width / 2 - 200, Screen.height / 2 - 223), "Vit："+ gameConfig.Vit + "("+ gameConfig.viTime + ")");  //显示体力
       GUI.EndGroup();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
