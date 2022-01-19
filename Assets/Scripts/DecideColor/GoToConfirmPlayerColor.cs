using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToConfirmPlayerColor : MonoBehaviour
{
    public GameObject Warning_Window;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);

        Warning_Window.SetActive(false);
    }

    private void OnClick()
    {
        if (VarColor.temp < PlayerNumber.playerNumber)
        {
            Warning_Window.GetComponent<Animation>().Play("Fadeout");
            Warning_Window.SetActive(true);
        }else
            SceneManager.LoadScene(3);

        
            
    }
    
    public void TurnOffWarning()
    {
        Warning_Window.SetActive(false);
    }
}

