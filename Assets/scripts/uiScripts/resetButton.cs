using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class resetButton : MonoBehaviour
{
    public Button reset;
    public GameObject codeErrorBox;
    public Text codeErrorText;
    public Button codeErrorButton;

    void Start ()
    {
        reset.onClick.AddListener(onResetClick);
    }
	
	void Update ()
    {
	
	}

    void onResetClick()
    {
        codeErrorBox.GetComponent<Renderer>().enabled = true;
        codeErrorText.GetComponent<Renderer>().enabled = true;
        codeErrorButton.GetComponent<Renderer>().enabled = true;
    }
}
