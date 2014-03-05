using UnityEngine;
using System.Collections;
//-----------------------------------------------------------------
//                      通过网络获取版本
//-----------------------------------------------------------------
public class newVer : MonoBehaviour {
    public string url = "";             //连接到游戏版本路径
    public int tVcheck;                 //填写当前版本
    int nVcheck;                        //检测是否有新版本
    public int N;                       //更新按钮跳转的场景
    bool changeSecne = false;           //是否切换画面判定
    //-----------------------------------------------------------------
    //                      显示新版本功能按钮
    //-----------------------------------------------------------------
    void OnGUI()
    {
      //如果有新版本则会有按钮提示
        if (nVcheck > tVcheck && GUI.Button(new Rect(Screen.width - 110, Screen.height - 40, 100, 30), "新版本已发"))
        {
            changeSecne = true;
        }
    }
    //-----------------------------------------------------------------
    //                      联网参数
    //-----------------------------------------------------------------
    IEnumerator Start()
    {
        if (gameConfig.windows)
        {
            //联网并返回数值
            WWW www = new WWW(url);
            yield return www;
            nVcheck = int.Parse(www.text);
        }
        //对比版本并给出公告
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