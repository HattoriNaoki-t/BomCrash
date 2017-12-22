using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBom : MonoBehaviour {


    public GameObject Player;
    public GameObject Player2;


    private bool FirstSetFlag;
    private bool SecondSetFlag;
    private int x = 0;
    private int y = 0;

    public KeyCode DecideButton;
    public KeyCode DecideButton2;


    public GameObject GameCom;

    private int turn;

    public bool bomflag;

    private bool CursorFlag;
    //public GameObject bom;

    // Use this for initialization
    void Start () {
     
	}
	
	// Update is called once per frame
	void Update ()
    {
        FirstSetFlag = Player.GetComponent<CharMove>().GetFlag();
        SecondSetFlag = Player2.GetComponent<CharMove2>().GetFlag();

        //if(bomflag==false)
        //{
        //    Instantiate(bom,new Vector3(0,5,5),Quaternion.identity);
        //    bomflag = true;
        //} 
        turn = GameCom.GetComponent<GameManager>().getTurn();

        //Debug.Log(FirstSetFlag);
        if (FirstSetFlag&&SecondSetFlag)
        {
            if (turn == 1)
            {
                if (y < 5)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxisRaw("joy1 Y") == 1 && CursorFlag == false)
                    {
                        transform.Translate(new Vector3(0, 0, -1));
                        y++;
                        CursorFlag = true;
                    }
                }
                if (y > 0)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxisRaw("joy1 Y") == -1 && CursorFlag == false)
                    {
                        transform.Translate(new Vector3(0, 0, 1));
                        y--;
                        CursorFlag = true;
                    }
                }
                if (x > 0)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxisRaw("joy1 X") == -1 && CursorFlag == false)
                    {
                        transform.Translate(new Vector3(-1, 0, 0));
                        x--;
                        CursorFlag = true;
                    }
                }
                if (x < 5)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxisRaw("joy1 X") == 1 && CursorFlag == false)
                    {
                        transform.Translate(new Vector3(1, 0, 0));
                        x++;
                        CursorFlag = true;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(DecideButton))
                {
                    transform.GetComponent<Rigidbody>().useGravity = true;
                }

                if (Input.GetAxisRaw("joy1 X") == 0 && Input.GetAxisRaw("joy1 Y") == 0)
                {
                    CursorFlag = false;
                }
            }
            if (turn == 2)
            {
                if (y < 5)
                {
                    if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxisRaw("joy2 Y") == 1 && CursorFlag == false)
                    {
                        transform.Translate(new Vector3(0, 0, -1));
                        y++;
                        CursorFlag = true;
                    }
                }
                if (y > 0)
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxisRaw("joy2 Y") == -1 && CursorFlag == false)
                    {
                        transform.Translate(new Vector3(0, 0, 1));
                        y--;
                        CursorFlag = true;
                    }
                }
                if (x > 0)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxisRaw("joy2 X") == -1 && CursorFlag == false)
                    {
                        transform.Translate(new Vector3(-1, 0, 0));
                        x--;
                        CursorFlag = true;
                    }
                }
                if (x < 5)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxisRaw("joy2 X") == 1 && CursorFlag == false)
                    {
                        transform.Translate(new Vector3(1, 0, 0));
                        x++;
                        CursorFlag = true;
                    }
                }
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(DecideButton2))
                {
                    transform.GetComponent<Rigidbody>().useGravity = true;
                }

                if (Input.GetAxisRaw("joy2 X")  == 0 && Input.GetAxisRaw("joy2 Y") == 0)
                {
                    CursorFlag = false;
                }
            }
        }
        
    }
}
