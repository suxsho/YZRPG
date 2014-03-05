using UnityEngine;
using System.Collections;
//-----------------------------------------------------------------
//                      用于LOGO的切换功能
//-----------------------------------------------------------------
public class logo : MonoBehaviour {
    public int N;                  //设定跳转的场景
    public int S;                  //设定等待的秒
	// Update is called once per frame
	void Update () 
    {
        //按H键后可跳过LOGO加载
        if (Input.GetKey("h"))
            Application.LoadLevel(N);
        //加载等待动画类
        StartCoroutine(loadLogo());
	}
//-----------------------------------------------------------------
//                      等待动画功能
//-----------------------------------------------------------------
    IEnumerator loadLogo()
    {
        yield return new WaitForSeconds(S);
        Camera.main.SendMessage("fadeOut"); //发送黑屏信息
        yield return new WaitForSeconds(2);
        Application.LoadLevel(N);           //加载对应的场景
    }
}
