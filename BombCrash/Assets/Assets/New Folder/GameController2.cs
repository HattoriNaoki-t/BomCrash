﻿using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;






public class GameController2 : MonoBehaviour
{

    public Button[] stopbt;

    public Button playbt;


    public GameObject[] reels;

    ReelController[] rc = new ReelController[3];

    public GameObject gamemanager;


    //当たりの判定を取る
    bool hit_flag = false;

    //プレイヤー最初のターン
    int player_turn = 1;

    //ビッグorレギュラー
    bool big_flag = false;

    //レギュラーを当てたか
    bool player1_right = false;
    bool player2_right = false;
    private GameObject MainCam;
    private GameObject SubCam;

    //エフェクトのオブジェクト
    GameObject[] Box = new GameObject[4];
    GameObject[] Blue_button = new GameObject[3];
    GameObject[] Red_button = new GameObject[3];
    GameObject Small_hit;
    GameObject Back_Revolution;

    //サウンド
    public AudioClip big_Regular;
    public AudioClip regular;
    public AudioClip smallhitSound;

    private AudioSource[] sound;

    //出すエフェクト
    ParticleSystem[] boxEffect = new ParticleSystem[4];
    ParticleSystem[] button_EffectB = new ParticleSystem[3];
    ParticleSystem[] button_EffectR = new ParticleSystem[3];
    ParticleSystem small_hit;
    ParticleSystem back_revolution;

    int[] lineL, lineC, lineR;

    int stopline_len = 3;

    State state = State.Start;

    private int turn;

    // Use this for initialization

    void Start()
    {

        for (int i = 0; i < 3; i++)
        {

            rc[i] = reels[i].GetComponent<ReelController>();

        }
        //カメラ
        MainCam = GameObject.Find("Main Camera");
        SubCam = GameObject.Find("SubCamera2");
        //追加文/////////////////////////////////
        ///////////////////////////エフェクト///////////////////////////////////
        ////////////当たった時(スロットの上にランダムで表示させる物)////////////
        Box[0] = GameObject.Find("box");
        boxEffect[0] = Box[0].gameObject.GetComponent<ParticleSystem>();
        boxEffect[0].Stop();

        Box[1] = GameObject.Find("box1");
        boxEffect[1] = Box[1].gameObject.GetComponent<ParticleSystem>();
        boxEffect[1].Stop();

        Box[2] = GameObject.Find("box2");
        boxEffect[2] = Box[2].gameObject.GetComponent<ParticleSystem>();
        boxEffect[2].Stop();

        Box[3] = GameObject.Find("box3");
        boxEffect[3] = Box[3].gameObject.GetComponent<ParticleSystem>();
        boxEffect[3].Stop();
        ////////////////////////ボタン(青)////////////////////////////////////
        Blue_button[0] = GameObject.Find("Blue button");
        button_EffectB[0] = Blue_button[0].gameObject.GetComponent<ParticleSystem>();

        Blue_button[1] = GameObject.Find("Blue button2");
        button_EffectB[1] = Blue_button[1].gameObject.GetComponent<ParticleSystem>();

        Blue_button[2] = GameObject.Find("Blue button3");
        button_EffectB[2] = Blue_button[2].gameObject.GetComponent<ParticleSystem>();
        ////////////////////////ボタン(赤)//////////////////////////////////
        Red_button[0] = GameObject.Find("Red button");
        button_EffectR[0] = Red_button[0].gameObject.GetComponent<ParticleSystem>();
        button_EffectR[0].Stop();

        Red_button[1] = GameObject.Find("Red button2");
        button_EffectR[1] = Red_button[1].gameObject.GetComponent<ParticleSystem>();
        button_EffectR[1].Stop();

        Red_button[2] = GameObject.Find("Red button3");
        button_EffectR[2] = Red_button[2].gameObject.GetComponent<ParticleSystem>();
        button_EffectR[2].Stop();
        //当たった(リールの上)
        Small_hit = GameObject.Find("Small hit");
        small_hit = Small_hit.gameObject.GetComponent<ParticleSystem>();
        small_hit.Stop();

        //レギュラー
        Back_Revolution = GameObject.Find("Back Revolution");
        back_revolution = Back_Revolution.gameObject.GetComponent<ParticleSystem>();
        back_revolution.Stop();

        sound = gameObject.GetComponents<AudioSource>();


    }



    // Update is called once per frame

