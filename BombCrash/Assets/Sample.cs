using UnityEngine;
using System.Collections;

public class Sample : MonoBehaviour
{

    private GameObject MainCam;
    private GameObject SubCam;

    void Start()
    {
        MainCam = GameObject.Find("Main Camera");
        SubCam = GameObject.Find("SubCamera");

        SubCam.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (MainCam.activeSelf)
            {
                MainCam.SetActive(false);
                SubCam.SetActive(true);
            }
            else
            {
                MainCam.SetActive(true);
                SubCam.SetActive(false);
            }
        }
    }

}