using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelOneTutorial : MonoBehaviour
{
    //tutorial prompting objects
    public GameObject tutorialBox;
    public GameObject tutorialBoxTwo;
    public Text tutorialCounterText;
    public Text tutorialTitle;
    public Text tutorialUnderline;
    public Text tutorialMessage;
    public Text dismissTutorialButtonText;
    public Image tutorialImage;
    public Image tutorialImage2;
    public Button nextButton;
    public Button previousButton;
    public Button dismissTutorialButton;
    public Button hintButton;
    public int tutorialCounter = 0;

    private bool taskOneActive = false;
    private bool taskTwoActive = false;

    void Start ()
    {
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;

        tutorialCounterText.GetComponent<Text>().enabled = false;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;

        tutorialImage.GetComponent<Image>().enabled = true;

        //hide tutorial elements
        previousButton.GetComponent<Image>().enabled = false;
        nextButton.GetComponent<Image>().enabled = false;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        hintButton.onClick.AddListener(onHintClick);
        nextButton.onClick.AddListener(onNextButtonClick);
        previousButton.onClick.AddListener(onPreviousButtonClick);
        dismissTutorialButton.onClick.AddListener(onDismissTutorialClick);
        //taskOne = true;
    }
	
	void Update ()
    {

	}

    void onNextButtonClick()
    {
        if(tutorialCounter == 0)
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
        else if(tutorialCounter == 3)
        {
            hideTutorial();
        }
    }

    void onPreviousButtonClick()
    {
        if(tutorialCounter == 1)
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

    void onDismissTutorialClick()
    {
        hideTutorial();
    }

    void onHintClick()
    {
        if(taskOneActive)
        {
            hideTutorial();
            tutorialBox.GetComponent<MeshRenderer>().enabled = true;
            tutorialTitle.GetComponent<Text>().enabled = true;
            tutorialUnderline.GetComponent<Text>().enabled = true;
            tutorialMessage.GetComponent<Text>().enabled = true;
            dismissTutorialButton.GetComponent<Image>().enabled = true;
            dismissTutorialButtonText.GetComponent<Text>().enabled = true;
            tutorialImage.GetComponent<Image>().enabled = true;
        }

        if (taskTwoActive)
        {
            hideTutorial();
            tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = true;
            tutorialTitle.GetComponent<Text>().enabled = true;
            tutorialUnderline.GetComponent<Text>().enabled = true;            
            dismissTutorialButton.GetComponent<Image>().enabled = true;
            dismissTutorialButtonText.GetComponent<Text>().enabled = true;
            tutorialCounterText.GetComponent<Text>().enabled = true;

            if (tutorialCounter == 0)
            {
                nextButton.GetComponent<Image>().enabled = true;
                tutorialMessage.GetComponent<Text>().enabled = true;

            }
            if(tutorialCounter == 1 || tutorialCounter == 2)
            {
                previousButton.GetComponent<Image>().enabled = true;
                nextButton.GetComponent<Image>().enabled = true;
                tutorialMessage.GetComponent<Text>().enabled = true;
            }
            if (tutorialCounter == 2)
            {
                tutorialImage2.GetComponent<Image>().enabled = true;
                tutorialMessage.GetComponent<Text>().enabled = false;
            }
            if(tutorialCounter == 3)
            {
                previousButton.GetComponent<Image>().enabled = true;
                tutorialMessage.GetComponent<Text>().enabled = true;
            }
        }
    }

    public void taskOne()
    {
        Debug.Log("task One");
        taskOneActive = true;

        //show tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = true;
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        tutorialMessage.GetComponent<Text>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;
        tutorialImage.GetComponent<Image>().enabled = true;

        tutorialMessage.text = "Try to move the box to the x axis by 2 units using:\n\nbox.x += 2;";
        Debug.Log("task One22");
    }

    public void taskTwo()
    {
        taskOneActive = false;
        taskTwoActive = true;

        //tutorialCounter = 0;
        hideTutorial();
        tutorialCounter0();
    }

    public void tutorialCounter0()
    {
        tutorialCounter = 0;
        Debug.Log("tutorial counter 0");
        tutorialCounterText.text = "1/4";
        tutorialCounterText.GetComponent<Text>().enabled = true;

        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = true;    
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;

        previousButton.GetComponent<Image>().enabled = false;
        nextButton.GetComponent<Image>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        tutorialMessage.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "To simulate movement a for loop can be used to move the box to the exit. It is a bit like counting. It starts counting from 0 and each time you count, you can execute a piece of code to move the box by 1 unit. It repeats this until the loop is done counting.";
    }
    public void tutorialCounter1()
    {
        tutorialCounter = 1;
        Debug.Log("tutorial counter 1");
        tutorialCounterText.text = "2/4";
        tutorialCounterText.GetComponent<Text>().enabled = true;

        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = true;        
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        
        previousButton.GetComponent<Image>().enabled = true;
        nextButton.GetComponent<Image>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        tutorialMessage.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "For example, to move a box by 6 units, we set a number variable called 'i' to 0 and begin counting. We check if 'i<5' and while this is true, we run the code to move the box by 1 unit using '++' and then increase the variable 'i' by 1 also. So the loop can run again, this time 'i' is 1 and so on.";
    }
    public void tutorialCounter2()
    {
        tutorialCounter = 2;
        Debug.Log("tutorial counter 2");
        tutorialCounterText.text = "3/4";
        tutorialCounterText.GetComponent<Text>().enabled = true;

        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = true;       
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;
        
        tutorialImage2.GetComponent<Image>().enabled = true;

        previousButton.GetComponent<Image>().enabled = true;
        nextButton.GetComponent<Image>().enabled = true;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        tutorialMessage.GetComponent<Text>().enabled = false;
    }
    public void tutorialCounter3()
    {
        tutorialCounter = 3;
        Debug.Log("tutorial counter 3");
        tutorialCounterText.text = "4/4";
        tutorialCounterText.GetComponent<Text>().enabled = true;

        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = true;       
        tutorialTitle.GetComponent<Text>().enabled = true;
        tutorialUnderline.GetComponent<Text>().enabled = true;        

        previousButton.GetComponent<Image>().enabled = true;
        nextButton.GetComponent<Image>().enabled = false;
        dismissTutorialButton.GetComponent<Image>().enabled = true;
        dismissTutorialButtonText.GetComponent<Text>().enabled = true;

        tutorialMessage.GetComponent<Text>().enabled = true;
        tutorialMessage.text = "Try it out:\n\nfor(int i = 0; i < 5; i++)\n{\n\tbox.x ++;\n}\n\nRemember the counter starts at zero. If you want to move the box by 6 units, you need to use \n'i < 5' inside the for loop.";
    }

    public void hideTutorial()
    {
        Debug.Log("hide tutorial");
        //hide tutorial box
        tutorialBox.GetComponent<MeshRenderer>().enabled = false;
        tutorialBoxTwo.GetComponent<MeshRenderer>().enabled = false;

        tutorialCounterText.GetComponent<Text>().enabled = false;
        tutorialTitle.GetComponent<Text>().enabled = false;
        tutorialUnderline.GetComponent<Text>().enabled = false;
        tutorialMessage.GetComponent<Text>().enabled = false;

        /*if(taskOneActive)
        {*/
            tutorialImage.GetComponent<Image>().enabled = false;
        //}
        
        /*if (taskTwoActive)
        {*/
            tutorialImage2.GetComponent<Image>().enabled = false;
        //}
        //hide tutorial elements
        previousButton.GetComponent<Image>().enabled = false;
        nextButton.GetComponent<Image>().enabled = false;
        dismissTutorialButton.GetComponent<Image>().enabled = false;
        dismissTutorialButtonText.GetComponent<Text>().enabled = false;
    }
}
