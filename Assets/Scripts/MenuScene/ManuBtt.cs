using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManuBtt : MonoBehaviour
{
    public GameObject Intro_Panel;
    public GameObject Left_Intro_Btt;
    public GameObject Right_Intro_Btt;
    public GameObject Close_Intro_Btt;

    public GameObject[] Intro_Img;

    int Page;

    private void Start()
    {
        Page = 0;
        Intro_Panel.SetActive(false);
    }

    private void Update()
    {
        if(Page==0)
        Left_Intro_Btt.SetActive(false);
        else
            Left_Intro_Btt.SetActive(true);
        if (Page==19)
        Right_Intro_Btt.SetActive(false);
        else
            Right_Intro_Btt.SetActive(true);
    }

    public void Game_Start()
    {
        SceneManager.LoadScene(1);
    }


    public void Exiting()
    {
        Application.Quit();
    }

    public void Open_Intro()
    {
        Intro_Img[Page].SetActive(true);
        Intro_Panel.SetActive(true);
    }

    public void Left_Intro()
    {
        Page--;
        Intro_Img[Page].SetActive(true);
        Intro_Img[Page+1].SetActive(false);

    }

    public void Right_Intro()
    {
        Page++;
        Intro_Img[Page].SetActive(true);
        Intro_Img[Page - 1].SetActive(false);
    }

    public void Close_Intro()
    {
        Intro_Panel.SetActive(false);
        for(int i = 0; i < 20; i++)
        {
            Intro_Img[i].SetActive(false);
        }
        Page = 0;

    }
}
