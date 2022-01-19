using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zoom : MonoBehaviour
{
    public float baseWidth = 1920;
    public float baseHeight = 1080;
    public float baseOrthographicSize = 164.8588f;


    Vector3 touchStart;
    public float zoomOutMin = 1;
    public float zoomOutMax = 8;

    void Awake()
    {
        float newOrthographicSize = (float)Screen.height / (float)Screen.width * this.baseWidth / this.baseHeight * this.baseOrthographicSize;
        //Camera.main.orthographicSize = Mathf.Max(newOrthographicSize, this.baseOrthographicSize);
    }

    void Start()
    {
        //Debug.Log("這是Camera的座標  " + gameObject.transform.position);
    }


    void Update()
    {
        //Input.mousePosition是螢幕座標

        if (Input.GetMouseButtonDown(0) && Input.GetMouseButtonDown(1))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }


        if (Input.touchCount == 2){

            //////////////////////////下方程式碼為縮放
            /* 
             Touch touchZero = Input.GetTouch(0);
             Touch touchOne = Input.GetTouch(1);

             Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
             Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

             //求兩點座標間的距離長度
             float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;   
             float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

             float difference = currentMagnitude - prevMagnitude;

             Zoomm(difference * 0.25f);
             */

            //////////////////////////下方程式碼為移動
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(direction);
            Camera.main.transform.position += direction;
             
        }
        //Zoomm(Input.GetAxis("Mouse ScrollWheel"));
	}

    void Zoomm(float increment){
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, zoomOutMin, zoomOutMax);
    }



   
}



