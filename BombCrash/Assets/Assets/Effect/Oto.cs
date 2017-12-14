using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oto : MonoBehaviour {
    //使用する効果音
    public AudioClip bakuhatu;

    //
    private AudioSource effectall;

	// Use this for initialization
	void Start () {
        effectall = gameObject.GetComponent<AudioSource>();
        effectall.clip = bakuhatu;
        
    }
	
	// Update is called once per frame
	void Update () {
        //if文の中は当たり判定を書いて
		if(Input.GetKey(KeyCode.P))
        {
            //再生
            effectall.Play();
        }
	}
}
