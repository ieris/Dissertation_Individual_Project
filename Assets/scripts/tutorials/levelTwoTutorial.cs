using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelTwoTutorial : MonoBehaviour
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

    void Start()
    {
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;

        tutorialTitle.GetComponent<Text>().enabled = false;
        tutorialUnderline.GetComponent<Text>().enabled = false;
        tutorialMessage.GetComponent<Text>().enabled = false;

        //hide tutorial elements
        dismissTutorialButton.GetComponent<Image>().enabled = false;
        dismissTutorialButtonText.GetComponent<Text>().enabled = false;

        hintButton.onClick.AddListener(onHintClick);
        dismissTutorialButton.onClick.AddListener(onDismissTutorialClick);

        tutorialMessage.text = "";
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
        tutorialMessage.text = "Let's move the box by 11 units across the bridge using a for loop:\n\nfor(int i = 0; i < 10; i++)\n{\n\tbox.x ++;\n}\n\n";
    }

    public void taskTwo()
    {
        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Oh no! The box is moving too slow. Let's increase its speed. Create an integer (whole number) variable called 'speed':\n\nint speed = 4;";
    }

    public void taskThree()
    {
        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Now let's move the box and apply the speed variable inside the for loop. Have a go:\n\nfor(int i = 0; i < 9; i++)\n{\n\tbox.x += 1 * speed;\n}\n\n";
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
