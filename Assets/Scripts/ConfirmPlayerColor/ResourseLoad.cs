using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourseLoad : MonoBehaviour
{
    public Image[] char_image;

    public GameObject char5_image_GO;
    public GameObject char6_image_GO;

    void Start()
    {
        switch (PlayerNumber.playerNumber)
        {
            case 4:
                char5_image_GO.SetActive(false);
                char6_image_GO.SetActive(false);
                break;
            case 5:
                char6_image_GO.SetActive(false);
                break;
        }



        for(int i = 0; i < PlayerNumber.playerNumber; i++)
        {
            switch (VarColor.playerColor[i]) 
            {
                case 1:
                    char_image[i].sprite = Resources.Load("Charactor/卡卡_190423_0015", typeof(Sprite)) as Sprite;
                    break;
                    // NOTE:圖片路徑不用加.jpq之類的 //
                case 2:
                    char_image[i].sprite = Resources.Load("Charactor/卡卡_190423_0011", typeof(Sprite)) as Sprite;
                    break;

                case 3:
                    char_image[i].sprite = Resources.Load("Charactor/卡卡_190423_0016", typeof(Sprite)) as Sprite;
                    break;

                case 4:
                    char_image[i].sprite = Resources.Load("Charactor/卡卡_190423_0019", typeof(Sprite)) as Sprite;
                    break;

                case 5:
                    char_image[i].sprite = Resources.Load("Charactor/卡卡_190423_0017", typeof(Sprite)) as Sprite;
                    break;

                case 6:
                    char_image[i].sprite = Resources.Load("Charactor/卡卡_190423_0018", typeof(Sprite)) as Sprite;
                    break;

                case 7:
                    char_image[i].sprite = Resources.Load("Charactor/卡卡_190423_0012", typeof(Sprite)) as Sprite;
                    break;

                case 8:
                    char_image[i].sprite = Resources.Load("Charactor/卡卡_190423_0014", typeof(Sprite)) as Sprite;
                    break;

                default:
                    char_image[i].sprite = Resources.Load("Charactor/卡卡_190423_0013", typeof(Sprite)) as Sprite;
                    break;

            }
        }
        
    }

    
}
