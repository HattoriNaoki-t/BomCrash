using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var joy1 = Input.GetAxisRaw("joy1");
        //var joy2 = Input.GetAxisRaw("joy2");
        if(joy1==1)
        {
            Debug.Log("joy1");
        }
        //if (joy2 == 1)
        //{
          //  Debug.Log("joy2");
        //}


        Debug.Log(joy1);

        //Debug.Log(joy2);

    }
}
