using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBom : MonoBehaviour {


    public GameObject Player;


    private bool FirstSetFlag;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        FirstSetFlag = Player.GetComponent<CharMove>().GetFlag();

        //Debug.Log(FirstSetFlag);
        if (FirstSetFlag)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, 0, -1));
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, 0, 1));
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-1, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(1, 0, 0));
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                transform.GetComponent<Rigidbody>().useGravity = true;
            }
        }

    }
}
