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
    public Text tutorialMessagePartTwo;
    public Text tutorialMessagePartThree;
    public Button dismissButton;
    public Image tutorialImage;
    public Image tutorialImage2;
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
        tutorialMessagePartTwo.GetComponent<Text>().enabled = false;
        tutorialMessagePartThree.GetComponent<Text>().enabled = false;
        dismissButton.GetComponent<Button>().enabled = false;
        dissmissButtonText.GetComponent<Text>().enabled = false;
        tutorialImage.GetComponent<Image>().enabled = false;
        tutorialImage2.GetComponent<Image>().enabled = false;
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
            tutorialMessagePartTwo.GetComponent<Text>().enabled = true;
            tutorialMessagePartThree.GetComponent<Text>().enabled = true;
            dismissButton.GetComponent<Button>().enabled = true;
            dissmissButtonText.GetComponent<Text>().enabled = true;
            tutorialImage2.GetComponent<Image>().enabled = false;

            tutorialMessagePartTwo.text = "A for loop can be used to move the box to the exit. It is a bit like counting. It starts counting from 0 and each time you count, you can execute a piece of code to move the box by 1 unit. It repeats this until the loop is done counting.";
            tutorialMessagePartThree.text = "Try it out:\n\nfor(int i = 0; i < 8; i++)\n{\n\tbox.x ++;\n}\nRemember the counter starts at zero. If you want to move the box by 5 units, you need to use 'i < 4' inside the for loop.";
        }
        if(hide)
        {
            //hide tutorial box
            tutorialBox.GetComponent<MeshRenderer>().enabled = false;
            tutorialTitle.GetComponent<Text>().enabled = false;
            tutorialUnderline.GetComponent<Text>().enabled = false;
            tutorialMessage.GetComponent<Text>().enabled = false;
            tutorialMessagePartTwo.GetComponent<Text>().enabled = false;
            tutorialMessagePartThree.GetComponent<Text>().enabled = false;
            dismissButton.GetComponent<Button>().enabled = false;
            dissmissButtonText.GetComponent<Text>().enabled = false;
            tutorialImage.GetComponent<Image>().enabled = false;
            tutorialImage2.GetComponent<Image>().enabled = false;
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
        tutorialMessagePartTwo.GetComponent<Text>().enabled = false;
        tutorialMessagePartThree.GetComponent<Text>().enabled = false;
        dismissButton.GetComponent<Button>().enabled = false;
        dissmissButtonText.GetComponent<Text>().enabled = false;
        tutorialImage.GetComponent<Image>().enabled = false;
        tutorialImage2.GetComponent<Image>().enabled = false;

        //taskOne = false;
    }
}
