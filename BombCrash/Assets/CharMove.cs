﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour {


    static bool SetFlag;

    private int x = 0;
    private int y = 0;

    public KeyCode stop;
    public KeyCode[] arrow;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (SetFlag == false)
        {
            if (y < 5)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(arrow[0]) || Input.GetAxis("Horizontal") == 1)
                {
                    transform.Translate(new Vector3(0, 0, -1));
                    y++;
                }
            }
            if (y > 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(arrow[1]) || Input.GetAxis("Vertical") == 1)
                {
                    transform.Translate(new Vector3(0, 0, 1));
                    y--;
                }
            }
            if (x > 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(arrow[2]) || Input.GetAxis("Horizontal") == -1)
                {
                    transform.Translate(new Vector3(-1, 0, 0));
                    x--;
                }
            }
            if (x < 5)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(arrow[3]) || Input.GetAxis("Vertical") == -1)
                {
                    transform.Translate(new Vector3(1, 0, 0));
                    x++;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(stop))
        {
            transform.GetComponent<MeshRenderer>().material.color = new Color(transform.GetComponent<MeshRenderer>().material.color.r, transform.GetComponent<MeshRenderer>().material.color.g, transform.GetComponent<MeshRenderer>().material.color.b, 0.0f);
            SetFlag = true;
        }
    }

    public bool GetFlag()
    {
        return SetFlag;
    }
}
