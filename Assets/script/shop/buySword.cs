using UnityEngine;
using System.Collections;
//-----------------------------------------------------
//                      睡觉功能
//-----------------------------------------------------
public class buySword : MonoBehaviour
{
    SpriteRenderer r;                   //定义
    public AudioClip startSound;        //加载声音
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
            if (gameConfig.money - 10000 >= 0)
            {
                battleUI.buySword = true;                    //买武器开启
                gameConfig.money -= 10000;                    //扣钱
                PlayerPrefs.SetInt("money", gameConfig.money);  //存档
                audio.PlayOneShot(startSound);       //播放进入声音
            }

        }
    }

}