using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {

    /// <summary>
    /// エフェクト
    /// </summary>

    //置き換えするパーティクル
    GameObject ob;
    GameObject ob2;
    GameObject ob3;
    GameObject ob4;

    //使うパーティクルの変数
    ParticleSystem baku;
    ParticleSystem botton;
    ParticleSystem botton2;
    ParticleSystem big;
    ParticleSystem reg;

    ///
    /// 音
    /// </summary>

    //使用する効果音
    public AudioClip bakuhatu;
    public AudioClip daibakuhatu;
    public AudioClip botton_oto;
    public AudioClip rebar;
    public AudioClip bigbouns;
    public AudioClip regular;

    //置き換えする音の宣言
    private AudioSource[] effectall;

    // Use this for initialization
    void Start () {
        //パーティクルの定義
        ob = GameObject.Find("bakuhatu");
        baku = ob.GetComponent<ParticleSystem>();
        baku.Stop();

        ob2 = GameObject.Find("botan");
        botton = ob2.GetComponent<ParticleSystem>();
        botton.Stop();

        ob3 = GameObject.Find("botan2");
        botton2 = ob3.GetComponent<ParticleSystem>();
        botton2.Stop();

        ob4 = GameObject.Find("big");
        big = ob4.GetComponent<ParticleSystem>();
        big.Stop();

        //音の定義
        effectall = gameObject.GetComponents<AudioSource>();
        effectall[0].clip = bakuhatu;
        effectall[1].clip =daibakuhatu;
        effectall[2].clip = botton_oto;
        effectall[3].clip = rebar;
        effectall[4].clip = bigbouns;
        effectall[5].clip = regular;

        //最初は音を出さない
        effectall[0].Stop();
        effectall[1].Stop();
        effectall[2].Stop();
        effectall[3].Stop();
        effectall[4].Stop();
        effectall[5].Stop();
    }
	
	// Update is called once per frame
	void Update () {
        ////爆弾を落とす
        /*本来の処理は当たり判定(プレイヤーとの当たり判定
        かフィールドとの当たり判定)をif文の中に書く*/
        if (Input.GetKey(KeyCode.P))
        {
            //再生
            effectall[0].Play();
            baku.Play();
        }

        /*本来の処理は(プレイヤーとの当たり判定
        かフィールドとの当たり判定)＋レギュラーボーナス中のみをif文に書く*/
        if(Input.GetKey(KeyCode.L))
        {
            //再生及び表示
            effectall[1].Play();
            baku.Play();
        }

        //実際のボタンを押されたら
        if (Input.GetKey(KeyCode.A))
        {
            //再生及び表示
            effectall[2].Play();
            botton.Play();
            botton2.Stop();
        }

        //実際のレバーのキー
        if(Input.GetKey(KeyCode.D))
        {
            //再生及び表示
            effectall[3].Play();
            botton.Stop();
            botton2.Play();
        }

        //ビッグボーナスに突入したら
        if(Input.GetKeyDown(KeyCode.W))
        {
            //再生及び表示
            effectall[4].Play();
            big.Play();
        }

        if(Input.GetKey(KeyCode.S))
        {
            //再生及び表示
            effectall[5].Play();
        }
    }
}
