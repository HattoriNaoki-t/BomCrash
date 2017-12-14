using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect2 : MonoBehaviour
{
    //
    GameObject Object0;
    GameObject Object1;
    GameObject[] Object2 = new GameObject[3];
    GameObject[] Object3 = new GameObject[3];
    GameObject Object4;
    GameObject Object5;
    GameObject Object6;
    GameObject Object7;
    GameObject Object8;
    GameObject[] Object9=new GameObject[4];
    GameObject[] Button_Red=new GameObject[3];
    GameObject[] Button_Blue = new GameObject[3];

    



    //各必要なエフェクト
    ParticleSystem Bomb;
    ParticleSystem Bomb8;
    ParticleSystem[] Warp_Up = new ParticleSystem[3];
    ParticleSystem[] Warp_Down = new ParticleSystem[3];
    ParticleSystem Big_R;
    ParticleSystem Regular;
    ParticleSystem Regular_Lamp;
    ParticleSystem Small_H;
    ParticleSystem Light;
    ParticleSystem[] Box = new ParticleSystem[4];
    ParticleSystem[] button_red = new ParticleSystem[3];
    ParticleSystem[] button_blue = new ParticleSystem[3];

    int CntP;
    bool Regular_flag;
    bool big_flag;
    bool Warp_flag;

    // Use this for initialization
    void Start()
    {
        //フラグ
        Regular_flag = false;
        big_flag = false;
        Warp_flag = false;

        //爆弾
        Object0 = GameObject.Find("Bomb");
        Bomb = Object0.gameObject.GetComponent<ParticleSystem>();
        Bomb.Stop();

        //爆弾(8)
        Object1 = GameObject.Find("Bomb8");
        Bomb8 = Object1.gameObject.GetComponent<ParticleSystem>();
        Bomb8.Stop();

        //ワープ
        /////////////////上に行くもの
        Object2[0] = GameObject.Find("WarpUp");
        Warp_Up[0] = Object2[0].gameObject.GetComponent<ParticleSystem>();
        Warp_Up[0].Stop();

        Object2[1] = GameObject.Find("Spiral");
        Warp_Up[1] = Object2[1].gameObject.GetComponent<ParticleSystem>();
        Warp_Up[1].Stop();

        Object2[2] = GameObject.Find("Spiral2");
        Warp_Up[2] = Object2[2].gameObject.GetComponent<ParticleSystem>();
        Warp_Up[2].Stop();

        /////////////////下に行くもの
        Object3[0] = GameObject.Find("WarpDown");
        Warp_Down[0] = Object3[0].gameObject.GetComponent<ParticleSystem>();
        Warp_Down[0].Stop();

        Object3[1] = GameObject.Find("Spiral3");
        Warp_Down[1] = Object3[1].gameObject.GetComponent<ParticleSystem>();
        Warp_Down[1].Stop();

        Object3[2] = GameObject.Find("Spiral4");
        Warp_Down[2] = Object3[2].gameObject.GetComponent<ParticleSystem>();
        Warp_Down[2].Stop();

        //ビッグボーナス
        Object4 = GameObject.Find("Big Regular");
        Big_R = Object4.gameObject.GetComponent<ParticleSystem>();
        Big_R.Stop();

        //レギュラー
        Object5 = GameObject.Find("Regular");
        Regular = Object5.gameObject.GetComponent<ParticleSystem>();
        Regular.Stop();

        //小当たり
        Object6 = GameObject.Find("Small hit");
        Small_H = Object6.gameObject.GetComponent<ParticleSystem>();
        Small_H.Stop();

        //小当たり
        Object7 = GameObject.Find("Light");
        Light = Object7.gameObject.GetComponent<ParticleSystem>();
        Light.Stop();

        //レギュラーランプ
        Object8 = GameObject.Find("Regular lamp");
        Regular_Lamp = Object8.gameObject.GetComponent<ParticleSystem>();
        Regular_Lamp.Stop();

        ////ボックス
        Object9[0] = GameObject.Find("box");
        Box[0] = Object9[0].gameObject.GetComponent<ParticleSystem>();
        Box[0].Stop();

        Object9[1] = GameObject.Find("box1");
        Box[1] = Object9[1].gameObject.GetComponent<ParticleSystem>();
        Box[1].Stop();

        Object9[2] = GameObject.Find("box2");
        Box[2] = Object9[2].gameObject.GetComponent<ParticleSystem>();
        Box[2].Stop();

        Object9[3] = GameObject.Find("box3");
        Box[3] = Object9[3].gameObject.GetComponent<ParticleSystem>();
        Box[3].Stop();

        //赤ボタン
        Button_Red[0] = GameObject.Find("Red button");
        button_red[0] = Button_Red[0].gameObject.GetComponent<ParticleSystem>();
        button_red[0].Stop();

        Button_Red[1] = GameObject.Find("Red button2");
        button_red[1] = Button_Red[1].gameObject.GetComponent<ParticleSystem>();
        button_red[1].Stop();

        Button_Red[2] = GameObject.Find("Red button3");
        button_red[2] = Button_Red[2].gameObject.GetComponent<ParticleSystem>();
        button_red[2].Stop();

        //青ボタン
        Button_Blue[0] = GameObject.Find("Blue button");
        button_blue[0] = Button_Blue[0].gameObject.GetComponent<ParticleSystem>();
        //button_blue[0].Stop();

        Button_Blue[1] = GameObject.Find("Blue button2");
        button_blue[1] = Button_Blue[1].gameObject.GetComponent<ParticleSystem>();
        //button_blue[1].Stop();

        Button_Blue[2] = GameObject.Find("Blue button3");
        button_blue[2] = Button_Blue[2].gameObject.GetComponent<ParticleSystem>();
        //button_blue[2].Stop();

    }

    // Update is called once per frame
    void Update()
    {
        //爆弾を使ったら
        if (Input.GetKeyDown(KeyCode.O))
        {
            Bomb.Play();
        }

        //爆弾(8)を使ったら(if文を1にまとめるor2に分けるか考え中)
        if (Input.GetKeyDown(KeyCode.I)&&
            Regular_flag==true)
        {
            Bomb8.Play();
        }

        //光を発動
        if (Input.GetKeyDown(KeyCode.P))
        {
            Light.Play();
        }

        //ワープが使用されたら
        if (Input.GetKeyDown(KeyCode.W))
        {
            Warp_flag = true;

            Warp_Up[0].Play();
            Warp_Up[1].Play();
            Warp_Up[2].Play();
        }

        //ワープを使用し、ワープを完了する地点
        if (Warp_flag==true)
        {

            Warp_Down[0].Play();
            Warp_Down[1].Play();
            Warp_Down[2].Play();
        }

        //ビッグボーナスの時
        if(Input.GetKeyDown(KeyCode.D))
        {
            Regular_Lamp.Play();
            Big_R.Play();
            big_flag = true;
        }

        //レギュラーボーナスの時
        if (Input.GetKeyDown(KeyCode.A))
        {
            Regular_Lamp.Play();
            Regular.Play();
            Regular_flag = true;
        }

        //小当たりの時
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Small_H.Play();
        }

        //当たったら
        if(Input.GetKeyDown(KeyCode.N))
        {
            //0～3をランダムで出す
            int rad = Random.Range(0, 4);

            //出した数字を設定したエフェクト出す
            Box[rad].Play();
        }

        //ボタン(左) 実際押すボタンの処理
        if(Input.GetKeyDown(KeyCode.Z))
        {
            button_blue[0].Stop();
            button_red[0].Play();

            //押した回数を1足す
            CntP += 1;
        }

        //ボタン(中央)実際押すボタンの処理
        if (Input.GetKeyDown(KeyCode.X))
        {
            button_blue[1].Stop();
            button_red[1].Play();

            //押した回数を1足す
            CntP += 1;
        }

        //ボタン(右)実際押すボタンの処理
        if (Input.GetKeyDown(KeyCode.C))
        {
            //
            button_blue[2].Stop();
            button_red[2].Play();

            //押した回数を1足す
            CntP += 1;
        }

        //リールを回すキーを押したら(実際のリールを押すキー)
        if (Input.GetKeyDown(KeyCode.V))
        {
            //3回押したか確認
            if (CntP == 3)
            {
                //青ボタン
                button_blue[0].Play();
                button_blue[1].Play();
                button_blue[2].Play();

                //赤ボタン
                button_red[0].Stop();
                button_red[1].Stop();
                button_red[2].Stop();

                //押した回数のリセット
                CntP = 0;
            }
        }

        //ビッグまたはレギュラー終了したら
        if(Input.GetKeyDown(KeyCode.F)||
            Input.GetKeyDown(KeyCode.J))
        {
            if(big_flag==true)
            {
                big_flag = false;
                Regular_Lamp.Stop();
                Big_R.Stop();
            }

            else if(big_flag==true&&
                Regular_flag==true)
            {
                big_flag = false;
                Regular_flag = false;
                Regular_Lamp.Stop();
                Regular.Stop();
                Big_R.Stop();
            }

            else
            {
                Regular_flag = false;
                Regular_Lamp.Stop();
                Regular.Stop();
            }
        }
    }
}
