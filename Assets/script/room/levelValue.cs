using UnityEngine;
using System.Collections;
//-----------------------------------------------------------------
//                  显示玩家等级和升级经验
//-----------------------------------------------------------------
public class levelValue : MonoBehaviour {
    public GUISkin UISkin;               //皮肤引用
    void OnGUI()
    {
        GUI.skin = UISkin;       //加载皮肤
        GUI.Label(new Rect(0, 60, Screen.width - 600, Screen.height / 2 - 240), "Lv:" + gameConfig.level + " EXP:" + gameConfig.exp + "/" + gameConfig.maxExp); 
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
