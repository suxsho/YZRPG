using UnityEngine;
using System.Collections;
//-----------------------------------------------------
//            遮挡屏幕脚本，拖动其到摄像机
//-----------------------------------------------------
public class FadeInOut : MonoBehaviour {
    //定义各种参数
    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.3f;
    int drawDepth = -1000;
    //私有部分
    float alpha = 1.0f;
    int fadeDir = -1;
	// GUI
	void OnGUI() 
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        GUI.color = new Color(1f, 1f, 1f, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
	}
    //淡入模式
    void fadeIn()
    {
        fadeDir = -2; 
    }
    //淡出模式
    void fadeOut()
    {
        fadeDir = 2;
    }
    void Start() 
    {
        alpha = 2;
        fadeIn();
    }
}
