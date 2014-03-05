using UnityEngine;
using System.Collections;
//-----------------------------------------------------------------
//  用于START按钮不断的闪烁功能
//-----------------------------------------------------------------
public class startTip : MonoBehaviour {
    SpriteRenderer r;                   //定义
    bool enable = true;                 //闪烁状态控制，true是消失
    float nextTime = 0.0f;              //下次时间计时
    public float shakeSpeed = 0.5f;     //频率，可手动修改
	// Use this for initialization
	void Start () 
    {
        r = gameObject.GetComponent<SpriteRenderer>();   //绑定到SpriteRenderer上
	}

	// Update is called once per frame
	void Update () 
    {
        change();                           //调用状态改变器
        //---------------------------------------------------------
        //  设置2个状态，一个是消失一个是全亮，之后用时间控制
        //---------------------------------------------------------
        if (enable)
        {
            r.color = new Color(0f, 0f, 0f, 0f);
        }
        else
        {
            r.color = new Color(1f, 1f, 1f, 1f);
        }
    }
    //-------------------------------------------------------------
    //  状态改变控制
    //-------------------------------------------------------------
    void change()
    {
        //时间频率控制器，不要随意修改
        if (Time.time > nextTime)
        {
            nextTime = Time.time + shakeSpeed;
            //-----------------------------------------------------
            //  下面是每次可执行的脚本
            //-----------------------------------------------------
            //判定enable的状态并切换
            if (enable)
                enable = false;
            else
                enable = true;
        }
    }
}
