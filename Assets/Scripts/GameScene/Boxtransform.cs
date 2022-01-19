using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//[RequireComponent(typeof(BoxCollider2D))]
public class Boxtransform : MonoBehaviour
{
    public int i = 1;      // land 的 i=1 ----> 可畫不可擦 ， i=2 ----> 不可畫可擦
    public int id;         // 這個土地是第幾位玩家所佔領的
    public int round;      //這個土地是第幾回合被佔領的
    bool troubleOwn=false;


    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
                                                    /////   畫格子  /////
        if (i == 1 && ButtonVoid.Game_Phase == 2 && ButtonVoid.Can_Draw == true && InputNumber.troubleModel == false
            && ButtonVoid.Can_Erase_Card == false && InputNumber.nowNumber > 0)
        {
            switch (VarColor.playerColor[ButtonVoid.nowPlayer])
            {
                case 1:
                    gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 150, 60, 200);//green
                    break;
                case 2:
                    gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 147, 0, 200);//orange
                    break;
                case 3:
                    gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 200, 255, 200);//greenblue
                    break;
                case 4:
                    gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 235, 0, 200);//yellow
                    break;
                case 5:
                    gameObject.GetComponent<SpriteRenderer>().color = new Color32(210, 0, 0, 200);//red
                    troubleOwn = true;
                    break;
                case 6:
                    gameObject.GetComponent<SpriteRenderer>().color = new Color32(145, 145, 145, 200);//gray
                    break;
                case 7:
                    gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 200, 200);//blue
                    break;
                case 8:
                    gameObject.GetComponent<SpriteRenderer>().color = new Color32(150, 0, 255, 200);//purple
                    break;

                default:
                    gameObject.GetComponent<SpriteRenderer>().color = new Color32(40, 40, 40, 200);//black
                    break;

            }

            i = 2;
            id = ButtonVoid.nowPlayer;
            round = ButtonVoid.totalRound;
            StatisticNumb.totalGroundPlayer[ButtonVoid.nowPlayer]++;
            InputNumber.nowNumber--;
        }



                                           ////   擦格子 (i:1可以擦、2不可以擦  Game_Phase==2:進入顏色區塊後階段) ////

        //橡皮擦模式(只能擦自己的土地) 試用情況:畫錯擦掉
        if (i == 2 && ButtonVoid.Game_Phase == 2 && ButtonVoid.Can_Erase == true && InputNumber.troubleModel == false 
            && ButtonVoid.Can_Erase_Card == false)
        {

            if (round == ButtonVoid.totalRound)
            {    
                if (InputNumber.nowNumber < InputNumber.DrawNumber)
                InputNumber.nowNumber++;

                i = 1;
                StatisticNumb.totalGroundPlayer[id]--;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                Debug.Log("普通橡皮擦模式:");
            }
           
        }

        //搗蛋鬼橡皮擦
        if (i == 2  &&  ButtonVoid.Game_Phase == 2  &&  ButtonVoid.Can_Erase == false  &&
            ButtonVoid.Can_Erase_Card == false  &&  InputNumber.troubleModel==true  &&  troubleOwn == false)
        {
            if (InputNumber.nowNumber > 0)
            {
                i = 1;
                InputNumber.nowNumber--;
                StatisticNumb.totalGroundPlayer[id]--;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                Debug.Log("搗蛋鬼橡皮擦模式:");
            }
                
        }



        //道具卡橡皮擦
        if (i == 2 && ButtonVoid.Game_Phase == 2 && ButtonVoid.Can_Erase == false && ButtonVoid.Can_Erase_Card == true)
        {
            if (InputNumber.nowNumber > 0)
            {
                i = 1;
                InputNumber.nowNumber--;

                if (InputNumber.nowNumber == 0)
                    ButtonVoid.Can_Erase_Card = false;

                StatisticNumb.totalGroundPlayer[id]--;
                gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
                Debug.Log("道具卡橡皮擦模式:");
            }

        }

    }
}
