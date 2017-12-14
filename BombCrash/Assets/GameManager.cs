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

    public int player1_Hp = 2;
    public int player2_Hp = 2;

    public GameObject seven;
    public GameObject bar;



    private GameObject MainCam;
    private GameObject SubCam;


    public int selectNumber1;
    public int selectNumber2;

    public GameObject[] playerhpSprite;


    // Use this for initialization
    void Start () {
        Instantiate(Player);
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

        Debug.Log(player1_Warp);
        Debug.Log(player2_Warp);

        //switch (selectNumber1)
        //{
        //    case 0:Player1ItemView[0].GetComponent<Image>().color = new Color(1,1,0.7f);
        //        break;
        //    case 1: Player1ItemView[0].GetComponent<Image>().color = new Color(50, 0, 0, 255);
        //        break;
        //    case 2: Player1ItemView[0].GetComponent<Image>().color = new Color(255, 0, 0, 255);
        //        break;
        //    case 3: Player1ItemView[0].GetComponent<Image>().color = new Color(255, 0, 0, 255);
        //        break;
        //}
        //switch (selectNumber2)
        //{
        //    case 0: break;
        //    case 1: break;
        //    case 2: break;
        //    case 3: break;
        //}

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
            }
            if(turn == 2 && player2_Bom > 0)
            {
                Instantiate(bom2);
                player2_Bom--;
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
