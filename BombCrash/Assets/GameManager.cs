﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

    public GameObject bom;
    public GameObject bom2;

    public KeyCode DecideButton;

    public KeyCode DecideButton2;

    public GameObject Player;

    public GameObject Player2;

    public static  int turn = 0;

    public GameObject Warp;

    public GameObject Warp2;


    public GameObject[] Player1ItemView;
    public GameObject[] Player2ItemView2;

    public GameObject TurnWindow;


    
    private bool FirstSetFlag;
    private bool SecondSetFlag;

    private bool insflag;
    private bool useItemFlag;
    private bool useItemFlag2;

    private bool insflag3;
    private bool insflag4;
    private bool insflag5;


    private bool UseBom;
    private bool UseWarp;

    public int player1_Bom = 3;
    public int player2_Bom = 3;
    public int player1_Warp = 1;
    public int player2_Warp = 1;

    public int player1_Hp = 2;
    public int player2_Hp = 2;

    public GameObject seven;
    public GameObject bar;
    public GameObject seven2;
    public GameObject bar2;

    private bool CursorFlag;


    private GameObject MainCam;
    private GameObject MainCam2;
    private GameObject SubCam;
    private GameObject SubCam2;



    public int selectNumber1;
    public int selectNumber2;

    private bool afterBomUseFlag;
    private bool afterWarpUseFlag;


    public GameObject[] playerhpSprite;


    // Use this for initialization
    void Start () {



        if (Display.displays.Length > 1)
            Display.displays[1].Activate();
        if (Display.displays.Length > 2)
            Display.displays[2].Activate();


        Player = Instantiate(Player);

        for(int i = 0; i < 4; i++)
        {
            Instantiate(playerhpSprite[i]);
        }
        for(int i = 0; i < Player1ItemView.Length; i++) {
            Player1ItemView[i].SetActive(false);
            Player2ItemView2[i].SetActive(false);


        }

        MainCam = GameObject.Find("Main Camera");
        MainCam2 = GameObject.Find("Main Camera2");

        SubCam = GameObject.Find("SubCamera");
        SubCam2 = GameObject.Find("SubCamera2");


        SubCam.SetActive(false);


    }

    // Update is called once per frame
    void Update () {
        FirstSetFlag = Player.GetComponent<CharMove>().GetFlag();
        SecondSetFlag = Player2.GetComponent<CharMove2>().GetFlag();

        //if (Input.anyKeyDown)
        //{
        //    foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
        //    {
        //        if (Input.GetKeyDown(code))
        //        {
        //            //処理を書く
        //            Debug.Log(code);
        //            break;
        //        }
        //    }
        //}

        //Debug.Log(Input.GetAxisRaw("joy2 X"));
        
        //Debug.Log(selectNumber1);
        //Debug.Log(selectNumber2);

        if (FirstSetFlag&&SecondSetFlag&& MainCam.active == true && UseBom ==false&&UseWarp==false)
        {
            switch (selectNumber1)
            {
                case 0:
                    if (afterBomUseFlag)
                    {
                        Player1ItemView[0].GetComponent<Image>().color = new Color(1, 0.7f, 0.7f);
                    }
                    else
                    {
                        Player1ItemView[0].GetComponent<Image>().color = new Color(1, 1, 0.7f);
                    }
                    if (afterWarpUseFlag)
                    {
                        Player1ItemView[1].GetComponent<Image>().color = new Color(1, 0.7f, 0.7f);
                    }
                    else
                    {
                        Player1ItemView[1].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    }

                    Player1ItemView[2].GetComponent<Image>().color = new Color(1, 1, 1.0f);

                    if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetAxisRaw("joy1 Y") == 1&&CursorFlag ==false)
                    {
                        selectNumber1++;
                        CursorFlag = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(DecideButton))
                    {
                        BomButtonClick();

                    }
                    break;
                case 1:

                    if (afterBomUseFlag)
                    {
                        Player1ItemView[0].GetComponent<Image>().color = new Color(1, 0.7f, 0.7f);
                    }
                    else
                    {
                        Player1ItemView[0].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    }
                    if (afterWarpUseFlag)
                    {

                        Player1ItemView[1].GetComponent<Image>().color = new Color(1, 0.7f, 0.7f);
                    }
                    else
                    {
                        Player1ItemView[1].GetComponent<Image>().color = new Color(1, 1, 0.7f);

                    }
                    
                    Player1ItemView[2].GetComponent<Image>().color = new Color(1, 1, 1.0f);

                    if (Input.GetKeyDown(KeyCode.DownArrow) && FirstSetFlag || Input.GetAxisRaw("joy1 Y") == 1 && CursorFlag == false)
                    {
                        selectNumber1++;
                    }
                    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxisRaw("joy1 Y") == -1 && CursorFlag == false)
                    {
                        selectNumber1--;
                    }
                    if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(DecideButton))
                    {
                        WarpButtonClick();
                    }
                    break;
                case 2:
                    if (afterBomUseFlag)
                    {
                        Player1ItemView[0].GetComponent<Image>().color = new Color(1, 0.7f, 0.7f);
                    }
                    else
                    {
                        Player1ItemView[0].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    }
                    if (afterWarpUseFlag)
                    {

                        Player1ItemView[1].GetComponent<Image>().color = new Color(1, 0.7f, 0.7f);
                    }
                    else
                    {
                        Player1ItemView[1].GetComponent<Image>().color = new Color(1, 1, 1.0f);

                    }
                    Player1ItemView[2].GetComponent<Image>().color = new Color(1, 1, 0.7f);
                    if (Input.GetKeyDown(KeyCode.UpArrow) && FirstSetFlag || Input.GetAxisRaw("joy1 Y") == -1 && CursorFlag == false)
                    {
                        selectNumber1--;
                        CursorFlag = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(DecideButton) && CursorFlag == false)
                    {
                        changeTurn();
                    }
                    break;
            }
            switch (selectNumber2)
            {
                case 0:

                    Player2ItemView2[0].GetComponent<Image>().color = new Color(1, 1, 0.7f);
                    Player2ItemView2[1].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player2ItemView2[2].GetComponent<Image>().color = new Color(1, 1, 1.0f);

                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxisRaw("joy2 Y") == 1 && CursorFlag == false)
                    {
                        selectNumber2++;
                        CursorFlag = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(DecideButton2))
                    {
                        BomButtonClick();
                    }
                    break;
                case 1:

                    Player2ItemView2[0].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player2ItemView2[1].GetComponent<Image>().color = new Color(1, 1, 0.7f);
                    Player2ItemView2[2].GetComponent<Image>().color = new Color(1, 1, 1.0f);

                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxisRaw("joy2 Y") == 1 && CursorFlag == false)
                    {
                        selectNumber2++;
                        CursorFlag = true;
                    }
                    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxisRaw("joy2 Y") == -1 && CursorFlag == false)
                    {
                        selectNumber2--;
                        CursorFlag = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(DecideButton2))
                    {
                        WarpButtonClick();
                    }
                    break;
                case 2:

                    Player2ItemView2[0].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player2ItemView2[1].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player2ItemView2[2].GetComponent<Image>().color = new Color(1, 1, 0.7f);

                    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxisRaw("joy2 Y") == -1 && CursorFlag == false)
                    {
                        selectNumber2--;
                        CursorFlag = true;
                    }
                    if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(DecideButton2))
                    {
                        changeTurn();
                    }
                    break;
            }
        }
        if ((Input.GetAxisRaw("joy1 Y") == 0 && MainCam.active == true && turn ==1)|| (Input.GetAxisRaw("joy2 Y") == 0 && MainCam.active == true && turn == 2))
        {
            CursorFlag = false;
        }
        








        Player1ItemView[0].GetComponentInChildren<Text>().text = "爆弾 x " + player1_Bom.ToString();
        
        if (FirstSetFlag == true && SecondSetFlag == true&&insflag3 ==false)
        {
            turn = 1;

            insflag3 = true;
            if (MainCam.activeSelf)
            {
                MainCam.SetActive(false);
                SubCam.SetActive(true);
            }
            else
            {
                MainCam.SetActive(true);
                SubCam.SetActive(false);
            }
            if (MainCam2.activeSelf)
            {
                MainCam2.SetActive(false);
                SubCam2.SetActive(true);
            }
            else
            {
                MainCam2.SetActive(true);
                SubCam2.SetActive(false);
            }
        }


        //Debug.Log(turn);
        if (GameObject.FindGameObjectsWithTag("Bom").Length > 0)
        {
            UseBom = true;
            afterBomUseFlag = true;
        }
        else
        {
            UseBom = false;
        }
        if (GameObject.FindGameObjectsWithTag("Warp").Length > 0)
        {
            UseWarp = true;
            afterWarpUseFlag = true;
        }
        else
        {
            UseWarp = false;
        }


        //Debug.Log(turn);

        if (FirstSetFlag && insflag ==false)
        {
            Player2 = Instantiate(Player2, new Vector3(5, 1.5f, 0),Quaternion.identity);
            insflag = true;
        }


        if (turn == 1)
        {

            insflag4 = false;
            //Player.GetComponent<MeshRenderer>().material.color = new Color(Player.GetComponent<MeshRenderer>().material.color.r, Player.GetComponent<MeshRenderer>().material.color.g, Player.GetComponent<MeshRenderer>().material.color.b, 1.0f);

            for (int i = 0; i < Player1ItemView.Length; i++)
            {
                Player1ItemView[i].SetActive(true);
                Player2ItemView2[i].SetActive(false);

            }
            TurnWindow.GetComponent<Text>().text = "ターン:player1";
        }
        if (turn == 2)
        {
            insflag4 = false;
            //Player2.GetComponent<MeshRenderer>().material.color = new Color(Player2.GetComponent<MeshRenderer>().material.color.r, Player2.GetComponent<MeshRenderer>().material.color.g, Player2.GetComponent<MeshRenderer>().material.color.b, 1.0f);

            for (int i = 0; i < Player1ItemView.Length; i++)
            {
                Player1ItemView[i].SetActive(false);
                Player2ItemView2[i].SetActive(true);


            }
            TurnWindow.GetComponent<Text>().text = "ターン:player2";
        }

        if (UseBom==true||UseWarp==true)
        {
            Player1ItemView[2].SetActive(false);
            Player2ItemView2[2].SetActive(false);
        }
        
        

    }

    public void changeTurn()
    {
        if (FirstSetFlag == true && SecondSetFlag == true && insflag4 == false)
        {
            if (turn == 1)
            {
                turn = 2;
                selectNumber2 = 0;

            }
            else
            {
                turn = 1;
                selectNumber1 = 0;

            }
            insflag4 = true;
            selectNumber1 = 0;
            selectNumber2 = 0;
            UseBom = false;
            UseWarp = false;
            afterBomUseFlag = false;
            afterWarpUseFlag = false;
        }

        if (MainCam.activeSelf)
        {
            MainCam.SetActive(false);
            SubCam.SetActive(true);
        }
        else
        {
            MainCam.SetActive(true);
            SubCam.SetActive(false);
        }

        if (MainCam2.activeSelf)
        {
            MainCam2.SetActive(false);
            SubCam2.SetActive(true);
        }
        else
        {
            MainCam2.SetActive(true);
            SubCam2.SetActive(false);
        }

        useItemFlag = false;
        useItemFlag2 = false;

        //TurnChangeButton.SetActive(false);
    }
    public int getTurn()
    {
        return turn;
    }
    public void BomButtonClick()
    {
        //爆弾ボタンクリックで生成
        if (useItemFlag == false)
        {
            //TurnChangeButton.SetActive(true);
            

            //insflag is 消えた？



            if (turn == 1&&player1_Bom>0)
            {
                Instantiate(bom);
                player1_Bom--;
            }
            if(turn == 2 && player2_Bom > 0)
            {
                Instantiate(bom2);
                player2_Bom--;
            }
            useItemFlag = true;
        }
    }
    public void WarpButtonClick()
    {
        //爆弾ボタンクリックで生成
        if (useItemFlag2 == false)
        {
            //TurnChangeButton.SetActive(true);

            if (turn == 1 && player1_Warp > 0)
            {
                Instantiate(Warp);
                player1_Warp--;
                Player1ItemView[1].GetComponentInChildren<Text>().text = "ワープ x " + player1_Warp.ToString();

            }
            if (turn == 2 && player2_Warp > 0)
            {
                Instantiate(Warp2);
                player2_Warp--;
                Player2ItemView2[1].GetComponentInChildren<Text>().text = "ワープ x " + player2_Warp.ToString();

            }
            useItemFlag2 = true;
        }
    }
    public void AddBom()
    {
        if (turn==1)
        {
            player1_Bom++;
        }
        if (turn == 2)
        {
            player2_Bom++;
        }
    }
    public void AddWarp()
    {
        if (turn == 1)
        {
            player1_Warp = 1;
            Player1ItemView[1].GetComponentInChildren<Text>().text = "ワープ x " + player1_Warp.ToString();

        }
        if (turn == 2)
        {
            player2_Warp = 1;
            Player2ItemView2[1].GetComponentInChildren<Text>().text = "ワープ x " + player2_Warp.ToString();
        }
    }
    public void AddHp()
    {
        if (turn == 1)
        {
            if (player1_Hp == 1)
            {
                player1_Hp++;
                Instantiate(playerhpSprite[3]);
            }
        }
        if (turn == 2)
        {
            if (player2_Hp == 1)
            {
                player2_Hp++;
                Instantiate(playerhpSprite[4]);
            }
        }
    }
    public void MinusHp()
    {
        if (turn == 1)
        {
                player2_Hp--;
        }
        if (turn == 2)
        {
                player1_Hp--;
        }
    }
    public int getplayer1HP()
    {
        return player1_Hp;
    }
    public int getplayer2HP()
    {
        return player2_Hp;
    }
    public void Seven()
    {
        if (turn == 1)
        {
            Instantiate(seven);
        }
        if(turn == 2)
        {
            Instantiate(seven2);
        }
    }
    public void Bar()
    {
        if (turn == 1)
        {
            Instantiate(bar);
        }
        if (turn == 2)
        {
            Instantiate(bar2);
        }
    }

}
