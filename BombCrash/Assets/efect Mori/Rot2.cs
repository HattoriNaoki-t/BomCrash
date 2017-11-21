using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rot2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 90, 0) *
            Time.deltaTime * 10, Space.World);
    }
}
