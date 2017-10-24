using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakudan : MonoBehaviour {

    GameObject ob;

    ParticleSystem baku;

    //使用する効果音
    public AudioClip bakuhatu;

    //置き換えする音の宣言
    private AudioSource effectall;

    // Use this for initialization
    void Start () {
        //パーティクルの定義
        ob = GameObject.Find("bakuhatu");
        baku = ob.GetComponent<ParticleSystem>();
        baku.Stop();

        //
        effectall = gameObject.GetComponent<AudioSource>();
        effectall.clip = bakuhatu;

        //最初は音を出さない
        effectall.Stop();

    }
	
	// Update is called once per frame
	void Update () {
        ////爆弾を落とす
        /*本来の処理は当たり判定(プレイヤーとの当たり判定
        かフィールドとの当たり判定)をif文の中に書く*/
        if (Input.GetKey(KeyCode.P))
        {
            //再生
            effectall.Play();
            baku.Play();
        }
    }
}
