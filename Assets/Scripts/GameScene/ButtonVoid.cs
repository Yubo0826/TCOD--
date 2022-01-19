using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonVoid : MonoBehaviour
{
    public GameObject YellowRegion;
    public GameObject BlueRegion;
    public GameObject RedRegion;

    public RectTransform ZoomRectTrans;
    public RectTransform NextPlayerRectTrans;
    public RectTransform DrawingRectTrans;
    public RectTransform EraseringRectTrans; 
    //public RectTransform ReturnHomeRectTrans;
    public RectTransform RemindModel_Text_Trans;
    //public RectTransform OpenMenu_Rect;

    public GameObject ZoomButton;
    public GameObject NextPlayerButton;
    public GameObject LastPlayerButton;
    public GameObject DrawingButton;
    public GameObject EraseringButton;
    public GameObject EraserCardButton;
    public GameObject OpenInputPlaneBtt;
    public GameObject OpenStatisticPanelBtt;
    public GameObject nowlastNumImage;
    public GameObject TroubleButton;
    public GameObject EraserCardBtt;
    public GameObject WarningWin_Panel;
    public GameObject EraserCard_ani;
    public GameObject Cwk_ani;
    public GameObject black_bg;
    public GameObject smallMenu;
    public GameObject OpenMenu;
    public GameObject Yellow_block;
    public GameObject Red_block;
    public GameObject Blue_block;

    public AudioSource CharacterSound;
    public AudioSource BGM;

    public Image CurrentPlayerImg;
    public Image DrawingImg;
    public Image EraseringImg;
    public Image SoundImg;

    public Text RemindModel_Text;

    public static int Game_Phase;
    public static bool Can_Draw=false;
    public static bool Can_Erase=false;
    public static bool Can_Erase_Card = false;

    public static int nowPlayer; //輪到第"i"位玩家
    public static int totalRound; //遊戲進行多少回合，配合boxtransform.cs

    bool Is_sound=true;
    

    Vector3 intiNextPlayerButton;
    Vector3 intiReturnHomeButton;

    void Start()
    { 
        ZoomButton.SetActive(false);
        DrawingButton.SetActive(false);
        EraseringButton.SetActive(false);
        WarningWin_Panel.gameObject.SetActive(false);
        smallMenu.gameObject.SetActive(false);

        Camera.main.transform.position = new Vector3(291.9f, 165.1f, -10);
        Camera.main.orthographicSize = 223.8f;
        //WarningWin_Rect.anchoredPosition = new Vector3(361.16f, 225.16f, 0f);

        //按鈕儲存起始位置
        intiNextPlayerButton = NextPlayerRectTrans.anchoredPosition;
        //intiReturnHomeButton = ReturnHomeRectTrans.anchoredPosition;

        //選擇區域階段
        Game_Phase = 1;

        nowPlayer = 0;
        totalRound = 1;
        CurrentPlayer();

        //主選單BGM關閉
        GameObject bgmInstance;
        bgmInstance = GameObject.FindGameObjectWithTag("sound");
        Destroy(bgmInstance);

        Invoke("BGM_Go", 3f);
    }

    void BGM_Go()
    {
        BGM.Play();
    }

    private void Update()
    {
        //Debug.Log("NOWPLAY: " + VarColor.playerColor[ButtonVoid.nowPlayer]);

        if (Can_Erase_Card == true)
            EraserCardBtt.GetComponent<Animation>().Play("UsingEraserCard");
        else
            EraserCardBtt.GetComponent<Animation>().Stop("UsingEraserCard");

    }

    public void Yellow_Region()
    {
        Game_Phase = 2;  //進入區域階段
        Can_Draw = true;
        DrawingImg.sprite = Resources.Load("Charactor/畫面6_畫筆模式", typeof(Sprite)) as Sprite;

        if (Can_Erase_Card == true || InputNumber.troubleModel == true)
        {
            EraseringButton.GetComponent<Button>().enabled=false;
            DrawingButton.GetComponent<Button>().enabled = false;

            EraseringButton.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            DrawingButton.GetComponent<Image>().color = new Color32(200, 200, 200, 255);

            if(Can_Erase_Card == true)
            RemindModel_Text.text = "~使用橡皮擦道具卡中~";
            else
                RemindModel_Text.text = "~被搗蛋鬼搞鬼中~";
        }

        ZoomButton.SetActive(true);
        DrawingButton.SetActive(true);
        EraseringButton.SetActive(true);
        Blue_block.SetActive(false);
        Red_block.SetActive(false);
        
        NextPlayerButton.SetActive(false);
        YellowRegion.gameObject.SetActive(false);
        BlueRegion.gameObject.SetActive(false);
        RedRegion.gameObject.SetActive(false);
        OpenInputPlaneBtt.gameObject.SetActive(false);
        CurrentPlayerImg.gameObject.SetActive(false);
        nowlastNumImage.gameObject.SetActive(false);
        OpenStatisticPanelBtt.gameObject.SetActive(false);
        TroubleButton.gameObject.SetActive(false);
        EraserCardBtt.gameObject.SetActive(false);
        LastPlayerButton.gameObject.SetActive(false);
        OpenMenu.gameObject.SetActive(false);


        //鏡頭位置、縮放
        Camera.main.transform.position= new Vector3(114f, 276.87f, -10);
        Camera.main.orthographicSize = 112f;

        //按鈕位置
        ZoomRectTrans.anchoredPosition = new Vector3(-310, 186, 0);
        //NextPlayerRectTrans.anchoredPosition = new Vector3(-210, 70, 0);
        //ReturnHomeRectTrans.anchoredPosition= new Vector3(-210, 10, 0);
        DrawingRectTrans.anchoredPosition = new Vector3(-310, 90, 0);
        EraseringRectTrans.anchoredPosition= new Vector3(-310, -30, 0);
        RemindModel_Text_Trans.anchoredPosition = new Vector3(-310, -162.2f, 0f);
        //WarningWin_Rect.anchoredPosition= new Vector3(-374f, 225.16f, 0f);

        if (Can_Erase_Card == false)
            InputNumber.nowNumber = InputNumber.DrawNumber;
    }

    public void Blue_Region()
    {
        Game_Phase = 2;  //進入區域階段
        Can_Draw = true;
        DrawingImg.sprite = Resources.Load("Charactor/畫面6_畫筆模式", typeof(Sprite)) as Sprite;

        if (Can_Erase_Card == true || InputNumber.troubleModel == true)
        {
            EraseringButton.GetComponent<Button>().enabled = false;
            DrawingButton.GetComponent<Button>().enabled = false;

            EraseringButton.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            DrawingButton.GetComponent<Image>().color = new Color32(200, 200, 200, 255);

            if (Can_Erase_Card == true)
                RemindModel_Text.text = "~使用橡皮擦道具卡中~";
            else
                RemindModel_Text.text = "~被搗蛋鬼搞鬼中~";
        }

        ZoomButton.SetActive(true);
        DrawingButton.SetActive(true);
        EraseringButton.SetActive(true);
        Yellow_block.SetActive(false);
        Red_block.SetActive(false);

        NextPlayerButton.SetActive(false);
        YellowRegion.gameObject.SetActive(false);
        BlueRegion.gameObject.SetActive(false);
        RedRegion.gameObject.SetActive(false);
        OpenInputPlaneBtt.gameObject.SetActive(false);
        CurrentPlayerImg.gameObject.SetActive(false);
        nowlastNumImage.gameObject.SetActive(false);
        OpenStatisticPanelBtt.gameObject.SetActive(false);
        TroubleButton.gameObject.SetActive(false);
        EraserCardBtt.gameObject.SetActive(false);
        LastPlayerButton.gameObject.SetActive(false);
        OpenMenu.gameObject.SetActive(false);
        smallMenu.gameObject.SetActive(false);

        Camera.main.transform.position = new Vector3(475f, 276.87f, -10);
        Camera.main.orthographicSize = 112f;

        ZoomRectTrans.anchoredPosition = new Vector3(303, 186, 0);
        //NextPlayerRectTrans.anchoredPosition = new Vector3(196, 70, 0);
        //ReturnHomeRectTrans.anchoredPosition = new Vector3(196, 10, 0);
        DrawingRectTrans.anchoredPosition = new Vector3(303, 90, 0);
        EraseringRectTrans.anchoredPosition = new Vector3(303, -30, 0);
        RemindModel_Text_Trans.anchoredPosition = new Vector3(303, -162.2f, 0f);
        //WarningWin_Rect.anchoredPosition = new Vector3(361.16f, 225.16f, 0f);

        if (Can_Erase_Card == false)
            InputNumber.nowNumber = InputNumber.DrawNumber;
    }

    public void Red_Region()
    {
        Game_Phase = 2;  //進入區域階段
        Can_Draw = true;
        DrawingImg.sprite = Resources.Load("Charactor/畫面6_畫筆模式", typeof(Sprite)) as Sprite;

        if (Can_Erase_Card == true || InputNumber.troubleModel == true)
        {
            EraseringButton.GetComponent<Button>().enabled = false;
            DrawingButton.GetComponent<Button>().enabled = false;

            EraseringButton.GetComponent<Image>().color = new Color32(200, 200, 200, 255);
            DrawingButton.GetComponent<Image>().color = new Color32(200, 200, 200, 255);

            if (Can_Erase_Card == true)
                RemindModel_Text.text = "~使用橡皮擦道具卡中~";
            else
                RemindModel_Text.text = "~被搗蛋鬼搞鬼中~";
        }

        ZoomButton.SetActive(true);
        DrawingButton.SetActive(true);
        EraseringButton.SetActive(true);
        Yellow_block.SetActive(false);
        Blue_block.SetActive(false);
 
        NextPlayerButton.SetActive(false);
        YellowRegion.gameObject.SetActive(false);
        BlueRegion.gameObject.SetActive(false);
        RedRegion.gameObject.SetActive(false);
        OpenInputPlaneBtt.gameObject.SetActive(false);
        CurrentPlayerImg.gameObject.SetActive(false);
        nowlastNumImage.gameObject.SetActive(false);
        OpenStatisticPanelBtt.gameObject.SetActive(false);
        TroubleButton.gameObject.SetActive(false);
        EraserCardBtt.gameObject.SetActive(false);
        LastPlayerButton.gameObject.SetActive(false);
        OpenMenu.gameObject.SetActive(false);
        smallMenu.gameObject.SetActive(false);

        Camera.main.transform.position = new Vector3(114f, 53f, -10);
        Camera.main.orthographicSize = 112f;

        ZoomRectTrans.anchoredPosition = new Vector3(-310, 186, 0);
        //NextPlayerRectTrans.anchoredPosition = new Vector3(-210, 70, 0);
        //ReturnHomeRectTrans.anchoredPosition = new Vector3(-210, 10, 0);
        DrawingRectTrans.anchoredPosition = new Vector3(-310, 90, 0);
        EraseringRectTrans.anchoredPosition = new Vector3(-310, -30, 0);
        RemindModel_Text_Trans.anchoredPosition = new Vector3(-310, -162.2f, 0f);
        //WarningWin_Rect.anchoredPosition = new Vector3(-158f, 225.16f, 0f);

        if (Can_Erase_Card == false)
            InputNumber.nowNumber = InputNumber.DrawNumber;
    }

    public void Zoom_Button()
    {
        Game_Phase = 1;  //進入選擇區域階段

        ZoomButton.SetActive(false);
        DrawingButton.SetActive(false);
        EraseringButton.SetActive(false);
        smallMenu.gameObject.SetActive(false);
        Blue_block.gameObject.SetActive(true);
        Yellow_block.gameObject.SetActive(true);
        Red_block.gameObject.SetActive(true);

        NextPlayerButton.SetActive(true);
        YellowRegion.gameObject.SetActive(true);
        RedRegion.gameObject.SetActive(true);
        BlueRegion.gameObject.SetActive(true);
        OpenInputPlaneBtt.gameObject.SetActive(true);
        CurrentPlayerImg.gameObject.SetActive(true);
        nowlastNumImage.gameObject.SetActive(true);
        OpenStatisticPanelBtt.gameObject.SetActive(true);
        TroubleButton.gameObject.SetActive(true);
        EraserCardBtt.gameObject.SetActive(true);
        LastPlayerButton.gameObject.SetActive(true);
        OpenMenu.gameObject.SetActive(true);
        

        RemindModel_Text.text = "";

        EraseringButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        DrawingButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

        EraseringButton.GetComponent<Button>().enabled = true;
        DrawingButton.GetComponent<Button>().enabled = true;

        DrawingImg.sprite = Resources.Load("Charactor/畫面6_畫筆", typeof(Sprite)) as Sprite;
        EraseringImg.sprite = Resources.Load("Charactor/畫面6_像橡皮擦", typeof(Sprite)) as Sprite;

        Can_Draw = false;
        Can_Erase = false;
        
        Camera.main.transform.position = new Vector3(291.9f,165.1f,-10);
        Camera.main.orthographicSize = 223.8f;
        //WarningWin_Rect.anchoredPosition = new Vector3(361.16f, 225.16f, 0f);

        NextPlayerRectTrans.anchoredPosition = intiNextPlayerButton;
        //ReturnHomeRectTrans.anchoredPosition = intiReturnHomeButton;


    }

    public void Next_Player_Button()
    {
        if(nowPlayer < PlayerNumber.playerNumber-1)
        nowPlayer++;                           
        else
        nowPlayer=0;

        totalRound++;

        Debug.Log(nowPlayer);
        if(InputNumber.troubleModel==false)
        InputNumber.lastNumber = InputNumber.DrawNumber;

        InputNumber.DrawNumber = 0;
        InputNumber.DigitNum =new float[99];

        InputNumber.troubleModel = false;
        Can_Erase_Card = false;

        CurrentPlayer();//更換現在回合玩家圖片
        CharacterSounds();//音效
    }


    public void Last_Player_Button()
    {

        if (nowPlayer > 0)
            nowPlayer--;
        else
            nowPlayer = PlayerNumber.playerNumber - 1;

        totalRound--;

        Debug.Log(nowPlayer);
        if (InputNumber.troubleModel == false)
            InputNumber.lastNumber = InputNumber.DrawNumber;

        InputNumber.DrawNumber = 0;
        InputNumber.DigitNum = new float[99];

        InputNumber.troubleModel = false;
        Can_Erase_Card = false;

        CurrentPlayer();//更換現在回合玩家圖片
        CharacterSounds();//音效
    }



    public void Drawing_Button()
    {
        DrawingImg.sprite = Resources.Load("Charactor/畫面6_畫筆模式", typeof(Sprite)) as Sprite;
        EraseringImg.sprite = Resources.Load("Charactor/畫面6_像橡皮擦", typeof(Sprite)) as Sprite;
        Can_Draw = true;
        Can_Erase = false;
    }
    
    public void Erasering_Button()
    {
        DrawingImg.sprite = Resources.Load("Charactor/畫面6_畫筆", typeof(Sprite)) as Sprite;
        EraseringImg.sprite = Resources.Load("Charactor/畫面6_橡皮擦模式", typeof(Sprite)) as Sprite;
        Can_Erase = true;
        Can_Draw = false;
    }

    public void EraserCard_Button()
    {
        if(Can_Erase_Card == false)
        {
            Cwk_ani.gameObject.SetActive(true);
            black_bg.gameObject.SetActive(true);
            EraserCard_ani.GetComponent<Animation>().Play("Eraser");
            Cwk_ani.GetComponent<Animator>().SetBool("put", true);
            Invoke("EraserCardAni", 2.2f);

            InputNumber.troubleModel = false;
            InputNumber.nowNumber = 15;     //橡皮擦道具卡使用一次能擦掉場上所有區域15格    
            Can_Erase_Card = true;
        }    
        else
            Can_Erase_Card = false; 
    }

    void EraserCardAni()
    {
        EraserCard_ani.GetComponent<Animation>().Stop("Trouble");
        Cwk_ani.gameObject.SetActive(false);
        black_bg.gameObject.SetActive(false);
    }

    public void OpenWarningWindow()
    {
        WarningWin_Panel.gameObject.SetActive(true);
    }

    public void CloseWarningWindow()
    {
        WarningWin_Panel.gameObject.SetActive(false);
    }

    public void OpenSmallMenu()
    {
        smallMenu.gameObject.SetActive(true);
    }

    public void CloseSmallMenu()
    {
        smallMenu.gameObject.SetActive(false);
    }

    public void Return_Home_Button()
    {
        NotDestroyBGM.SoundStart = false;
        SceneManager.LoadScene(0);
    }

    public void ControlSound()
    {
        if(Is_sound == true)
        {
            SoundImg.sprite = Resources.Load("選單_關閉聲音", typeof(Sprite)) as Sprite;
            Is_sound = false;
            BGM.Pause();
        }
        else
        {
            SoundImg.sprite = Resources.Load("選單_開啟聲音", typeof(Sprite)) as Sprite;
            Is_sound = true;
            BGM.UnPause();
        }
        

    }

    void CurrentPlayer()
    {  
            switch (VarColor.playerColor[nowPlayer])
            {
                case 1:
                    CurrentPlayerImg.sprite = Resources.Load("Charactor/卡卡_190423_0015", typeof(Sprite)) as Sprite;
                    break;
                // NOTE:圖片路徑不用加.jpq之類的 //
                case 2:
                    CurrentPlayerImg.sprite = Resources.Load("Charactor/卡卡_190423_0011", typeof(Sprite)) as Sprite;
                    break;

                case 3:
                    CurrentPlayerImg.sprite = Resources.Load("Charactor/卡卡_190423_0016", typeof(Sprite)) as Sprite;
                    break;

                case 4:
                    CurrentPlayerImg.sprite = Resources.Load("Charactor/卡卡_190423_0019", typeof(Sprite)) as Sprite;
                    break;

                case 5:
                    CurrentPlayerImg.sprite = Resources.Load("Charactor/卡卡_190423_0017", typeof(Sprite)) as Sprite;
                    break;

                case 6:
                    CurrentPlayerImg.sprite = Resources.Load("Charactor/卡卡_190423_0018", typeof(Sprite)) as Sprite;
                    break;

                case 7:
                    CurrentPlayerImg.sprite = Resources.Load("Charactor/卡卡_190423_0012", typeof(Sprite)) as Sprite;
                    break;

                case 8:
                    CurrentPlayerImg.sprite = Resources.Load("Charactor/卡卡_190423_0014", typeof(Sprite)) as Sprite;
                    break;

                default:
                    CurrentPlayerImg.sprite = Resources.Load("Charactor/卡卡_190423_0013", typeof(Sprite)) as Sprite;
                    break;

            }
        
    }


    void CharacterSounds()
    {
        switch (VarColor.playerColor[nowPlayer])
        {
            case 1:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/職業/強盜/4", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 2:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/職業/爸爸/3", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 3:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/職業/畫家/5", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 4:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/職業/企業家/2", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 5:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/職業/搗蛋鬼/6", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 6:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/職業/小偷/1", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 7:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/職業/演員/7", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 8:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/職業/魔術師/9", typeof(AudioClip));
                CharacterSound.Play();
                break;

            default:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/職業/賭徒/8", typeof(AudioClip));
                CharacterSound.Play();
                break;

        }
    }
}
