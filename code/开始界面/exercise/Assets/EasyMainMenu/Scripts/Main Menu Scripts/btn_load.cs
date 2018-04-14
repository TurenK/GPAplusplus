using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_load : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUp()                 //鼠标点击时调用，触发按钮事件

    {
        Invoke("Jump", 0.5F);       //0.5秒，调用jump方法
    }

    void Jump()

    {

        Application.LoadLevel("load");//“loading”是所要跳转的目标场景名称

    }

}
