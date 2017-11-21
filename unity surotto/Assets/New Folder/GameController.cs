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



    // Use this for initialization

    void Start()
    {

        for (int i = 0; i < 3; i++)
        {

            rc[i] = reels[i].GetComponent<ReelController>();

        }



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




    }



    public void Play()
    {  
        //Playボタンを押した時の動作
        if (Input.GetKeyDown(stop))
        {
            playbt.interactable = false;

            stopline_len = 0;

            state = State.Playing;

            for (int i = 0; i < 3; i++)
            {

                rc[i].Reel_Move();

                stopbt[i].interactable = true;

            }

        }

        playbt.interactable = false;

        stopline_len = 0;

        state = State.Playing;

        for (int i = 0; i < 3; i++)
        {

            rc[i].Reel_Move();

            stopbt[i].interactable = true;

        }

    }





    public void Stopbt_f(int id)
    {

        stopbt[id].interactable = false;

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

                break;

            case 1:

                Debug.Log("BARが揃った");

                break;

            case 2:

                Debug.Log("爆弾が揃った");

                break;

            case 3:

                Debug.Log("チェリーが揃った");
                break;

            case 4:

                Debug.Log("ハートが揃った");
                break;

            case 5:

                Debug.Log("ゾウさんが揃った");
                break;

            default:

                Debug.Log("???????");
                break;

        }
    }



    public void Chack()
    {

        for (int i = 0; i < 3; i++)
        {

            if (lineL[i] == lineC[i] && lineC[i] == lineR[i])
            {
                ATR(lineL[i]);
            }

        }



        if (lineL[0] == lineC[1] && lineC[1] == lineR[2])
        {
            ATR(lineL[0]);  
        }

        if (lineL[2] == lineC[1] && lineC[1] == lineR[0])
        {

            ATR(lineL[2]);
        }

    }

}