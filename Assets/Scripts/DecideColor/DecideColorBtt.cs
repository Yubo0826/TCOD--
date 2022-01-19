using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DecideColorBtt : MonoBehaviour
{
    public Text numPlayer;
    public Button[] bttn;
    public AudioSource CharacterSound;

    private int nowNoPlay;

    private void Start()
    {
        VarColor.temp = 0;
        VarColor.playerColor = new int[PlayerNumber.playerNumber];
    }

    private void Update()
    {
        
    }

    public void RetryBtt()
    {
        VarColor.temp = 0;
        VarColor.playerColor = new int[PlayerNumber.playerNumber];
        numPlayer.text = "玩家1選擇:";

        for(int i=0;i<9;i++)
        bttn[i].GetComponent<Image>().color = new Color(255,255,255,255);
    }

    public void LastSceneBtt()
    {
        SceneManager.LoadScene(1);
    }

    public void DecideColorBtn()
    {
        if (VarColor.temp < PlayerNumber.playerNumber)  //先判斷VarColor.temp有沒有小於遊玩人數，如果大於就顯示"玩家人數已滿"
        {
            if (VarColor.temp != 0)
            {
                int k = 0;
                for (int i = 0; i <VarColor.temp; i++) //一一檢查顏色陣列有沒有重複的顏色，k=0沒有重複
                {
                    if (VarColor.playerColor[i] != ScrollRectSnap.minButtonNum)
                        k = 0;
                    else
                    {
                        k = 1;
                        break;
                    }
                        
                }


                if (k == 0)
                {
                    VarColor.playerColor[VarColor.temp] = ScrollRectSnap.minButtonNum;   
                    bttn[ScrollRectSnap.minButtonNum].GetComponent<Image>().color = Color.gray;//選過的卡片顏色變灰表示選過
                    Textplayercolor(ScrollRectSnap.minButtonNum,VarColor.temp+1);
                    Debug.Log("已選擇" + VarColor.playerColor[VarColor.temp]);
                    VarColor.temp++;


                    //確定完角色音效
                    CharacterSounds(ScrollRectSnap.minButtonNum);
                }
                else
                {
                    numPlayer.text = "這個角色已選過";
                }
            }
            else
            {
                VarColor.playerColor[VarColor.temp] = ScrollRectSnap.minButtonNum;
                bttn[ScrollRectSnap.minButtonNum].GetComponent<Image>().color = Color.gray;
                Textplayercolor(ScrollRectSnap.minButtonNum, VarColor.temp + 1);
                Debug.Log("已選擇" + VarColor.playerColor[VarColor.temp]);
                VarColor.temp++;
                //確定完角色音效
                CharacterSounds(ScrollRectSnap.minButtonNum);
            }


        }

        

        if (VarColor.temp == PlayerNumber.playerNumber)
        {
            Invoke("GoToNextScene", 4f);
        }
            
    }

    void GoToNextScene()
    {
        SceneManager.LoadScene(3);
    }


    void Textplayercolor(int i ,int k)
    {
        int nowPlayer = k;
            switch (i)
            {
                case 1:
                    numPlayer.text = "玩家" + nowPlayer + "選擇強盜";
                    break;
                case 2:
                    numPlayer.text = "玩家" + nowPlayer + "選擇爸爸";
                    break;
                case 3:
                    numPlayer.text = "玩家" + nowPlayer + "選擇畫家";
                    break;
                case 4:
                    numPlayer.text = "玩家" + nowPlayer + "選擇企業家";
                    break;
                case 5:
                    numPlayer.text = "玩家" + nowPlayer + "選擇搗蛋鬼";
                    break;
                case 6:
                    numPlayer.text = "玩家" + nowPlayer + "選擇小偷";
                    break;
                case 7:
                    numPlayer.text = "玩家" + nowPlayer + "選擇演員";
                    break;
                case 8:
                    numPlayer.text = "玩家" + nowPlayer + "選擇魔術師";
                    break;

                default:
                    numPlayer.text = "玩家" + nowPlayer + "選擇賭徒";
                    break;

            }
        
    }

    void CharacterSounds(int i)
    {
        switch (i)
        {
            case 1:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/台詞/強盜/哥哥", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 2:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/台詞/爸爸/東遠", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 3:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/台詞/畫家/雅Gok", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 4:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/台詞/企業家/金穠", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 5:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/台詞/搗蛋鬼/葉靜", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 6:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/台詞/小偷/英瑑", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 7:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/台詞/演員/茵淇ok", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 8:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/台詞/魔術師/金穠", typeof(AudioClip));
                CharacterSound.Play();
                break;

            default:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/台詞/賭徒/英瑑", typeof(AudioClip));
                CharacterSound.Play();
                break;

        }
    }
}
