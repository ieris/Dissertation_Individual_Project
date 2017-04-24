using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelThreeTutorial : MonoBehaviour
{
    //tutorial prompting objects
    public GameObject tutorialBox;
    public GameObject tutorialBoxTwo;
    public Text tutorialTitle;
    public Text tutorialUnderline;
    public Text tutorialMessage;
    public Text dismissTutorialButtonText;
    public Button dismissTutorialButton;
    public Button hintButton;

    private bool taskTwoActive = false;

    void Start()
    {
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;

        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;

        //hide tutorial elements
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        hintButton.onClick.AddListener(onHintClick);
        dismissTutorialButton.onClick.AddListener(onDismissTutorialClick);

        tutorialMessage.text = "Oh, looks like someone moved the platform up. Let's get it back down so we can cross:\n\nfor(int i = 0; i < 4; i++)\n{\n\tmovingPlatform.y--;\n}\n\n";
    }

    void onDismissTutorialClick()
    {
        hideTutorial();
    }

    void onHintClick()
    {
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        //tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = true;

        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;

        //previousButton.GetComponent<Image>().enabled = true;
        //nextButton.GetComponent<Image>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        if(taskTwoActive)
        {
            taskTwoAnswer();
        }
    }

    public void taskOne()
    {
        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Oh, looks like someone moved the platform up. Let's get it back down so we can cross:\n\nfor(int i = 0; i < 4; i++)\n{\n\tmovingPlatform.y--;\n}\n\n";
    }

    public void taskTwo()
    {
        taskTwoActive = true;
        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Now we can cross. Use a for loop to move the box to the exit. If you need help, click on the lightbulb button above.";
    }

    public void taskTwoAnswer()
    {
        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "We need to move the box by 9 units so let's put 'i < 8' inside the for loop like so:\n\nfor(int i = 0; i < 8; i++)\n{\n\tbox.x++;\n}";
    }

    public void hideTutorial()
    {
        Debug.Log("hide tutorial");
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;

        tutorialTitle.GetComponent<Text>().enabled = false;
        tutorialUnderline.GetComponent<Text>().enabled = false;
        tutorialMessage.GetComponent<Text>().enabled = false;

        dismissTutorialButton.GetComponent<Image>().enabled = false;
        dismissTutorialButtonText.GetComponent<Text>().enabled = false;
    }
}
