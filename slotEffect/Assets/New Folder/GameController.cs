using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;



enum State
{

    Start,

    Playing,

    Stay,

}



public class GameController : MonoBehaviour
{

    public Button[] stopbt;

    public Button playbt;

    public KeyCode stop;

    public GameObject[] reels;

    ReelController[] rc = new ReelController[3];



    int[] lineL, lineC, lineR;

    int stopline_len = 3;

    State state = State.Start;

    //エフェクト
    GameObject[] Box = new GameObject[4];
    GameObject[] Blue_button = new GameObject[3];
    GameObject[] Red_button = new GameObject[3];
    GameObject Big_Regular;
    GameObject Regular;
    GameObject Small_hit;
    GameObject Back_Revolution;

    //出すエフェクト
    ParticleSystem[] boxEffect = new ParticleSystem[4];
    ParticleSystem[] button_EffectB = new ParticleSystem[3];
    ParticleSystem[] button_EffectR = new ParticleSystem[3];
    ParticleSystem big_regular;
    ParticleSystem regular;
    ParticleSystem small_hit;
    ParticleSystem back_revolution;


    // Use this for initialization

    void Start()
    {

        for (int i = 0; i < 3; i++)
        {

            rc[i] = reels[i].GetComponent<ReelController>();

        }

        ///////////////////////////エフェクト///////////////////////////////////
        //当たった時(スロットの上に表示)
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

        //ボタン(青)
        Blue_button[0] = GameObject.Find("Blue button");
        button_EffectB[0] = Blue_button[0].gameObject.GetComponent<ParticleSystem>();

        Blue_button[1] = GameObject.Find("Blue button2");
        button_EffectB[1] = Blue_button[1].gameObject.GetComponent<ParticleSystem>();

        Blue_button[2] = GameObject.Find("Blue button3");
        button_EffectB[2] = Blue_button[2].gameObject.GetComponent<ParticleSystem>();

        //ボタン(赤)
        Red_button[0] = GameObject.Find("Red button");
        button_EffectR[0] = Red_button[0].gameObject.GetComponent<ParticleSystem>();
        button_EffectR[0].Stop();

        Red_button[1] = GameObject.Find("Red button2");
        button_EffectR[1] = Red_button[1].gameObject.GetComponent<ParticleSystem>();
        button_EffectR[1].Stop();

        Red_button[2] = GameObject.Find("Red button3");
        button_EffectR[2] = Red_button[2].gameObject.GetComponent<ParticleSystem>();
        button_EffectR[2].Stop();

        //レギュラー
        Regular = GameObject.Find("Regular");
        regular = Regular.gameObject.GetComponent<ParticleSystem>();
        regular.Stop();

        //ビッグボーナス
        Big_Regular = GameObject.Find("Big Regular");
        big_regular = Big_Regular.gameObject.GetComponent<ParticleSystem>();
        big_regular.Stop();

        //当たった(リールの上)
        Small_hit = GameObject.Find("Small hit");
        small_hit = Small_hit.gameObject.GetComponent<ParticleSystem>();
        small_hit.Stop();

        //レギュラー時(ビッグ及びレギュラー時)
        Back_Revolution = GameObject.Find("Back Revolution");
        back_revolution = Back_Revolution.gameObject.GetComponent<ParticleSystem>();
        back_revolution.Stop();
        //////////////////////////////////////////////////////////////////////
    }



    // Update is called once per frame

    void Update()
    {
        if (stopline_len == 3 && state == State.Playing)
        {
            state = State.Stay;

            Chack();

            playbt.interactable = true;
        }

        if (Input.GetKeyDown(stop))
        {
            playbt.interactable = false;

            stopline_len = 0;

            state = State.Playing;

            //エフェクトを変える(青)
            button_EffectB[0].Play();
            button_EffectB[1].Play();
            button_EffectB[2].Play();

            button_EffectR[0].Stop();
            button_EffectR[1].Stop();
            button_EffectR[2].Stop();

            for (int i = 0; i < 3; i++)
            {
                rc[i].Reel_Move();

                stopbt[i].interactable = true;
            }

        }

    }

    public void Play()
    {
        //Playボタンを押した時の動作
        playbt.interactable = false;

        stopline_len = 0;

        state = State.Playing;

        //エフェクトを変える(青)
        button_EffectB[0].Play();
        button_EffectB[1].Play();
        button_EffectB[2].Play();

        button_EffectR[0].Stop();
        button_EffectR[1].Stop();
        button_EffectR[2].Stop();

        for (int i = 0; i < 3; i++)
        {
            rc[i].Reel_Move();

            stopbt[i].interactable = true;
        }

    }

    public void Stopbt_f(int id)
    {
        stopbt[id].interactable = false;

        //エフェクトを変える(赤)
        button_EffectB[id].Stop();
      
        button_EffectR[id].Play();
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

    public void Chack()
    {
        for (int i = 0; i < 3; i++)
        {
            if (lineL[i] == lineC[i] && lineC[i] == lineR[i])
            {
                //エフェクトをランダムで選出
                int rand = Random.Range(0, 4);
                boxEffect[rand].Play();
                small_hit.Play();

                switch (i)
                {
                    case 0:
                        Debug.Log("一番下のラインが揃ったよ。");
                        break;

                    case 1:
                        Debug.Log("真ん中のラインが揃ったよ。");
                        break;

                    case 2:
                        Debug.Log("一番上のラインが揃ったよ。");
                        break;

                    default:
                        Debug.Log("設定ミスでは???");
                        break;
                }

            }

        }

        if (lineL[0] == lineC[1] && lineC[1] == lineR[2])
        {
            //エフェクトをランダムで選出
            int rand = Random.Range(0, 4);
            boxEffect[rand].Play();
            small_hit.Play();

            Debug.Log("ラインの左下がりが揃ったよ。");
        }

        if (lineL[2] == lineC[1] && lineC[1] == lineR[0])
        {
            //エフェクトをランダムで選出
            int rand = Random.Range(0, 4);
            boxEffect[rand].Play();
            small_hit.Play();
            Debug.Log("ラインの右上がりが揃ったよ。");
        }


    }
}