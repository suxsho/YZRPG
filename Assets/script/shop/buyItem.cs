using UnityEngine;
using System.Collections;
//-----------------------------------------------------------------
//                    购买商品
//-----------------------------------------------------------------
public class buyItem : MonoBehaviour {
    float y = 100.0f;
    public bool mouseDrag = false;
	// Use this for initialization
	void Start () {
	
	}
    //-----------------------------------------------------------------
    //                   GUI部分
    //-----------------------------------------------------------------
    void OnGUI()
    {
        if(mouseDrag)
        {
            Event e = Event.current;
            y = e.mousePosition.y;
        }
        //一个窗口组合
        GUI.BeginGroup(new Rect(0, y, 550, 50));
        GUI.Box(new Rect(0, 0, 550, 25), "一万金币购买武器测试之剑，攻击力+200（注意：本版本刷新或下线后武器需要重新购买）");
        GUI.EndGroup();
    }
	// Update is called once per frame
	void Update () {
	
	}
    //-----------------------------------------------------------------
    //                  拖动鼠标实现的内容
    //-----------------------------------------------------------------
    void OnMouseDown ()
    {
        mouseDrag = true;
    }
}
