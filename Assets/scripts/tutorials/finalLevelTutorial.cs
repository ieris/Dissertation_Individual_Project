using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalLevelTutorial : MonoBehaviour
{
    FinalLevel fl;

    //tutorial prompting objects
    public GameObject tutorialBox;
    public GameObject tutorialBoxTwo;
    public GameObject tutorialBoxThree;
    public Text tutorialCounterText;
    public Text tutorialTitle;
    public Text tutorialUnderline;
    public Text tutorialMessage;
    public Text dismissTutorialButtonText;
    public Button dismissTutorialButton;
    public Button hintButton;
    public int tutorialCounter = 0;

    public bool taskOneActive = false;
    public bool taskTwoActive = false;
    public bool taskThreeActive = false;

    void Start()
    {
        fl = GameObject.FindObjectOfType(typeof(FinalLevel)) as FinalLevel;
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = true;
        tutorialBoxThree.GetComponent<MeshRenderer>().enabled = false;

        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;

        //hide tutorial elements
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        hintButton.onClick.AddListener(onHintClick);
        dismissTutorialButton.onClick.AddListener(onDismissTutorialClick);

        tutorialMessage.text = "Let's see if you can solve this one. If you need help click on the lightbulb button above.";
    }

    void onDismissTutorialClick()
    {
        hideTutorial();
    }

    void onHintClick()
    {               
        if (taskThreeActive)
        {
            fl.dismissError();
            taskThree();
        }
        else if (taskTwoActive)
        {
            fl.dismissError();
            taskTwo();
        }
        else if (taskOneActive)
        {
            fl.dismissError();
            taskOne();
        }
        else
        {
            fl.dismissError();
            taskOne();
        }
    }

    public void taskOne()
    {
        taskOneActive = true;
        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "We can check when 'platformOne' is at the same height as 'platformTwo'. When they match, we just need to walk off like so:\n\nif(platformOne.y == platformTwo.y)\n{\n\tfor(int i = 0; i < 2; i++)\n\t{\n\t\tbox.x++;\n\t}\n}";
    }

    public void taskTwo()
    {
        taskOneActive = false;
        taskTwoActive = true;
        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "We can repeat the same process using 'platformTwo' and 'platformThree':\n\nif(platformTwo.y == platformThree.y)\n{\n\tfor(int i = 0; i < 2; i++)\n\t{\n\t\tbox.x++;\n\t}\n}";
    }

    public void taskThree()
    {
        taskTwoActive = false;
        taskThreeActive = true;
        hideTutorial();

        //show tutorial box
        tutorialBoxThree.GetComponent<MeshRenderer>().enabled = true;
        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Now all that's left is to get to the exit:\n\nfor(int i = 0; i < 3; i++)\n{\n\tbox.x++;\n}";
    }

    public void hideTutorial()
    {
        Debug.Log("hide tutorial");
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxThree.GetComponent<MeshRenderer>().enabled = false;

        tutorialTitle.GetComponent<Text>().enabled = false;
        tutorialUnderline.GetComponent<Text>().enabled = false;
        tutorialMessage.GetComponent<Text>().enabled = false;

        dismissTutorialButton.GetComponent<Image>().enabled = false;
        dismissTutorialButtonText.GetComponent<Text>().enabled = false;
    }
}
