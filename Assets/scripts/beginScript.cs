using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beginScript : MonoBehaviour
{
    public Button beginButton;

	void Start ()
    {
        beginButton.onClick.AddListener(onBeginButtonClick);
	}
	
	void onBeginButtonClick()
    {
        Application.LoadLevel("LevelOne");
    }
}
