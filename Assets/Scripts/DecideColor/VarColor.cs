using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VarColor : MonoBehaviour
{

    public static int[] playerColor ;  
    //宣告一個int變數陣列，儲存每個玩家選擇的顏色，容量為玩家所選擇的人數

    public static string[] everyPlayerVeiw ; 
    //宣告一個string變數陣列，使每一玩家選擇顏色後，在下一個scenes，都會在text顯示你選擇甚麼顏色

    public static int temp ;
    //temp是玩家選擇職業(顏色)，temp就會+1，用以輸入顏色進入color變數裡

    public Image SoundImg;
    GameObject BGM;


    void Start()
    {
        /*for(int i=0; i < playerColor.Length ; i++)
        {
            playerColor[i] = null;
        }*/
        temp = 0;
        playerColor = new int[PlayerNumber.playerNumber];
        everyPlayerVeiw = new string[PlayerNumber.playerNumber];

        Debug.Log("" + playerColor.Length);
    }


    public void ControlSound()
    {
        if (PlayerNumber.Is_sound == true)
        {
            SoundImg.sprite = Resources.Load("選單_關閉聲音", typeof(Sprite)) as Sprite;
            PlayerNumber.Is_sound = false;
            BGM = GameObject.FindWithTag("sound");
            BGM.GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            SoundImg.sprite = Resources.Load("選單_開啟聲音", typeof(Sprite)) as Sprite;
            PlayerNumber.Is_sound = true;
            BGM = GameObject.FindWithTag("sound");
            BGM.GetComponent<AudioSource>().volume = 0.1f;
        }


    }
}
