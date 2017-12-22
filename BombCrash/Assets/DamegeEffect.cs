using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamegeEffect : MonoBehaviour
{

    public GameObject explosion;
    public GameObject not;
    public GameObject not2;
    public GameObject gamemanager;

    static int player1_hp = 2;
    static int player2_hp = 2;

    static private int playerNum = 1;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player1_hp);
        Debug.Log(player2_hp);
        player1_hp = gamemanager.GetComponent<GameManager>().getplayer1HP();
        player2_hp = gamemanager.GetComponent<GameManager>().getplayer2HP();


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            var obj = Instantiate(explosion, transform.position, Quaternion.identity);
            if (gamemanager.GetComponent<GameManager>().getTurn() == 1)
            {

                Debug.Log("palyer1");
                Instantiate(not, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.Euler(90, 0, 0));
                playerNum = 2;
            }
            else
            {
                Debug.Log("palyer2");
                Instantiate(not2, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.Euler(90, 0, 0));
                playerNum = 1;
            }
            Destroy(gameObject);
            Destroy(obj, 2.0f);
        }
        if (collision.transform.tag == "Player1")
        {
            if (player1_hp == 2)
            {
                Destroy(GameObject.Find("life1-1(Clone)"));
                gamemanager.GetComponent<GameManager>().MinusHp();
            }
            if(player1_hp == 1)
            {
                Destroy(GameObject.Find("life1(Clone)"));
                SceneManager.LoadScene("Title");
            }
            var obj = Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(obj, 2.0f);
        }
        if (collision.transform.tag == "Player2")
        {
            if (player2_hp == 2)
            {
                Destroy(GameObject.Find("life2-1(Clone)"));

                gamemanager.GetComponent<GameManager>().MinusHp();
            }
            if(player2_hp == 1)
            {
                Destroy(GameObject.Find("life2(Clone)"));
                SceneManager.LoadScene("Title");
            }
            var obj = Instantiate(explosion, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(obj, 2.0f);
        }

    }
}

