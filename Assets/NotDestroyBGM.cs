using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotDestroyBGM : MonoBehaviour
{
    public AudioSource Sound;
    public static bool SoundStart = false;
    // Start is called before the first frame update
    void Start()
    {
        if (SoundStart == false)
        {
            Sound.Play();
            DontDestroyOnLoad(this.gameObject);
            SoundStart = true;
        } 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
