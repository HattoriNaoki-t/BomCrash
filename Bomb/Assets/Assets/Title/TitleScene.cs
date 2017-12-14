using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour {

    public TitleScene button;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        if(button==null)
        {
            throw new System.Exception("Button instance is null!!");
        }

        button.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string objectname)
    {
        Debug.Log("Base Button");
    }
}