    void Update()
    {

        turn = gamemanager.GetComponent<GameManager>().getTurn();

        //レギュラー中かレギュラー終了の判定
        if (state == State.Init)
        {
            //自分がレギュラー中である
            Effect_Big();
            //自分がレギュラー中ではない
            Effect_Check();

            state = State.Start;
        }

        if (stopline_len == 3 && state == State.Playing)
        {


            state = State.Stay;

            Chack();
            //爆弾一個追加
            gamemanager.GetComponent<GameManager>().AddBom();
            //プレイヤー交代
            CheageTurn();
            playbt.interactable = true;

        }


        if(state==State.Start)
        {
            /////////////////////////////////////////////////////////////////
            if (SubCam.active == true)
            {
                if (turn == 1)
                {
                    if (Input.GetAxisRaw("joy1 Y") < 0)
                    {
                        //レギュラー判定(相手ターン時)
                        Effect_Check();

                        //ボタン
                        Button_Effect();
                        //上に傾いている
                        playbt.interactable = false;

                        stopline_len = 0;

                        state = State.Playing;

                        for (int i = 0; i < 3; i++)
                        {

                            rc[i].Reel_Move();

                            stopbt[i].interactable = true;
                        }
                    }
                    else if (0 < Input.GetAxisRaw("joy1 Y"))
                    {//レギュラー判定(相手ターン時)
                        Effect_Check();
                        //ボタン
                        Button_Effect();
                        //下に傾いている
                        playbt.interactable = false;

                        stopline_len = 0;

                        state = State.Playing;

                        for (int i = 0; i < 3; i++)
                        {

                            rc[i].Reel_Move();

                            stopbt[i].interactable = true;

                        }
                    }
                }

                if (turn == 2)
                {
                    if (Input.GetAxisRaw("joy2 Y") < 0)
                    {
                        //レギュラー判定(相手ターン時)
                        Effect_Check();

                        //ボタン
                        Button_Effect();
                        //上に傾いている
                        playbt.interactable = false;

                        stopline_len = 0;

                        state = State.Playing;

                        for (int i = 0; i < 3; i++)
                        {

                            rc[i].Reel_Move();

                            stopbt[i].interactable = true;
                        }
                    }
                    else if (0 < Input.GetAxisRaw("joy2 Y"))
                    {//レギュラー判定(相手ターン時)
                        Effect_Check();
                        //ボタン
                        Button_Effect();
                        //下に傾いている
                        playbt.interactable = false;

                        stopline_len = 0;

                        state = State.Playing;

                        for (int i = 0; i < 3; i++)
                        {

                            rc[i].Reel_Move();

                            stopbt[i].interactable = true;

                        }
                    }
                }
            }

            /////////////////////////

        }


    }



    public void Play()
    {

        //レギュラー判定(相手ターン時)
        Effect_Check();

        //ボタン
        Button_Effect();

        playbt.interactable = false;

        stopline_len = 0;

        state = State.Playing;

        for (int i = 0; i < 3; i++)
        {

            rc[i].Reel_Move();

            stopbt[i].interactable = true;

        }
        ////////////////////////////////////////////////////////////////////

    }





    public void Stopbt_f(int id)
    {

       

        stopbt[id].interactable = false;
        //エフェクトを変える(青)
        button_EffectB[id].Stop();
        //エフェクトを変える(赤)
        button_EffectR[id].Play();
    }

    public void Effect_Check()
    {
        //プレイヤー1のターン
        if (player_turn == 1)
        {
            //プレイヤー1のレギュラーではない
            if (player1_right == false)
            {
                back_revolution.Stop();
            }
        }

        //プレイヤー2のターン
        else if (player_turn == 2)
        {
            //プレイヤー2のレギュラーではない
            if (player2_right == false)
            {
                back_revolution.Stop();
            }
        }
    }

    //ボタンの色を変える(再び回す時)
    public void Button_Effect()
    {
        for (int i = 0; i < 3; i++)
        {
            //エフェクトを変える(青)
            button_EffectB[i].Play();
            //エフェクトを変える(赤)
            button_EffectR[i].Stop();
        }
    }



    public void SetLineL(int[] line)
    {

        lineL = new int[3];

        lineL = line;

        stopline_len++;

    }

    public void SetLineC(int[] line)
    {

        lineC = new int[3];

        lineC = line;

        stopline_len++;

    }

    public void SetLineR(int[] line)
    {

        lineR = new int[3];

        lineR = line;

        stopline_len++;

    }


