using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effectall : MonoBehaviour {

    //
    GameObject[] ob=new GameObject[5];

    Vector3 pos;



    //
    ParticleSystem baku;
    ParticleSystem[] botan = new ParticleSystem[3];
    ParticleSystem[] botan2 = new ParticleSystem[3];

    int math;


    // Use this for initialization
    void Start () {
        ob[0] = GameObject.Find("bakuhatu");
        baku = gameObject.GetComponent<ParticleSystem>();
        baku.Stop();

        ob[4] = GameObject.Find("botan");
        botan[0] = gameObject.GetComponent<ParticleSystem>();
        botan[1] = gameObject.GetComponent<ParticleSystem>();
        botan[2] = gameObject.GetComponent<ParticleSystem>();

        pos = botan[0].transform.position;

        ob[4] = GameObject.Find("botan2");
        botan2[0] = gameObject.GetComponent<ParticleSystem>();
        botan2[1] = gameObject.GetComponent<ParticleSystem>();
        botan2[2] = gameObject.GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.O))
        {
            baku.Play();
        }
	}
}
