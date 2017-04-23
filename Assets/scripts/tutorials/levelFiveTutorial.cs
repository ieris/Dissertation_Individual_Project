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

    public bool taskOneActive = false;
    public bool taskTwoActive = false;
    public bool taskTwoAnswerActive = false;

    void Start()
    {
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;

        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;

        //hide tutorial elements
        previousButton.GetComponent<Image>().enabled = false;
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
        if(taskTwoActive)
        {
            taskTwoAnswer();
        }
        

        if (taskOneActive)
        {
            if (tutorialCounter == 0)
            {
                tutorialCounter0();
            }
            else if (tutorialCounter == 1)
            {
                tutorialCounter1();
            }
            else if (tutorialCounter == 2)
            {
                tutorialCounter2();
            }
            else if (tutorialCounter == 3)
            {
                tutorialCounter3();
            }
        }     
    }

    public void tutorialCounter0()
    {
        taskOneActive = true;
        Debug.Log("tutorialcounter 0");
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
        nextButton.GetComponent<Image>().enabled = true;
        previousButton.GetComponent<Image>().enabled = false;
        tutorialCounterText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Looks like we're going on a little ride. We need to get off the platform at the right time.";

        tutorialMessage.fontSize = 23;
        tutorialMessage.GetComponent<RectTransform>().sizeDelta = new Vector2(482.8f, 30);
        tutorialMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-274.28f, 200, 0);

        tutorialBox.transform.localScale = new Vector3(0.98f, 1, -0.47f);
        tutorialBox.transform.position = new Vector3(-4.37f, 13.89f, -1);
        tutorialUnderline.text = "_______________________________________";
        tutorialUnderline.GetComponent<RectTransform>().sizeDelta = new Vector2(487.5f, 30);
        tutorialUnderline.GetComponent<RectTransform>().anchoredPosition = new Vector3(-270, 238.8f, 0);
        dismissTutorialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-43.3f, 255, 0);

        previousButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-327.7f, 60.2f, 0);
        nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-221.05f, 60.2f, 0);
        tutorialCounterText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-160.8f, 56.7f, 0);
    }

    public void tutorialCounter1()
    {
        tutorialCounter = 1;
        tutorialCounterText.text = "2/4";
        hideTutorial();

        //show tutorial box
        nextButton.GetComponent<Image>().enabled = true;
        tutorialCounterText.GetComponent<Text>().enabled = true;
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "We need check when the 'movingPlatform' is next to 'platformOne'. To get the correct x coordinate, we add the x and width of the 'movingPlatform'. When it matches 'platformOne' x coordinate, the player will begin to move.";
        previousButton.GetComponent<Image>().enabled = true;
    }

    public void tutorialCounter2()
    {
        tutorialCounter = 2;
        hideTutorial();
        tutorialCounterText.text = "3/4";

        //show tutorial box
        tutorialCounterText.GetComponent<Text>().enabled = true;
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "We could do that by using an if statement. An if statement executes a piece of code when a certain condition is met.";
        nextButton.GetComponent<Image>().enabled = true;
        previousButton.GetComponent<Image>().enabled = true;

        tutorialBox.transform.position = new Vector3(-4.37f, 13.89f, -1);
        tutorialBox.transform.localScale = new Vector3(0.98f, 1, -0.47f);
        previousButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-327.7f, 60.2f, 0);
        nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-221.05f, 60.2f, 0);
        tutorialCounterText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-160.8f, 56.7f, 0);
    }

    public void tutorialCounter3()
    {
        //____________________________________________

        tutorialCounterText.text = "4/4";
        tutorialCounter = 3;
        hideTutorial();

        //show tutorial box
        tutorialCounterText.GetComponent<Text>().enabled = true;
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Try it out:\n\nif(movingPlatform.x + movingPlatform.width == platformOne.x)\n{\n\tfor(int i = 0; i < 2; i++)\n\t{\n\t\tplayer.x++;\n\t}\n}";

        tutorialBox.transform.localScale = new Vector3(0.98f, 1, -0.68f);
        tutorialBox.transform.position = new Vector3(-4.37f, 12.86f, -1);
        nextButton.GetComponent<Image>().enabled = false;
        previousButton.GetComponent<Image>().enabled = true;

        tutorialCounterText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-160.8f, -56.9f, 0);
        previousButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-327.7f, -53.1f, 0);
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
        tutorialMessage.text = "Awesome! Let's get to the exit. If you need help you can click on the lightbulb button above.";

        tutorialMessage.fontSize = 23;
        tutorialMessage.GetComponent<RectTransform>().sizeDelta = new Vector2(482.8f, 30);
        tutorialMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-274.28f, 200, 0);

        tutorialBox.transform.localScale = new Vector3(0.98f, 1, -0.47f);
        tutorialBox.transform.position = new Vector3(-4.37f, 13.89f, -1);
        tutorialUnderline.text = "_______________________________________";
        tutorialUnderline.GetComponent<RectTransform>().sizeDelta = new Vector2(487.5f, 30);
        tutorialUnderline.GetComponent<RectTransform>().anchoredPosition = new Vector3(-270, 238.8f, 0);
        dismissTutorialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-43.3f, 255, 0);
    }

    public void taskTwoAnswer()
    {
        //taskTwoActive = false;
        taskTwoAnswerActive = true;
        Debug.Log("taskTwoAnswer");
        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "We need to move about 3 steps. So lets use this code:\nfor(int i = 0; i < 2; i++)\n{\n\tplayer.x++;\n}";
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

        tutorialCounterText.GetComponent<Text>().enabled = false;
        previousButton.GetComponent<Image>().enabled = false;
        nextButton.GetComponent<Image>().enabled = false;
        dismissTutorialButton.GetComponent<Image>().enabled = false;
        dismissTutorialButtonText.GetComponent<Text>().enabled = false;
    }
}
