using System.Collections;
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

    public GameObject[] Player1ItemView;
    public GameObject[] Player2ItemView;

    public GameObject TurnWindow;


    public GameObject TurnChangeButton;
    
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

    private bool CursorFlag;


    private GameObject MainCam;
    private GameObject SubCam;


    public int selectNumber1;
    public int selectNumber2;

    public GameObject[] playerhpSprite;


    // Use this for initialization
    void Start () {
        Player = Instantiate(Player);

        for(int i = 0; i < 4; i++)
        {
            Instantiate(playerhpSprite[i]);
        }
        TurnChangeButton.SetActive(false);
        for(int i = 0; i < Player1ItemView.Length; i++) {
            Player1ItemView[i].SetActive(false);
            Player2ItemView[i].SetActive(false);
        }

        MainCam = GameObject.Find("Main Camera");
        SubCam = GameObject.Find("SubCamera");

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

        Debug.Log(Input.GetAxis("Horizontal"));
        Debug.Log(Input.GetAxis("Vertical"));
        
        //Debug.Log(selectNumber1);
        //Debug.Log(selectNumber2);

        if (FirstSetFlag&&SecondSetFlag&&MainCam.active==true&&UseBom==false&&UseWarp==false)
        {
            switch (selectNumber1)
            {
                case 0:
                    Player1ItemView[0].GetComponent<Image>().color = new Color(1, 1, 0.7f);
                    Player1ItemView[1].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player1ItemView[2].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetAxis("Vertical")==-1&&CursorFlag ==false)
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
                    Player1ItemView[0].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player1ItemView[1].GetComponent<Image>().color = new Color(1, 1, 0.7f);
                    Player1ItemView[2].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    if (Input.GetKeyDown(KeyCode.DownArrow) && FirstSetFlag || Input.GetAxis("Vertical") == -1 && CursorFlag == false)
                    {
                        selectNumber1++;
                    }
                    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical") == 1 && CursorFlag == false)
                    {
                        selectNumber1--;
                    }
                    if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(DecideButton))
                    {
                        WarpButtonClick();
                    }
                    break;
                case 2:
                    Player1ItemView[0].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player1ItemView[1].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player1ItemView[2].GetComponent<Image>().color = new Color(1, 1, 0.7f);
                    if (Input.GetKeyDown(KeyCode.UpArrow) && FirstSetFlag || Input.GetAxis("Vertical") == 1 && CursorFlag == false)
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
                    Player2ItemView[0].GetComponent<Image>().color = new Color(1, 1, 0.7f);
                    Player2ItemView[1].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player2ItemView[2].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical") == -1 && CursorFlag == false)
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
                    Player2ItemView[0].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player2ItemView[1].GetComponent<Image>().color = new Color(1, 1, 0.7f);
                    Player2ItemView[2].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical") == -1 && CursorFlag == false)
                    {
                        selectNumber2++;
                        CursorFlag = true;
                    }
                    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical") == 1 && CursorFlag == false)
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
                    Player2ItemView[0].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player2ItemView[1].GetComponent<Image>().color = new Color(1, 1, 1.0f);
                    Player2ItemView[2].GetComponent<Image>().color = new Color(1, 1, 0.7f);
                    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical") == 1 && CursorFlag == false)
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
        if (Input.GetAxis("Vertical") == 0 && MainCam.active == true)
        {
            CursorFlag = false;
        }









        Player1ItemView[0].GetComponentInChildren<Text>().text = "爆弾 x " + player1_Bom.ToString();

        Player2ItemView[0].GetComponentInChildren<Text>().text = "爆弾 x " + player2_Bom.ToString();

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
        }


        //Debug.Log(turn);
        if (GameObject.FindGameObjectsWithTag("Bom").Length > 0)
        {
            UseBom = true;
        }
        else
        {
            UseBom = false;
        }
        if (GameObject.FindGameObjectsWithTag("Warp").Length > 0)
        {
            UseWarp = true;
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
            Player.GetComponent<MeshRenderer>().material.color = new Color(Player.GetComponent<MeshRenderer>().material.color.r, Player.GetComponent<MeshRenderer>().material.color.g, Player.GetComponent<MeshRenderer>().material.color.b, 1.0f);

            for (int i = 0; i < Player1ItemView.Length; i++)
            {
                Player1ItemView[i].SetActive(true);
                Player2ItemView[i].SetActive(false);
            }
            TurnWindow.GetComponent<Text>().text = "ターン:player1";
        }
        if (turn == 2)
        {
            insflag4 = false;
            Player2.GetComponent<MeshRenderer>().material.color = new Color(Player2.GetComponent<MeshRenderer>().material.color.r, Player2.GetComponent<MeshRenderer>().material.color.g, Player2.GetComponent<MeshRenderer>().material.color.b, 1.0f);

            for (int i = 0; i < Player1ItemView.Length; i++)
            {
                Player1ItemView[i].SetActive(false);
                Player2ItemView[i].SetActive(true);
            }
            TurnWindow.GetComponent<Text>().text = "ターン:player2";
        }

        if (UseBom==true||UseWarp==true)
        {
            Player1ItemView[2].SetActive(false);
            Player2ItemView[2].SetActive(false);
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
        useItemFlag = false;
        useItemFlag2 = false;

        //TurnChangeButton.SetActive(false);
    }
    public void cameraChange()
    {

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
                Instantiate(Warp);
                player2_Warp--;
                Player2ItemView[1].GetComponentInChildren<Text>().text = "ワープ x " + player2_Warp.ToString();
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
        }
        if (turn == 2)
        {
            player2_Warp = 1;
        }
    }
    public void AddHp()
    {
        if (turn == 1)
        {
            if (player1_Hp == 1)
                player1_Hp++;
        }
        if (turn == 2)
        {
            if (player2_Hp == 1)
                player2_Hp++;
        }
    }
    public void MinusHp()
    {
        if (turn == 1)
        {
                player1_Hp--;
        }
        if (turn == 2)
        {
                player2_Hp--;
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
        Instantiate(seven);
    }
    public void Bar()
    {
        Instantiate(bar);
    }

}
