using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove2 : MonoBehaviour
{





    static bool SetFlag2;

    public KeyCode stop;

    private int x = 5;
    private int y = 5;

    private bool CursorFlag;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (SetFlag2 == false)
        {
            if (y < 5)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetAxisRaw("joy2 Y") == 1 && CursorFlag == false)
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
        }
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(stop))
        {

            //transform.GetComponent<MeshRenderer>().material.color = new Color(transform.GetComponent<MeshRenderer>().material.color.r, transform.GetComponent<MeshRenderer>().material.color.g, transform.GetComponent<MeshRenderer>().material.color.b, 0.0f);
            SetFlag2 = true;
        }
        if (Input.GetAxisRaw("joy2 X") == 0 && Input.GetAxisRaw("joy2 Y") == 0)
        {
            CursorFlag = false;
        }
    }

    public bool GetFlag()
    {
        return SetFlag2;
    }
}
