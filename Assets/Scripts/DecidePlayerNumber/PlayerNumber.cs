using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerNumber : MonoBehaviour
{
    public static int playerNumber;
    public Text point;
    public static bool Is_sound;
    public Image SoundImg;
    GameObject BGM;


    void Start()
    {
        playerNumber = 4;
        point.text = playerNumber.ToString();
        Is_sound = true;
    }


    public void ClickPlayerIncrease()
    {
        if (playerNumber < 6)
            playerNumber ++;
        point.text = playerNumber.ToString();
    }

    public void ClickPlayerDecrease()
    {
        if (playerNumber == 4)
            playerNumber -= 0;
        else
            playerNumber --;


        point.text = playerNumber.ToString();
    }

    public void BttNextScene()
    {
       SceneManager.LoadScene(2);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ControlSound()
    {
        if (Is_sound == true)
        {
            SoundImg.sprite = Resources.Load("選單_關閉聲音", typeof(Sprite)) as Sprite;
            Is_sound = false;
            BGM = GameObject.FindWithTag("sound");
            BGM.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            SoundImg.sprite = Resources.Load("選單_開啟聲音", typeof(Sprite)) as Sprite;
            Is_sound = true;
            BGM = GameObject.FindWithTag("sound");
            BGM.GetComponent<AudioSource>().volume = 0.1f;
        }


    }
}