    ///////図柄ぞろい
    void ATR(int G)
    {
        ///////図柄ぞろい
        switch (G)
        {

            case 0:

                Debug.Log("7揃ったぞ");
                //追加文///////////////
                back_revolution.Play();
                sound[0].Play();
                big_flag = true;
                //////////////////////////
                gamemanager.GetComponent<GameManager>().Seven();

                break;

            case 1:

                Debug.Log("BARが揃った");
                //追加文/////////////////////////////
                back_revolution.Play();
                sound[1].Play();
                big_flag = true;
                /////////////////////////////////////
                gamemanager.GetComponent<GameManager>().Bar();

                break;

            case 2:

                //追加文//////////////
                small_hit.Play();
                /////////////////////
                Debug.Log("爆弾が揃った");
                sound[2].Play();

                gamemanager.GetComponent<GameManager>().AddBom();

                break;

            case 3:

                Debug.Log("チェリーが揃った");
                small_hit.Play();
                break;

            case 4:

                //追加文/////////////////////////////
                small_hit.Play();
                /////////////////////////////////////
                Debug.Log("ハートが揃った");
                sound[2].Play();

                gamemanager.GetComponent<GameManager>().AddHp();
                break;

            case 5:

                //追加文/////////////////////////////////////
                small_hit.Play();
                ///追加文終了////////////////////////////////
                Debug.Log("ゾウさんが揃った");
                sound[2].Play();

                gamemanager.GetComponent<GameManager>().AddWarp();

                break;

            default:

                Debug.Log("???????");

                break;

        }

        
    }



    public void Chack()
    {
        //斜めに揃ったときの判定
        state = State.Start;

        for (int i = 0; i < 3; i++)
        {

            if (lineL[i] == lineC[i] && lineC[i] == lineR[i])
            {
                ATR(lineL[i]); Effct_C();
            }

        }

        if (lineL[0] == lineC[1] && lineC[1] == lineR[2])
        {
            ATR(lineL[0]); Effct_C();
        }

        if (lineL[2] == lineC[1] && lineC[1] == lineR[0])
        {

            ATR(lineL[2]); Effct_C();
        }
        //当たりか外れでカメラ切り替えの時間変更
        ////当たり
        if (hit_flag == true)
        {
            //3秒
            StartCoroutine("CheageCameraTime");
        }

        ////外れ
        else
        {
            //1秒
            StartCoroutine("CheageCameraTime2");
        }
    }
    void Effct_C()
    {
        //スロットの上に出すエフェクト(ランダム)
        int rand = Random.Range(0, 4);
        boxEffect[rand].Play();
        //当たり
        hit_flag = true;
    }

    //当たった時のカメラ切り替え停止(3秒 コルーチン)
    private IEnumerator CheageCameraTime()
    {
        //当たりフラグを戻す
        hit_flag = false;

        //カメラ切り替えの一時中断(画面に関係している処理は動く)
        yield return new WaitForSeconds(3.0f);

        //カメラ切り替えの処理
        CheageCamera();
    }

    //外れた時のカメラ切り替え停止(1秒 コルーチン)
    private IEnumerator CheageCameraTime2()
    {
        //カメラ切り替えの一時中断(画面に関係している処理は動く)
        yield return new WaitForSeconds(1.0f);

        //カメラ切り替えの処理
        CheageCamera();
    }

    //カメラ切り替えの処理
    public void CheageCamera()
    {
        //メインカメラを表示している時
        if (MainCam.activeSelf)
        {
            MainCam.SetActive(false);
            SubCam.SetActive(true);
            state = State.Init;
        }

        //サブ(スロット)カメラを表示している時
        else
        {
            MainCam.SetActive(true);
            SubCam.SetActive(false);
            state = State.Init;
        }
    }

    //ターンチェンジ
    void CheageTurn()
    {
        //プレイヤー1
        if (player_turn == 1)
        {
            if (big_flag == true)
            {
                big_flag = false;
                back_revolution.Stop();
            }
            Debug.Log("Player2に交代");
            player_turn = 2;
        }

        //プレイヤー2
        else
        {
            if (big_flag == true)
            {
                big_flag = false;
                back_revolution.Stop();
            }
            Debug.Log("Player1に交代");
            player_turn = 1;
        }
    }

    //レギュラー終了orレギュラー中判定
    void Effect_Big()
    {
        //プレイヤー1のターン
        if (player_turn == 1)
        {

            //プレイヤー1のレギュラー入っているか
            if (player1_right == true)
            {
                player1_right = false;
            }

        }
        //プレイヤー2のターン
        else if (player_turn == 2)
        {

            //プレイヤー2のレギュラー入っているか
            if (player2_right == true)
            {
                player2_right = false;
            }

        }
    }

}