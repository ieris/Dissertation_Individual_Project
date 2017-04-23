using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelFiveTutorial : MonoBehaviour
{
    //tutorial prompting objects
    public GameObject tutorialBox;
    public GameObject tutorialBoxTwo;
    public Text tutorialCounterText;
    public Text tutorialTitle;
    public Text tutorialUnderline;
    public Text tutorialMessage;
    public Text dismissTutorialButtonText;
    public Button nextButton;
    public Button previousButton;
    public Button dismissTutorialButton;
    public Button hintButton;
    public int tutorialCounter = 0;

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
        previousButton.GetComponent<Image>().enabled = true;
        nextButton.GetComponent<Image>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        hintButton.onClick.AddListener(onHintClick);
        nextButton.onClick.AddListener(onNextButtonClick);
        previousButton.onClick.AddListener(onPreviousButtonClick);
        dismissTutorialButton.onClick.AddListener(onDismissTutorialClick);        
    }

    void onDismissTutorialClick()
    {
        hideTutorial();
    }

    void onNextButtonClick()
    {
        if (tutorialCounter == 0)
        {
            hideTutorial();
            tutorialCounter1();
        }
        else if (tutorialCounter == 1)
        {
            hideTutorial();
            tutorialCounter2();
        }
        else if (tutorialCounter == 2)
        {
            hideTutorial();
            tutorialCounter3();
        }
        else if (tutorialCounter == 3)
        {
            hideTutorial();
        }
    }

    void onPreviousButtonClick()
    {
        if (tutorialCounter == 1)
        {
            hideTutorial();
            tutorialCounter0();
        }
        else if (tutorialCounter == 2)
        {
            hideTutorial();
            tutorialCounter1();
        }

        else if (tutorialCounter == 3)
        {
            hideTutorial();
            tutorialCounter2();
        }
        else if (tutorialCounter == 4)
        {
            hideTutorial();
            tutorialCounter3();
        }
    }

    void onHintClick()
    {
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        //tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = true;

        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;

        previousButton.GetComponent<Image>().enabled = true;
        nextButton.GetComponent<Image>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        if (tutorialCounter == 0)
        {
            tutorialCounter0();
        }
        if (tutorialCounter == 1)
        {
            tutorialCounter1();
        }
        if (tutorialCounter == 2)
        {
            tutorialCounter2();
        }
    }

    public void tutorialCounter0()
    {
        tutorialCounter = 0;
        hideTutorial();
        tutorialCounterText.text = "1/4";

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Looks like we're going on a little ride. We need to get off the platform at the right time.";

        tutorialMessage.fontSize = 23;
        tutorialMessage.GetComponent<RectTransform>().sizeDelta = new Vector2(417.5f, 30);
        tutorialMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-275, 200, 0);

        //tutorialBoxTwo.transform.localScale = new Vector3(0.7f, 1, -0.82f);
        tutorialUnderline.text = "______________________";
        dismissTutorialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-43.3f, 255, 0);
    }

    public void tutorialCounter1()
    {
        tutorialCounter = 1;
        tutorialCounterText.text = "2/4";

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "We need check when the 'movingPlatform' is next to 'platformOne'. To get the correct x coordinate, we add the x and width of the 'movingPlatform'. When it matches 'platformOne' x coordinate, the player will begin to move.";
    }

    public void tutorialCounter2()
    {
        tutorialCounter = 2;
        hideTutorial();
        tutorialCounterText.text = "3/4";

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "We could do that by using an if statement. An if statement executes a piece of code when a certain condition is met.";
    }

    public void tutorialCounter3()
    {
        //____________________________________________

        tutorialCounterText.text = "4/4";
        tutorialCounter = 3;
        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Try it out:\nif(movingPlatform.x + movingPlatform.width == platformOne.x)\n{\n\tfor(int i = 0; i < 2; i++)\n\t{\n\t\tplayer.x++;\n\t}\n}";
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
