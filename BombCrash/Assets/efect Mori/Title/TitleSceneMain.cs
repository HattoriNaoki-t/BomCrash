using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneMain : TitleScene {

    protected override void OnClick(string objectname)
    {
        if("Button".Equals(objectname))
        {
            this.ButtonClick();
        }

        else
        {
            throw new System.Exception("Not implemented!!");
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void ButtonClick()
    {
        //実際のシーンへ移動
        SceneManager.LoadScene("Main");
    } 
}
