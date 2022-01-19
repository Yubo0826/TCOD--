using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticNumb : MonoBehaviour
{
    public RectTransform OpenStatisticPanel_rect;
    public Image[] plyerJobImage;
    public Text[] countPlayer;
    public static float[] totalGroundPlayer=new float[6];

    public GameObject char5_GO;
    public GameObject char6_GO;

    Vector3 ini_panel;

    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerNumber.playerNumber)
        {
            case 4:
                char5_GO.SetActive(false);
                char6_GO.SetActive(false);
                break;
            case 5:
                char6_GO.SetActive(false);
                break;
        }

        ini_panel = OpenStatisticPanel_rect.anchoredPosition;

        int i = 0;
        while(i < PlayerNumber.playerNumber)
        {
            plyerJobImage[i].gameObject.SetActive(true);
            i++;
        }

        for (int k = 0; k < 5; k++)
            totalGroundPlayer[k] = 0;

        ImageResourse();
    }


    // Update is called once per frame
    void Update()
    {
        for(int i=0;i< PlayerNumber.playerNumber; i++)
        {
            countPlayer[i].text = totalGroundPlayer[i].ToString();
        }
    }


    public void openStatisticPanel()
    {
        OpenStatisticPanel_rect.anchoredPosition = new Vector2(550, -242.3f);
    }



    public void closeStatisticPanel()
    {
        OpenStatisticPanel_rect.anchoredPosition = ini_panel;
    }



    void ImageResourse()
    {
        for (int i = 0; i < PlayerNumber.playerNumber; i++)
        {
            switch (VarColor.playerColor[i])
            {
                case 1:
                    plyerJobImage[i].sprite = Resources.Load("Charactor/卡卡_190423_0015", typeof(Sprite)) as Sprite;
                    break;
                // NOTE:圖片路徑不用加.jpq之類的 //
                case 2:
                    plyerJobImage[i].sprite = Resources.Load("Charactor/卡卡_190423_0011", typeof(Sprite)) as Sprite;
                    break;

                case 3:
                    plyerJobImage[i].sprite = Resources.Load("Charactor/卡卡_190423_0016", typeof(Sprite)) as Sprite;
                    break;

                case 4:
                    plyerJobImage[i].sprite = Resources.Load("Charactor/卡卡_190423_0019", typeof(Sprite)) as Sprite;
                    break;

                case 5:
                    plyerJobImage[i].sprite = Resources.Load("Charactor/卡卡_190423_0017", typeof(Sprite)) as Sprite;
                    break;

                case 6:
                    plyerJobImage[i].sprite = Resources.Load("Charactor/卡卡_190423_0018", typeof(Sprite)) as Sprite;
                    break;

                case 7:
                    plyerJobImage[i].sprite = Resources.Load("Charactor/卡卡_190423_0012", typeof(Sprite)) as Sprite;
                    break;

                case 8:
                    plyerJobImage[i].sprite = Resources.Load("Charactor/卡卡_190423_0014", typeof(Sprite)) as Sprite;
                    break;

                default:
                    plyerJobImage[i].sprite = Resources.Load("Charactor/卡卡_190423_0013", typeof(Sprite)) as Sprite;
                    break;

            }
        }
    }
}
