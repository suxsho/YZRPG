using UnityEngine;
using System.Collections;
//-----------------------------------------------------------------
//                     统计游戏被点开了多少次
//-----------------------------------------------------------------
public class userTotal : MonoBehaviour {
    public string urlOpen = "";             //连接到游戏版本路径
	// Use this for initialization
    IEnumerator Start()
    {
        if(gameConfig.windows)
        { 
                //统计打开游戏的次数
                WWW www = new WWW(urlOpen);
                yield return www;        
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
