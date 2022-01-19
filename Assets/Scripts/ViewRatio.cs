using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewRatio : MonoBehaviour
{
    public float baseWidth = 1024;
    public float baseHeight = 768;
    public float baseOrthographicSize = 5;
    public Camera mainCamera;

    void Awake()
    {
        float newOrthographicSize = (float)Screen.height / (float)Screen.width * this.baseWidth / this.baseHeight * this.baseOrthographicSize;
        mainCamera.orthographicSize = Mathf.Max(newOrthographicSize, this.baseOrthographicSize);
    }
}
