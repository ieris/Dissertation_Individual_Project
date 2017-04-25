using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitScript : MonoBehaviour {

    public Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(onExitButtonClick);
    }

    void onExitButtonClick()
    {
        Application.Quit();
    }
}
