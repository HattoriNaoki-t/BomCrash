using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour {
    public GameObject bomb_effect;
    private ParticleSystem bomb;
    // Use this for initialization
    void Start () {
        bomb_effect = GameObject.Find("Bomb8");
        bomb = bomb_effect.gameObject.GetComponent<ParticleSystem>();
        bomb.Stop();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {

        Instantiate(bomb_effect, transform.position,
            Quaternion.identity);
        bomb.Play(); //パーティクルの再生
        Debug.Log("ターンエンド");

    }
}
