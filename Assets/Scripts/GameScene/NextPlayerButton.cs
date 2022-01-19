using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPlayerButton : MonoBehaviour
{
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        if (ButtonVoid.nowPlayer < PlayerNumber.playerNumber-1)
            ButtonVoid.nowPlayer = ButtonVoid.nowPlayer + 1;
        else
            ButtonVoid.nowPlayer = 0;
    }
}
