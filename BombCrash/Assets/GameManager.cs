using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject bom;
    public GameObject bom2;


    public GameObject Player;

    public GameObject Player2;

    public static  int turn = 1;

    public GameObject[] Player1ItemView;
    public GameObject[] Player2ItemView;

    public GameObject TurnWindow;


    public GameObject TurnChangeButton;
    
    private bool FirstSetFlag;
    private bool SecondSetFlag;

    private bool insflag;
    private bool insflag2;


    private bool UseItemflag;

    // Use this for initialization
    void Start () {
        Instantiate(Player);
        TurnChangeButton.SetActive(false);
        for(int i = 0; i < 3; i++) {
            Player1ItemView[i].SetActive(false);
            Player2ItemView[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update () {
        FirstSetFlag = Player.GetComponent<CharMove>().GetFlag();
        SecondSetFlag = Player2.GetComponent<CharMove2>().GetFlag();

        Debug.Log(turn);
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

            for (int i = 0; i < 3; i++)
            {
                Player1ItemView[i].SetActive(true);
                Player2ItemView[i].SetActive(false);
            }
            TurnWindow.GetComponent<Text>().text = "ターン:player1";
        }
        else
        {
            for (int i = 0; i < 3; i++)
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

        //爆弾ボタンクリックで生成
        if (FirstSetFlag == true&&SecondSetFlag ==true&&insflag2 ==false)
        {


            //TurnChangeButton.SetActive(true);

            if (turn == 1)
            {
                Instantiate(bom);
            }
            else
            {
                Instantiate(bom2);
            }
            insflag2 = true;
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
        //TurnChangeButton.SetActive(false);
    }
    public void cameraChange()
    {

    }
    public int getTurn()
    {
        return turn;
    }
}
