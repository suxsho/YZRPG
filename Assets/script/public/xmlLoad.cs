using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
//-----------------------------------------------------------------
//  用于XML操控，上面添加XML需要使用的类
//-----------------------------------------------------------------
public class xmlLoad : MonoBehaviour {

	// Use this for initialization
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 30), "创建XML"))
        {
            createXml();
        }
        if (GUI.Button(new Rect(10, 50, 100, 30), "更新XML"))
        {
            UpdateXml();
        }
        if (GUI.Button(new Rect(10, 100, 100, 30), "读取XML"))
        {
            showXml();
        }
        if (GUI.Button(new Rect(10, 150, 100, 30), "XMLREADER读取"))
        {
            showXmlForXmlReader();
        }
    }
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    //-----------------------------------------------------------------
    //          生成XML
    //-----------------------------------------------------------------
    public void createXml()
    {
        string filepath = Application.dataPath + @"/my.xml";           //xml保存的路径，这里放在Assets路径 注意路径。
        //-----------------------------------------------------------------
        //          判断是否用XML文件
        //-----------------------------------------------------------------
        if (!File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();                   //创建XML文档实例
            XmlElement root = xmlDoc.CreateElement("transforms");    //创建root节点，也就是最上一层节点
            XmlElement elmNew = xmlDoc.CreateElement("rotation");     //继续创建下一层节点
            //-----------------------------------------------------------------
            //         设置2个属性ID和name
            //-----------------------------------------------------------------
            elmNew.SetAttribute("id", "0");
            elmNew.SetAttribute("name", "momo");
            XmlElement rotation_X = xmlDoc.CreateElement("x");      //继续创建下一层节点
            rotation_X.InnerText = "0";                             //设置节点中的数值
            XmlElement rotation_Y = xmlDoc.CreateElement("y");
            rotation_Y.InnerText = "1";
            XmlElement rotation_Z = xmlDoc.CreateElement("z");
            rotation_Z.InnerText = "2";
            rotation_Z.SetAttribute("id", "1");                      //这里在添加一个节点属性，用来区分。
            //-----------------------------------------------------------------
            //    把节点一层一层的添加至XMLDoc中 ，请仔细看它们之间的先后顺序
            //    这将是生成XML文件的顺序
            //-----------------------------------------------------------------
            elmNew.AppendChild(rotation_X);
            elmNew.AppendChild(rotation_Y);
            elmNew.AppendChild(rotation_Z);
            root.AppendChild(elmNew);
            xmlDoc.AppendChild(root);
            //-----------------------------------------------------------------
            //         把XML文件保存至本地
            //-----------------------------------------------------------------
            xmlDoc.Save(filepath);
            Debug.Log("createXml OK!");
        }
    }
    //-----------------------------------------------------------------
    //          修改XML
    //-----------------------------------------------------------------
    public void UpdateXml()
    {
        string filepath = Application.dataPath + @"/my.xml";
        if (File.Exists(filepath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filepath);                                                    //根据路径将XML读取出来
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("transforms").ChildNodes;  //得到transforms下的所有子节点 
            //遍历所有子节点
            foreach(XmlElement xe in nodeList)
            {
                //拿到节点中属性ID =0的节点
                if (xe.GetAttribute("id") == "0")
                {
                    //更新节点属性
                    xe.SetAttribute("id", "1000");
                    //继续遍历
                    foreach (XmlElement x1 in xe.ChildNodes)
                    {
                        if (x1.Name == "z")
                        {
                            x1.InnerText = "update00000";                             //这里是修改节点名称对应的数值，而上面的拿到节点连带的属性。。。
                        }
                    }
                    break;
                }
            }
            xmlDoc.Save(filepath);
            Debug.Log("UpdateXml OK!");
        }
    }
    //-----------------------------------------------------------------
    //          添加XML
    //-----------------------------------------------------------------
    public void AddXml()
    {
     string filepath = Application.dataPath + @"/my.xml";
         if(File.Exists (filepath))
             {
                 XmlDocument xmlDoc = new XmlDocument();
                 xmlDoc.Load(filepath);
                 XmlNode root = xmlDoc.SelectSingleNode("transforms");
                 XmlElement elmNew = xmlDoc.CreateElement("rotation");
                 elmNew.SetAttribute("id","1");
                 elmNew.SetAttribute("name","yusong");
                  XmlElement rotation_X = xmlDoc.CreateElement("x");
                  rotation_X.InnerText = "0";
                  rotation_X.SetAttribute("id","1");
                  XmlElement rotation_Y = xmlDoc.CreateElement("y");
                  rotation_Y.InnerText = "1";
                  XmlElement rotation_Z = xmlDoc.CreateElement("z");
                  rotation_Z.InnerText = "2";
                  elmNew.AppendChild(rotation_X);
                  elmNew.AppendChild(rotation_Y);
                  elmNew.AppendChild(rotation_Z);
                  root.AppendChild(elmNew);
                  xmlDoc.AppendChild(root);
                  xmlDoc.Save(filepath);
                  Debug.Log("AddXml OK!");
             }
    }
    //-----------------------------------------------------------------
    //          删除XML
    //----------------------------------------------------------------- 
    public void deleteXml()
    {
      string filepath = Application.dataPath + @"/my.xml";
      if(File.Exists (filepath))
      {
           XmlDocument xmlDoc = new XmlDocument();
           xmlDoc.Load(filepath);
           XmlNodeList nodeList=xmlDoc.SelectSingleNode("transforms").ChildNodes;
           foreach(XmlElement xe in nodeList)
           {
              if(xe.GetAttribute("id")=="1")
              {
                  xe.RemoveAttribute("id");
              }
              foreach(XmlElement x1 in xe.ChildNodes)
              {
                  if(x1.Name == "z")
                  {
                      x1.RemoveAll();
                  }
              }
           }
           xmlDoc.Save(filepath);
           Debug.Log("deleteXml OK!");
      }
    }
    //-----------------------------------------------------------------
    //          读取XML
    //----------------------------------------------------------------- 
    public void showXml()
    {
      string filepath = Application.dataPath + @"/my.xml";
      if(File.Exists (filepath))
      {
           XmlDocument xmlDoc = new XmlDocument();
           xmlDoc.Load(filepath);
           XmlNodeList nodeList=xmlDoc.SelectSingleNode("transforms").ChildNodes;
          //遍历每一个节点，拿节点的属性以及节点的内容
           foreach(XmlElement xe in nodeList)
           {
              Debug.Log("Attribute :" + xe.GetAttribute("name"));
              Debug.Log("NAME :" + xe.Name);
              foreach(XmlElement x1 in xe.ChildNodes)
              {
                  if(x1.Name == "y")
                  {
                      Debug.Log("VALUE :" + x1.InnerText);
                  }
              }
           }
           Debug.Log("all = " + xmlDoc.OuterXml);
      }
    }
    //-----------------------------------------------------------------
    //          用XmlReader获取信息
    //----------------------------------------------------------------- 
    public void showXmlForXmlReader()
    {
        string filepath = Application.dataPath + @"/my.xml";        //读取XML文件
        XmlReader xml_reader = XmlReader.Create(filepath);        //生成XML内容
        while (xml_reader.Read())
        {
            //获取当前节点的类型，如果当前读取的节点是文本类型就输出文本信息
            if (xml_reader.NodeType == XmlNodeType.Text)
            {
                Debug.Log(xml_reader.Value);
            }
        }

    }
}
