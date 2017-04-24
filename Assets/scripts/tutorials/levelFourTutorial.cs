using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelFourTutorial : MonoBehaviour
{
    //tutorial prompting objects
    public GameObject tutorialBox;
    public GameObject tutorialBoxTwo;
    public GameObject tutorialBoxThree;
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
    public bool taskThreeActive = false;
    public bool taskThreeAnswerActive = false;
    public bool taskFourActive = false;

    void Start()
    {
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxThree.GetComponent<MeshRenderer>().enabled = false;

        tutorialCounterText.GetComponent<Text>().enabled = false;
        tutorialTitle.GetComponent<Text>().enabled = false;
        tutorialUnderline.GetComponent<Text>().enabled = false;
        tutorialMessage.GetComponent<Text>().enabled = false;

        //hide tutorial elements
        previousButton.GetComponent<Image>().enabled = false;
        nextButton.GetComponent<Image>().enabled = false;
        dismissTutorialButton.GetComponent<Image>().enabled = false;
        dismissTutorialButtonText.GetComponent<Text>().enabled = false;

        hintButton.onClick.AddListener(onHintClick);
        nextButton.onClick.AddListener(onNextButtonClick);
        previousButton.onClick.AddListener(onPreviousButtonClick);
        dismissTutorialButton.onClick.AddListener(onDismissTutorialClick);

        tutorialMessage.text = "";
    }

    void onDismissTutorialClick()
    {
        hideTutorial();
    }

    void onHintClick()
    {
        if (taskOneActive)
        {
            Debug.Log("hint button");
            //hideTutorial();
            /*tutorialBox.GetComponent<MeshRenderer>().enabled = true;
            tutorialTitle.GetComponent<Text>().enabled = true;
            tutorialUnderline.GetComponent<Text>().enabled = true;
            dismissTutorialButton.GetComponent<Image>().enabled = true;
            dismissTutorialButtonText.GetComponent<Text>().enabled = true;
            tutorialCounterText.GetComponent<Text>().enabled = true;*/

            if (tutorialCounter == 0)
            {
                /*nextButton.GetComponent<Image>().enabled = true;
                tutorialMessage.GetComponent<Text>().enabled = true;*/

                tutorialCounter0();
            }
            if (tutorialCounter == 1)
            {
                /*previousButton.GetComponent<Image>().enabled = true;
                nextButton.GetComponent<Image>().enabled = true;
                tutorialMessage.GetComponent<Text>().enabled = true;*/
                tutorialCounter1();
            }
            if(tutorialCounter == 2)
            {
                tutorialCounter2();
            }
            if (tutorialCounter == 3)
            {
                /*previousButton.GetComponent<Image>().enabled = true;
                tutorialMessage.GetComponent<Text>().enabled = true;*/
                tutorialCounter3();
            }
        }
        if(taskThreeActive)
        {
            taskThreeAnswer();
        }
        if (taskFourActive)
        {
            taskFourAnswer();
        }
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
    }

    public void taskOne()
    {
        Debug.Log("taskOne");
        taskOneActive = true;
        hideTutorial();
        tutorialCounter0();
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
        tutorialMessage.text = "Now let's call the function we just made and move 'platformOne' up by 2 units!\n\nmoveUp(platformOne, 2);";

        tutorialMessage.fontSize = 22;
        tutorialMessage.GetComponent<RectTransform>().sizeDelta = new Vector2(260, 30);
        tutorialMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-385, 200, 0);

        //tutorialBoxTwo.transform.localScale = new Vector3(0.7f, 1, -0.82f);
        tutorialUnderline.text = "______________________";
        dismissTutorialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250f, 255, 0);
    }
    public void taskThree()
    {
        taskTwoActive = false;
        taskThreeActive = true;
        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Now repeat the process with 'platformTwo' and 'platformThree'. If you need a reminder, click the lightbulb button above.";

        tutorialMessage.fontSize = 22;
        tutorialMessage.GetComponent<RectTransform>().sizeDelta = new Vector2(260, 30);
        tutorialMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-385, 200, 0);

        //tutorialBoxTwo.transform.localScale = new Vector3(0.7f, 1, -0.82f);
        tutorialUnderline.text = "______________________";
        dismissTutorialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250f, 255, 0);
    }

    public void taskThreeAnswer()
    {
        taskTwoActive = false;
        taskThreeAnswerActive = true;

        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "All we need to do is call the function we made again like so:\n\nmoveUp(platformTwo, 2); \n\nmoveUp(platformThree, 2);";

        tutorialMessage.fontSize = 21;
        tutorialMessage.GetComponent<RectTransform>().sizeDelta = new Vector2(260, 30);
        tutorialMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-385, 200, 0);

        //tutorialBoxTwo.transform.localScale = new Vector3(0.7f, 1, -0.82f);
        tutorialUnderline.text = "______________________";
        dismissTutorialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250f, 255, 0);
    }

    public void taskFour()
    {
        taskFourActive = true;
        taskThreeActive = false;
        hideTutorial();

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "You know what to do now. Let's make the box move. If you get stuck you can click the lightbulb button above.";

        tutorialMessage.fontSize = 22;
        tutorialMessage.GetComponent<RectTransform>().sizeDelta = new Vector2(260, 30);
        tutorialMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-385, 200, 0);

        //tutorialBoxTwo.transform.localScale = new Vector3(0.7f, 1, -0.82f);
        tutorialUnderline.text = "______________________";
        dismissTutorialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250f, 255, 0);
    }

    public void taskFourAnswer()
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

        tutorialMessage.fontSize = 22;
        tutorialMessage.GetComponent<RectTransform>().sizeDelta = new Vector2(260, 30);
        tutorialMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-385, 200, 0);

        //tutorialBoxTwo.transform.localScale = new Vector3(0.7f, 1, -0.82f);
        tutorialUnderline.text = "______________________";
        dismissTutorialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250f, 255, 0);
    }

    public void tutorialCounter0()
    {
        taskOneActive = true;
        tutorialCounter = 0;
        Debug.Log("tutorial counter 0");
        tutorialCounterText.text = "1/4";

        tutorialCounterText.GetComponent<Text>().enabled = true;
        //Debug.Log(tutorialCounterText.GetComponent<Text>().enabled);
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxThree.GetComponent<MeshRenderer>().enabled = false;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;

        previousButton.GetComponent<Image>().enabled = false;
        nextButton.GetComponent<Image>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        tutorialMessage.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Wow! There is a lot of work to do to move all of these platforms up. Oh, I know! Let's create a function.";
        //Debug.Log(tutorialMessage.text);
    }
    public void tutorialCounter1()
    {
        tutorialCounter = 1;
        Debug.Log("tutorial counter 1");
        tutorialCounterText.text = "2/4";
        tutorialCounterText.GetComponent<Text>().enabled = true;

        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxThree.GetComponent<MeshRenderer>().enabled = false;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;

        previousButton.GetComponent<Image>().enabled = true;
        nextButton.GetComponent<Image>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        tutorialMessage.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "A function is just a place  where you can store code. Whenever you want to use that code, you simply write one line of code to recall that function.";

        //tutorialBoxThree.GetComponent<MeshRenderer>().enabled = false;

        tutorialMessage.fontSize = 22;
        tutorialMessage.GetComponent<RectTransform>().sizeDelta = new Vector2(260, 30);
        tutorialMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-385, 200, 0);
        tutorialBoxThree.GetComponent<MeshRenderer>().enabled = false;
        tutorialCounterText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-265.4f, -7.5f, 0);
        nextButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-324.9f, -3.6f, 0);
        previousButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-435.8f, -3.6f, 0);

        //tutorialBoxTwo.transform.localScale = new Vector3(0.7f, 1, -0.82f);
        tutorialUnderline.text = "______________________";
        dismissTutorialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-250f, 255, 0);
    }
    public void tutorialCounter2()
    {
        tutorialCounter = 2;
        Debug.Log("tutorial counter 2");
        tutorialCounterText.text = "3/4";
        tutorialMessage.fontSize = 21;
        tutorialMessage.GetComponent<RectTransform>().sizeDelta = new Vector2(320, 30);
        tutorialMessage.GetComponent<RectTransform>().anchoredPosition = new Vector3(-353, 200, 0);
        tutorialBoxThree.GetComponent<MeshRenderer>().enabled = true;
        tutorialCounterText.GetComponent<RectTransform>().anchoredPosition = new Vector3(-234.6f, -124.9f, 0);
        nextButton.GetComponent<RectTransform>() .anchoredPosition = new Vector3(-287.3f, -120.86f, 0);
        previousButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-408.3f, -120.86f, 0);

        //tutorialBoxTwo.transform.localScale = new Vector3(0.7f, 1, -0.82f);
        tutorialUnderline.text = "__________________________";
        dismissTutorialButton.GetComponent<RectTransform>().anchoredPosition = new Vector3(-202.5f, 255, 0);

        tutorialCounterText.GetComponent<Text>().enabled = true;

        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;

        previousButton.GetComponent<Image>().enabled = true;
        nextButton.GetComponent<Image>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        tutorialMessage.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Let's create a function which can move any available platform up by x units:\n\nvoid moveUp(object platform, int x)\n{\n\tfor(int i = 0; i < x - 1; i++)\n\t{\n\t\tplatform.y++;\n\t}\n}";
    }
    public void tutorialCounter3()
    {
        tutorialCounter = 3;
        Debug.Log("tutorial counter 3");
        tutorialCounterText.text = "4/4";
        tutorialCounterText.GetComponent<Text>().enabled = true;

        tutorialBoxThree.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;

        previousButton.GetComponent<Image>().enabled = true;
        nextButton.GetComponent<Image>().enabled = false;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        tutorialMessage.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Notice that 'x' and 'platform' are used inside the for loop. When we recall our function we are going to replace 'x' with an integer and 'platform' with an available platform name. Also note that if we want to move the platform by 2 units, we need to use 'i < 1', hence why we write 'i < x - 1' inside the for loop.";
    }

    public void hideTutorial()
    {
        Debug.Log("hide tutorial");
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxThree.GetComponent<MeshRenderer>().enabled = false;

        tutorialCounterText.GetComponent<Text>().enabled = false;
        tutorialTitle.GetComponent<Text>().enabled = false;
        tutorialUnderline.GetComponent<Text>().enabled = false;
        tutorialMessage.GetComponent<Text>().enabled = false;

        //hide tutorial elements
        previousButton.GetComponent<Image>().enabled = false;
        nextButton.GetComponent<Image>().enabled = false;
        dismissTutorialButton.GetComponent<Image>().enabled = false;
        dismissTutorialButtonText.GetComponent<Text>().enabled = false;
    }
}
