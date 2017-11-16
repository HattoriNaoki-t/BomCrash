using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamegeEffect : MonoBehaviour
{

    public GameObject explosion;
    public GameObject not;
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

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Floor")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            if (gamemanager.GetComponent<GameManager>().getTurn() == 1)
            {

                Debug.Log("palyer1");
                not.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 255, 255);
                playerNum = 2;
            }
            else
            {
                Debug.Log("palyer2");
                not.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
                playerNum = 1;
            }
            Instantiate(not, new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z), Quaternion.Euler(90, 0, 0));
            Destroy(gameObject);
        }

        if (collision.transform.tag == "Player1")
        {
            if (player1_hp == 2)
            {
                Destroy(GameObject.Find("life1-1"));
                player1_hp = 1;
            }
            else
            {
                Destroy(GameObject.Find("life1"));
                SceneManager.LoadScene("Title");
            }
        }
        if (collision.transform.tag == "Player2")
        {
            if (player2_hp == 2)
            {
                Destroy(GameObject.Find("life2-1"));
                player2_hp = 1;
            }
            else
            {
                Destroy(GameObject.Find("life2"));
                SceneManager.LoadScene("Title");
            }
        }

        Instantiate(explosion, collision.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

