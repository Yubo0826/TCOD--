using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerVeiw : MonoBehaviour
{
    public GameObject CardAni;
    public Text[] playerVeiw;

    public GameObject char5_text_GO;
    public GameObject char6_text_GO;

    void Start()
    {
        switch (PlayerNumber.playerNumber)
        {
            case 4:
                char5_text_GO.SetActive(false);
                char6_text_GO.SetActive(false);
                break;
            case 5:
                char6_text_GO.SetActive(false);
                break;
        }


        for (int i= 0; i < PlayerNumber.playerNumber; i++)
        {
            int nowPlayer = i + 1;

            switch (VarColor.playerColor[i])
            {
                case 1:
                    playerVeiw[i].text = "玩家" + nowPlayer + "選擇的角色是強盜";
                    break;
                case 2:
                    playerVeiw[i].text = "玩家" + nowPlayer + "選擇的角色是爸爸";
                    break;
                case 3:
                    playerVeiw[i].text = "玩家" + nowPlayer + "選擇的角色是畫家";
                    break;
                case 4:
                    playerVeiw[i].text = "玩家" + nowPlayer + "選擇的角色是企業家";
                    break;
                case 5:
                    playerVeiw[i].text = "玩家" + nowPlayer + "選擇的角色是搗蛋鬼";
                    break;
                case 6:
                    playerVeiw[i].text = "玩家" + nowPlayer + "選擇的角色是小偷";
                    break;
                case 7:
                    playerVeiw[i].text = "玩家" + nowPlayer + "選擇的角色是演員";
                    break;
                case 8:
                    playerVeiw[i].text = "玩家" + nowPlayer + "選擇的角色是魔術師";
                    break;

                default:
                    playerVeiw[i].text = "玩家" + nowPlayer + "選擇的角色是賭徒";
                    break;

            }          
        }
    }



    public void GoToSceneChoosebtt()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToSceneGamebtt()
    {
        CardAni.GetComponent<Animation>().Play("test");
        Invoke("InvokeToSceneGame", 8.5f);
    }

    void InvokeToSceneGame()
    {
        SceneManager.LoadScene(4);
    }
}
