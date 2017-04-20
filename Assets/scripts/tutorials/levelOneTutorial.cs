using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelOneTutorial : MonoBehaviour
{
    //tutorial prompting objects
    public GameObject tutorialBox;
    public Text tutorialTitle;
    public Text tutorialUnderline;
    public Text tutorialMessage;
    public Button dismissButton;
    public Image tutorialImage;
    public Text dissmissButtonText;

    //tasks
    public static bool taskOne = false;
    public static bool taskTwo = false;
    public static bool taskThree = false;
    public static bool hide = false;

    void Start ()
    {
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialTitle.GetComponent<Text>().enabled = false;
        tutorialUnderline.GetComponent<Text>().enabled = false;
        tutorialMessage.GetComponent<Text>().enabled = false;
        dismissButton.GetComponent<Button>().enabled = false;
        dissmissButtonText.GetComponent<Text>().enabled = false;
        tutorialImage.GetComponent<Image>().enabled = false;

        dismissButton.onClick.AddListener(onDismissClick);

        //taskOne = true;
    }
	
	void Update ()
    {
	    if(taskOne)
        {
            //show tutorial box
            tutorialBox.GetComponent<MeshRenderer>().enabled = true;
            tutorialTitle.GetComponent<Text>().enabled = true;
            tutorialUnderline.GetComponent<Text>().enabled = true;
            tutorialMessage.GetComponent<Text>().enabled = true;
            dismissButton.GetComponent<Button>().enabled = true;
            dissmissButtonText.GetComponent<Text>().enabled = true;
            tutorialImage.GetComponent<Image>().enabled = true;

            tutorialMessage.text = "Try to move the box to the x axis by 2 units using:\n\nbox.x += 2;";
        }
        if(taskTwo)
        {
            //show tutorial box
            tutorialBox.GetComponent<MeshRenderer>().enabled = true;
            tutorialTitle.GetComponent<Text>().enabled = true;
            tutorialUnderline.GetComponent<Text>().enabled = true;
            tutorialMessage.GetComponent<Text>().enabled = true;
            dismissButton.GetComponent<Button>().enabled = true;
            dissmissButtonText.GetComponent<Text>().enabled = true;
            //tutorialImage.GetComponent<Image>().enabled = true;

            tutorialMessage.text = "Try to move the box to the x axis by 2 units using:\n\nfor(int i = 0; i < 8; i++)\n{\n\tbox.x ++;\n}";
        }
        if(hide)
        {
            //hide tutorial box
            tutorialBox.GetComponent<MeshRenderer>().enabled = false;
            tutorialTitle.GetComponent<Text>().enabled = false;
            tutorialUnderline.GetComponent<Text>().enabled = false;
            tutorialMessage.GetComponent<Text>().enabled = false;
            dismissButton.GetComponent<Button>().enabled = false;
            dissmissButtonText.GetComponent<Text>().enabled = false;
            tutorialImage.GetComponent<Image>().enabled = false;
        }

	}

    void onDismissClick()
    {
        Debug.Log("clicked dismiss button");
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialTitle.GetComponent<Text>().enabled = false;
        tutorialUnderline.GetComponent<Text>().enabled = false;
        tutorialMessage.GetComponent<Text>().enabled = false;
        dismissButton.GetComponent<Button>().enabled = false;
        dissmissButtonText.GetComponent<Text>().enabled = false;
        tutorialImage.GetComponent<Image>().enabled = false;

        //taskOne = false;
    }
}
