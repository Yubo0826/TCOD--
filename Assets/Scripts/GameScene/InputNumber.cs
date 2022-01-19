using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputNumber : MonoBehaviour
{
    public GameObject InputPanel;
    public GameObject TroubleMaker_btt;
    public GameObject TroubleMaker_ani;
    public GameObject Cwk_ani;
    public GameObject Bat_ani;
    public GameObject black_bg;
    public Text Number_text;

    public AudioSource Trouble_sound;

    public Text mainNowNumber_text;
    public Text regionNowNumber_text;
    public Text lastNumber_text;
    public RectTransform mainNowNumRect_text;
    public RectTransform regionNowNumRect_text;
    public RectTransform lastNowNumRect_text;

    public static float DrawNumber;   //玩家輸入的格數
    public static float[] DigitNum = new float[99];   //每一位數的數字
    public static float nowNumber;
    public static float lastNumber;

    public static bool troubleModel=false;

    int digits;  //位數


    /*快速測試用
    private void Awake()
    {
        /// test ///
        /// 
        PlayerNumber.playerNumber = 6;
        VarColor.playerColor = new int[PlayerNumber.playerNumber];
        VarColor.playerColor[0] = 0;
        VarColor.playerColor[1] = 1;
        VarColor.playerColor[2] = 2;
        VarColor.playerColor[3] = 3;
        VarColor.playerColor[4] = 4;
        VarColor.playerColor[5] = 5;
    }
    */
    /// Start ///
    private void Start()
    {
        InputPanel.gameObject.SetActive(false);
        mainNowNumber_text.gameObject.SetActive(true);
        lastNumber_text.gameObject.SetActive(true);
        regionNowNumber_text.gameObject.SetActive(false);
        TroubleMaker_btt.SetActive(true);
        DrawNumber = 0;
        lastNumber = 0;
        digits = -1;

        for (int i = 0; i < PlayerNumber.playerNumber; i++)
            if (VarColor.playerColor[i] == 5)
                TroubleMaker_btt.SetActive(true);

    }

    /// Update ///
    private void Update()
    {
        Number_text.text = DrawNumber.ToString();
        regionNowNumber_text.text = nowNumber.ToString();      
        lastNumber_text.text = lastNumber.ToString();
        mainNowNumber_text.text = DrawNumber.ToString();

        if(troubleModel ==true)
            TroubleMaker_btt.GetComponent<Animation>().Play("UsingCardAbility");
        else
            TroubleMaker_btt.GetComponent<Animation>().Stop("UsingCardAbility");
    }

    //// 搗蛋鬼技能 ////
    public void Troublemaker()   
    {   
        if(troubleModel == false)
        {
            Cwk_ani.gameObject.SetActive(true);
            black_bg.gameObject.SetActive(true);
            //Bat_ani.gameObject.SetActive(true);
            TroubleMaker_ani.GetComponent<Animation>().Play("Trouble");
            Bat_ani.GetComponent<Animator>().SetBool("put", true);
            Cwk_ani.GetComponent<Animator>().SetBool("put", true);

            Trouble_sound.clip = (AudioClip)Resources.Load("配音/台詞/搗蛋鬼/葉靜", typeof(AudioClip));
            Trouble_sound.Play();
            Invoke("TroubleAni", 3.5f);
            troubleModel = true;
            ButtonVoid.Can_Erase_Card = false;
        }else
            troubleModel = false;
    }

    void TroubleAni()
    {
        InputPanel.gameObject.SetActive(true);
        Bat_ani.GetComponent<Animator>().SetBool("put", false);
        //Cwk_ani.GetComponent<Animator>().SetBool("put", false);
        TroubleMaker_ani.GetComponent<Animation>().Stop("Trouble");
        //Bat_ani.gameObject.SetActive(false);
        Cwk_ani.gameObject.SetActive(false);
        black_bg.gameObject.SetActive(false);   
    }


    public void OpenInputPanel()
    {
        InputPanel.gameObject.SetActive(true);
        digits = -1;
    }

    public void CloseInputPanel()
    {
        InputPanel.gameObject.SetActive(false);
        troubleModel = false;
    }

    public void Confirm_numberBtt()
    {
        InputPanel.gameObject.SetActive(false);

        //把主頁輸入的格數assign給 Region
        nowNumber = DrawNumber;
        
    }

    public void Back_numberBtt()
    {
        DrawNumber = 0;
        DigitNum[digits] = 0;
        digits--;
        for (int i = digits, k = 0; i >= 0 && k <= digits; i--, k++)
        {
            DrawNumber = DrawNumber + DigitNum[k] * Mathf.Pow(10f, i);
        }
    }


    public void One_numberBtt()
    {
        CountNumber(1);
    }

    public void Two_numberBtt()
    {
        CountNumber(2);
    }

    public void Three_numberBtt()
    {
        CountNumber(3);
    }

    public void Four_numberBtt()
    {
        CountNumber(4);
    }

    public void Five_numberBtt()
    {
        CountNumber(5);
    }

    public void Six_numberBtt()
    {
        CountNumber(6);
    }

    public void Senve_numberBtt()
    {
        CountNumber(7);
    }

    public void Eight_numberBtt()
    {
        CountNumber(8);
    }

    public void Nine_numberBtt()
    {
        CountNumber(9);
    }

    public void Zero_numberBtt()
    {
        CountNumber(0);
    }
    
    void CountNumber(int a) {
        if (digits < 4)
        {
            DrawNumber = 0;
            digits++;
            DigitNum[digits] = a;
            for (int i = digits, k = 0; i >= 0 && k <= digits; i--, k++)
            {
                DrawNumber = DrawNumber + DigitNum[k] * Mathf.Pow(10f, i);
            }
            //Number_text.text = DrawNumber.ToString();
        }
    }

    public void YellowregionSetActive()
    {
        mainNowNumber_text.gameObject.SetActive(false);
        lastNumber_text.gameObject.SetActive(false);
        regionNowNumber_text.gameObject.SetActive(true);

        regionNowNumRect_text.anchoredPosition = new Vector3(-169.56f, 130, 0f);
    }

    public void RedregionSetActive()
    {
        mainNowNumber_text.gameObject.SetActive(false);
        lastNumber_text.gameObject.SetActive(false);
        regionNowNumber_text.gameObject.SetActive(true);

        regionNowNumRect_text.anchoredPosition = new Vector3(-169.56f, 150f, 0f);
    }

    public void BlueregionSetActive()
    {
        mainNowNumber_text.gameObject.SetActive(false);
        lastNumber_text.gameObject.SetActive(false);
        regionNowNumber_text.gameObject.SetActive(true);

        regionNowNumRect_text.anchoredPosition = new Vector3(166.7f, 130f, 0f);
    }

    public void ZoomSetActive()
    {
        mainNowNumber_text.gameObject.SetActive(true);
        lastNumber_text.gameObject.SetActive(true);
        regionNowNumber_text.gameObject.SetActive(false);

    }
}
