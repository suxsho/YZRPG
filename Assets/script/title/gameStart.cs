using UnityEngine;
using System.Collections;
//-----------------------------------------------------------------
//                      用于进入游戏
//-----------------------------------------------------------------
public class gameStart : MonoBehaviour {
    public int N;       //设置加载的场景
    public AudioClip startSound;
    bool touchCheck = false;            //判断是否点击，避免在屏幕切换前玩家不停的点击
    //当完成一次点击后
    void OnMouseUpAsButton()
    {
        if (gameConfig.windows || gameConfig.web)
        {
            //print("you press the mouse");
            if (!touchCheck)
            {
                audio.PlayOneShot(startSound);       //播放进入声音
                StartCoroutine(sencesCheck());       //加载等待动画类
                touchCheck = true;                  //将点击检测设置为用户点击过
            }
        }
    }
    IEnumerator sencesCheck()
    {
        Camera.main.SendMessage("fadeOut"); //发送黑屏信息
        yield return new WaitForSeconds(1);
        Application.LoadLevel(N);           //加载对应的场景
    }
}
