using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarp : MonoBehaviour {

    public GameObject GameCom;

    public GameObject Player1;
    public GameObject Player2;

    private int turn;
    private int x = 0;
    private int y = 0;

    public KeyCode DecideButton;

    public KeyCode DecideButton2;

    private bool CursorFlag;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(x);
        Debug.Log(y);

        turn = GameCom.GetComponent<GameManager>().getTurn();
        Player1 = GameObject.Find("Player1(Clone)");
        Player2 = GameObject.Find("Player2(Clone)");


        if (turn == 1)
        {
            if (Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(DecideButton))
            {
                Player1.transform.position = transform.position;
                Destroy(gameObject);
                Destroy(GameObject.Find("not1(Clone)"));
            }
            if (y < 5)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical") == -1 && CursorFlag == false)
                {
                    transform.Translate(new Vector3(0, 1, 0));
                    y++;
                    CursorFlag = true;
                }
            }
            if (y > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical") == 1 && CursorFlag == false)
                {
                    transform.Translate(new Vector3(0, -1, 0));
                    y--;
                    CursorFlag = true;
                }
            }
            if (x > 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") == -1 && CursorFlag == false)
                {
                    transform.Translate(new Vector3(-1, 0, 0));
                    x--;
                    CursorFlag = true;
                }
            }
            if (x < 5)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxis("Horizontal") == 1 && CursorFlag == false)
                {
                    transform.Translate(new Vector3(1, 0, 0));
                    x++;
                    CursorFlag = true;
                }
            }
            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
            {
                CursorFlag = false;
            }

        }
        if(turn == 2)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(DecideButton2))
            {
                Player2.transform.position = transform.position;
                Destroy(gameObject);
            }
            if (y < 5)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical") == -1 && CursorFlag == false)
                {
                    transform.Translate(new Vector3(0, 1, 0));
                    y++;
                    CursorFlag = true;
                }
            }
            if (y > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical") == 1 && CursorFlag == false)
                {
                    transform.Translate(new Vector3(0, -1, 0));
                    y--;
                    CursorFlag = true;
                }
            }
            if (x > 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") == -1 && CursorFlag == false)
                {
                    transform.Translate(new Vector3(-1, 0, 0));
                    x--;
                    CursorFlag = true;
                }
            }
            if (x < 5)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxis("Horizontal") == 1 && CursorFlag == false)
                {
                    transform.Translate(new Vector3(1, 0, 0));
                    x++;
                    CursorFlag = true;
                }
            }
            if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
            {
                CursorFlag = false;
            }
        }
	}
}
