using UnityEngine;
using System.Collections;

public class verValue : MonoBehaviour {
    //-----------------------------------------------------------------
    //  通过配置计算版本
    //-----------------------------------------------------------------
    float ver;                  //获取版本以及计算
	// Use this for initialization
	void Start () 
    {
        ver = gameConfig.ver;
        ver /= 100;
        guiText.text = "Ver " + ver;
	}
	
}
