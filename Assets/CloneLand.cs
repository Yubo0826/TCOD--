using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneLand : MonoBehaviour
{
    public GameObject Land;
    private GameObject EmLand;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=1 ; i<15 ; i++)
        {
            for(int j=1; j<15 ; j++)
            {
                /*EmLand = GameObject.Find("EmLand");
                EmLand.transform.parent = Land.transform;
                EmLand.transform.localPosition = Land.transform.position + new Vector3(12.84f * j, 0 - 12.84f * (i - 1), 0);
                EmLand.name = "EmLand";
                EmLand.AddComponent<Boxtransform>();
                */
                //Instantiate(Land, Land.transform.position + new Vector3(12.84f * j, 0 - 12.84f * (i - 1), 0), Land.transform.rotation);
            }
            
            //Instantiate(Land, Land.transform.position + new Vector3(0, 12.84f*i, 0), Land.transform.rotation);
        }

        //Instantiate(Land, Land.transform.position+new Vector3(12.84f,0,0), Land.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
