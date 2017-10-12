using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour {

    public GameObject floor;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < 5; i++)
        {
            for(int j=0;j<5;j++)
            {
                var chil  = Instantiate(floor, new Vector3(i, 0, j), Quaternion.identity);
                chil.transform.parent = gameObject.transform;
                chil.name = i.ToString() + j.ToString();
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
