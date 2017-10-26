using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsEffect : MonoBehaviour {

    public GameObject explosion;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bom")
        {
            Instantiate(explosion, collision.transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
        }
    }
}
