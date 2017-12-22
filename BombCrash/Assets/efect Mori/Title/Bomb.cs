using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    int bom_max = 3;
    int time = 0;
    int timeCnt = 0;

    public MeshRenderer Meshpos;

    public GameObject bomb;
    private ParticleSystem bomb_effect;
    // Use this for initialization
    void Start () {
        //bomb_effect = GameObject.Find("Bomb8");
        bomb = this.transform.Find("Bomb8").gameObject;
        bomb_effect = bomb.gameObject.GetComponent<ParticleSystem>();
        bomb_effect.Stop();

        Meshpos = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update () {
        timeCnt++;
        if(timeCnt==60)
        {
            time++;
            timeCnt = 0;
        }

        if(time==5)
        {
            BomRon();
            time = 0;
            timeCnt = 0;
        }
    }

    void BomRon()
    {
        float x = Random.Range(-5.0f, 5.0f);
        float y = 20.0f;
        float z = Random.Range(0.0f, 10.0f);

        transform.position = new Vector3(x, y, z);
        Meshpos.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Meshpos.enabled = false;

        Debug.Log("俺のターン");

        bomb_effect.Play(); //パーティクルの再生
    }

}
