using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour {

    public GameObject floor1;
    public GameObject floor2;
    private GameObject floor;

    // Use this for initialization
    void Start () {
        for(int i = 0; i < 6; i++)
        {
            for(int j=0;j<6;j++)
            {
                if (i % 2 == 0)
                {
                    if (j % 2 == 0)
                    {
                        floor = Instantiate(floor1, new Vector3(i, 0, j), Quaternion.identity);
                    }
                    else
                    {
                        floor = Instantiate(floor2, new Vector3(i, 0, j), Quaternion.identity);
                    }
                }
                else
                {
                    if (j % 2 == 0)
                    {
                        floor = Instantiate(floor2, new Vector3(i, 0, j), Quaternion.identity);
                    }
                    else
                    {
                        floor = Instantiate(floor1, new Vector3(i, 0, j), Quaternion.identity);
                    }
                }

                floor.transform.parent = gameObject.transform;
                floor.name = i.ToString() + j.ToString();
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
