using UnityEngine;
using System.Collections;
//-----------------------------------------------------
//            各种按钮的脚本 按下后透明化
//-----------------------------------------------------
public class button : MonoBehaviour {
    SpriteRenderer r;                   //定义
    public int N;                       //设置加载的场景
    public AudioClip startSound;        //加载声音
    public bool VitCheck;                //检测体力（没有体力的时候不能点击
    bool touchCheck = false;            //判断是否点击，避免在屏幕切换前玩家不停的点击
    // Use this for initialization
    void Start()
    {
        r = gameObject.GetComponent<SpriteRenderer>();   //绑定到SpriteRenderer上
    }
    //当鼠标按下去后变色
    void OnMouseDown()
    {
        if (gameConfig.windows || gameConfig.web)
        {
            if (!touchCheck)
            {
                r.color = new Color(1f, 1f, 1f, 0.7f);
            }
        }
    }
    //当鼠标弹起后颜色恢复
    void OnMouseUp()
    {
        if (gameConfig.windows || gameConfig.web)
        {
            r.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    //当完成一次点击后
    void OnMouseUpAsButton()
    {
        if (!touchCheck)
        { 
            if (VitCheck)
            {
                if (gameConfig.Vit > 0)
                    StartCoroutine(sencesCheck());       //加载等待动画类
            }
            else 
            {
                StartCoroutine(sencesCheck());       //加载等待动画类
            }
            touchCheck = true;                  //将点击检测设置为用户点击过
            
        }
    }
    //-----------------------------------------------------
    //            切换场景
    //-----------------------------------------------------
    IEnumerator sencesCheck()
    {
        audio.PlayOneShot(startSound);       //播放进入声音
        Camera.main.SendMessage("fadeOut"); //发送黑屏信息
        yield return new WaitForSeconds(0.4f);
        Application.LoadLevel(N);           //加载对应的场景
    }
}