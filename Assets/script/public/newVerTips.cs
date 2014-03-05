using UnityEngine;
using System.Collections;

public class newVerTips : MonoBehaviour {
    //-----------------------------------------------------------------
    //                      网络公告功能
    //-----------------------------------------------------------------
	// Use this for initialization
    public string url = "";             //连接到游戏版本路径
    public int N;                       //更新按钮跳转的场景
    bool changeSecne = false;           //是否切换画面判定
    //返回主界面
    void OnGUI()
    {
        //如果有新版本则会有按钮提示
        if (GUI.Button(new Rect(Screen.width/2 - 50, Screen.height - 40, 100, 30), "返回"))
        {
            changeSecne = true;
        }
    }
    //-----------------------------------------------------------------
    //                      联网参数
    //-----------------------------------------------------------------
    IEnumerator Start()
    {
        //联网并返回数值
        WWW www = new WWW(url);
        yield return www;
        guiText.text = www.text;
    }
    //-----------------------------------------------------------------
    //                     场景切换
    //-----------------------------------------------------------------
    void Update()
    {
        //切换场景功能
        if (changeSecne)
            StartCoroutine(changeSence());
    }
    //-----------------------------------------------------------------
    //                      切换新场景
    //-----------------------------------------------------------------
    IEnumerator changeSence()
    {
        Camera.main.SendMessage("fadeOut"); //发送黑屏信息
        yield return new WaitForSeconds(2);
        Application.LoadLevel(N);           //加载对应的场景
    }
}
