using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject bom;
    public GameObject bom2;


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
    private bool insflag2;
    private bool insflag3;

    private bool UseItemflag;

    public int player1_Bom = 3;
    public int player2_Bom = 3;
    public int player1_Warp = 1;
    public int player2_Warp = 1;

    private GameObject MainCam;
    private GameObject SubCam;



    // Use this for initialization
    void Start () {
        Instantiate(Player);
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

        if(FirstSetFlag == true && SecondSetFlag == true&&insflag3 ==false)
        {
            turn = 1;
            insflag3 = true;
        }


        //Debug.Log(turn);
        if (GameObject.FindGameObjectsWithTag("Bom").Length > 0)
        {
            UseItemflag = true;
        }
        else
        {
            UseItemflag = false;
        }


        if (turn == 1)
        {

            for (int i = 0; i < Player1ItemView.Length; i++)
            {
                Player1ItemView[i].SetActive(true);
                Player2ItemView[i].SetActive(false);
            }
            TurnWindow.GetComponent<Text>().text = "ターン:player1";
        }
        if(turn == 2)
        {
            for (int i = 0; i < Player1ItemView.Length; i++)
            {
                Player1ItemView[i].SetActive(false);
                Player2ItemView[i].SetActive(true);
            }
            TurnWindow.GetComponent<Text>().text = "ターン:player2";
        }

        //Debug.Log(turn);

        if (FirstSetFlag && insflag ==false)
        {
            Instantiate(Player2, new Vector3(5, 1.5f, 0),Quaternion.identity);
            insflag = true;
        }

        
        if(UseItemflag==true)
        {
            Player1ItemView[2].SetActive(false);
            Player2ItemView[2].SetActive(false);
        }

    }

    public void changeTurn()
    {
        if(turn == 1)
        {
            turn = 2;

        }
        else
        {
            turn = 1;
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
        insflag2 = false;
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
        if (insflag2 == false)
        {
            //TurnChangeButton.SetActive(true);

            if (turn == 1&&player1_Bom>0)
            {
                Instantiate(bom);
                player1_Bom--;
                Player1ItemView[0].GetComponentInChildren<Text>().text = "爆弾 x " + player1_Bom.ToString();
            }
            if(turn == 2 && player2_Bom > 0)
            {
                Instantiate(bom2);
                player2_Bom--;
                Player2ItemView[0].GetComponentInChildren<Text>().text = "爆弾 x " + player2_Bom.ToString();
            }
            insflag2 = true;
        }
    }
    public void WarpButtonClick()
    {
        //爆弾ボタンクリックで生成
        if (insflag2 == false)
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
            insflag2 = true;
        }
    }
}
