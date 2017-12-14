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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        turn = GameCom.GetComponent<GameManager>().getTurn();
        Player1 = GameObject.Find("Player1(Clone)");
        Player2 = GameObject.Find("Player2(Clone)");


        if (turn == 1)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Player1.transform.position = transform.position;
                Destroy(gameObject);
            }
            if (y < 5)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.Translate(new Vector3(0, 1, 0));
                    y++;
                }
            }
            if (y > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.Translate(new Vector3(0, -1, 0));
                    y--;
                }
            }
            if (x > 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.Translate(new Vector3(-1, 0, 0));
                    x--;
                }
            }
            if (x < 5)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.Translate(new Vector3(1, 0, 0));
                    x++;
                }
            }

        }
        if(turn == 2)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Player2.transform.position = transform.position;
                Destroy(gameObject);
            }
            if (y < 5)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.Translate(new Vector3(0, 1, 0));
                    y++;
                }
            }
            if (y > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.Translate(new Vector3(0, -1, 0));
                    y--;
                }
            }
            if (x > 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.Translate(new Vector3(-1, 0, 0));
                    x--;
                }
            }
            if (x < 5)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.Translate(new Vector3(1, 0, 0));
                    x++;
                }
            }
        }
	}
}
