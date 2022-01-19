using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectSnap : MonoBehaviour
{
    public RectTransform panel;       //To hold the ScrollPanel
    public Button[] bttn;
    public RectTransform center;      //Center to compare the distence for each button
    public static int minButtonNum;  //To hold the number of the button, with smallest distence to center
    public AudioSource CharacterSound;

    bool Is_wow_ing = false;
    int current_wow;

    private float[] distance;  //All button's distance to the center
    private float[] distReposition;
    private bool dragging = false;  //Will be true, while we drag the panel
    private int bttnDistance;  //Will hold the distance between the buttons
    private int bttLength;




    private void Start()
    {
        int bttLenght = bttn.Length;    //bttn陣列長度
        distance = new float[bttLenght];   //把distence陣列長度=bttn陣列長度
        distReposition = new float[bttLenght];

        //Get distance between buttons
        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
    }


    private void Update()
    {
        for (int i = 0; i < bttn.Length; i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - bttn[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(center.transform.position.x - bttn[i]. transform.position.x);

            if (distReposition[i] > 1000)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX + (bttLength * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }

            if (distReposition[i] < 1000)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchoredPos = new Vector2(curX - (bttLength * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
            }
        }

        float minDistance = Mathf.Min(distance);  //Get the min distance
        
        for(int a = 0; a < bttn.Length; a++)  
        {
            if (minDistance == distance[a])
            {
                minButtonNum = a;               
                if (current_wow != a)
                {
                    CharacterSounds(a);
                }           
            }
        }

        ////找完離中心最短距離的按鈕////

        if (!dragging)
        {
            LerpToBttn(minButtonNum * -bttnDistance);
        }

        //Debug.Log("minButtonNum:   "+minButtonNum);
    }


    void LerpToBttn(int position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 15f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging = false;
    }


    void CharacterSounds(int i)
    {
        switch (i)
        {
            case 1:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/叫聲/強盜/哥哥", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 2:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/叫聲/爸爸/東遠_咳嗽", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 3:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/叫聲/畫家/雅均", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 4:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/叫聲/企業家/金穠", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 5:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/叫聲/搗蛋鬼/茵淇", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 6:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/叫聲/小偷/柏諭", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 7:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/叫聲/演員/茵淇", typeof(AudioClip));
                CharacterSound.Play();
                break;
            case 8:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/叫聲/魔術師/金穠", typeof(AudioClip));
                CharacterSound.Play();
                break;

            default:
                CharacterSound.clip = (AudioClip)Resources.Load("配音/叫聲/賭徒/英瑑", typeof(AudioClip));
                CharacterSound.Play();
                break;

        }
        current_wow = i;
    }

}
