﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBom : MonoBehaviour {


    public GameObject Player;
    public GameObject Player2;


    private bool FirstSetFlag;
    private bool SecondSetFlag;
    private int x = 0;
    private int y = 0;



    public bool bomflag;

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


        //Debug.Log(FirstSetFlag);
        if (FirstSetFlag&&SecondSetFlag)
        {
            if (y < 5)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    transform.Translate(new Vector3(0, 0, -1));
                    y++;
                }
            }
            if (y > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    transform.Translate(new Vector3(0, 0, 1));
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.GetComponent<Rigidbody>().useGravity = true;
            }
        }
        
    }
}