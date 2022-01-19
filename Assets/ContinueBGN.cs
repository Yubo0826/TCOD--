using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueBGN : MonoBehaviour
{
    public GameObject bgmPrefab;
    public GameObject bgmInstance = null;
    // Use this for initialization
    void Start()
    {
        bgmInstance = GameObject.FindGameObjectWithTag("sound");
        if (bgmInstance == null)
        {
            bgmInstance = (GameObject)Instantiate(bgmPrefab);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
