using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class TouchMove : MonoBehaviour
{
    float OffsetX;
    float OffsetY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.Log("觸碰座標: "+ Input.mousePosition+"小紅點座標: "+ gameObject.transform.position);

        /*if (Input.touchCount == 1)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OffsetX = gameObject.transform.position.x - Input.mousePosition.x; ;
                OffsetY = gameObject.transform.position.y - Input.mousePosition.y; ; 
            }

            if (Input.GetMouseButton(0))
            {  
                gameObject.transform.position = new Vector3(Input.mousePosition.x + OffsetX, Input.mousePosition.y + OffsetY);
            }
            
            if (Input.GetMouseButton(0))
            {

            }
               


        }
        Debug.Log(gameObject.transform.position);
        讓物件在update涵式=>物件位置=左鍵持續按的位置
        */
    }

    void FixedUpdate()
    {
        if (Input.touchCount == 1)
            //gameObject.transform.position = Input.mousePosition;
            gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);



    }



    
}

