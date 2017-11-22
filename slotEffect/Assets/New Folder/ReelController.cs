using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class ReelController : MonoBehaviour
{

    public GameController gc;


    public KeyCode stopKey;


    public int line_ID = 0; //リールのid

    public GameObject[] imgobj; //絵柄のプレハブを格納

    int[] lines = new int[3];   //リール停止時に見えている絵柄のid(imgobjの番号)を格納

    int[] current = { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1,- 1, -1, -1, -1, -1, -1, -1, -1 }; //配列に全体の絵柄idを格納

    GameObject[] tmp_obj = new GameObject[20];

    Transform[] img_pos = new Transform[20];



    Transform pos;  //リールのTransform

    Vector3 initpos; //リールの初期位置


    public int speed; //リールの回転速度

    bool turn = false; //回転させるか否か

    int flg = 0;



    void Awake()
    {

        pos = GetComponent<Transform>();

        initpos = pos.localPosition;

        for (int i = 0; i < 20; i++)
        {

            Vector3 pos = new Vector3(0.0f, -2.0f + (2.0f * i), 0.0f);

            int tmp = Random.Range(0, imgobj.Length);//絵柄をランダムで生成



            if (i != 0 && i < 9)
            {

                while (current[i - 1] == tmp)
                { //前の絵柄と同じにならないように再抽選

                    tmp = Random.Range(0, imgobj.Length);

                }

            }
            else if (i == 16)
            {

                tmp = current[0];

            }
            else if (i == 17)
            {

                tmp = current[1];

            }
            else if (i == 18)
            {

                tmp = current[2];

            }



            current[i] = tmp;

            tmp_obj[i] = null;
            
            tmp_obj[i] = Instantiate<GameObject>(imgobj[tmp]); //プレハブからGameObjectを生成

            tmp_obj[i].transform.SetParent(transform, false); //リールのオブジェクトを親にする

            img_pos[i] = tmp_obj[i].GetComponent<Transform>();

            img_pos[i].localPosition = pos;

        }

    }



    // Update is called once per frame

    void Update()
    {

        //接続器のストップ
        if (Input.GetKeyDown(stopKey))
        {
            turn = false;

            gc.Stopbt_f(line_ID);
        }


        ///////////////////////////////////////////////////////


        if (pos.localPosition.y < -8.1)
        {

            pos.localPosition = initpos;

        }

       


        if (turn)
        {

            pos.localPosition = new Vector3(pos.localPosition.x, pos.localPosition.y - (speed * Time.deltaTime), pos.localPosition.z);

        }
        else
        {

            if (pos.localPosition.y % 1.0f < -0.06f)
            {   //絵柄をマスで固定するために回転スピードを弱める

                flg = 0;

                pos.localPosition = new Vector3(pos.localPosition.x, pos.localPosition.y - 0.03f, pos.localPosition.z);

            }
            else
            {   //固定完了

                if (flg == 0)
                {   //トリガー

                    flg = 1;

                    int under = -1 * (int)(pos.localPosition.y / 0.9);  //何マス回転（移動）したか



                    for (int i = 0; i < 3; i++)
                    {

                        lines[i] = current[(under) + i];    //絵柄を特定

                    }

                    //値送り、絵柄配列を送る[0]が一番下の絵柄[1]が真ん中[2]が一番上

                    if (line_ID == 0)
                    {

                        gc.SetLineR(lines);

                    }
                    else if (line_ID == 1)
                    {

                        gc.SetLineC(lines);

                    }
                    else
                    {

                        gc.SetLineL(lines);

                    }



                }

            }



        }

    }


    


    public void Reel_Stop()
    {

        turn = false;
       
        //マウスクリック(ストップ)
        gc.Stopbt_f(line_ID);

    }

  


    public void Reel_Move()
    {

        turn = true;

        flg = 0;

    }



}
