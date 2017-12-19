using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //押されたら
		if(Input.GetKeyDown(KeyCode.Joystick1Button5))
        {
            //シーン移行
            SceneManager.LoadScene("Main");
            Debug.Log("ゲームスタート");
        }
	}
}
