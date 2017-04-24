using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class LevelThree : MonoBehaviour
{
    //Tutorial references
    levelThreeTutorial tutorial;

    //user input
    private InputField input;
    private string inputCopy;

    //correct answer
    public GameObject correctAnswerBox;
    public Text correctAnswerText;
    public Button correctAnswerDismissButton;
    public Text correctAnswerDismissButtonText;
    private float correctAnswerTimer = 2f;

    //objects in the scene
    public Button run;
    public Button resetButton;
    public GameObject platformOne;
    public GameObject platformTwo;
    public GameObject movingPlatform;
    public GameObject player;

    //store coordinatees
    private Vector3 movingPlatformPos;
    private Vector3 playerPos;

    //error prompting objects
    public GameObject errorBox;
    public Text errorTitle;
    public Text errorTitleUnderline;
    public Text errorMessage;
    public Button dismissErrorButton;
    public Text dissmissErrorButtonText;

    //seperating the code into variables
    private string objectName;
    private string loopLength;

    //levelComplete
    private static bool partOneDone = false;
    private static bool partTwoDone = false;
    private static bool movingPlatformLower = false;
    private static bool movingPlatformHigher = false;
    private static bool movingPlayerLeft = false;
    private static bool movingPlayerRight = false;

    // Use this for initialization
    void Start ()
    {
        tutorial = GameObject.FindObjectOfType(typeof(levelThreeTutorial)) as levelThreeTutorial;
        input = GetComponent<InputField>();
        run.onClick.AddListener(onRunClick);
        resetButton.onClick.AddListener(onResetClick);
        dismissErrorButton.onClick.AddListener(onDismissClick);
        correctAnswerDismissButton.onClick.AddListener(onCorrectAnswerDismiss);

        //hide error/hint box
        errorBox.GetComponent<MeshRenderer>().enabled = false;
        errorTitle.GetComponent<Text>().enabled = false;
        errorTitleUnderline.GetComponent<Text>().enabled = false;
        errorMessage.GetComponent<Text>().enabled = false;
        dismissErrorButton.GetComponent<Button>().enabled = false;
        dissmissErrorButtonText.GetComponent<Text>().enabled = false;

        //Store original object coordinates
        movingPlatformPos = movingPlatform.transform.position;
        playerPos = player.transform.position;

        //correct answer
        correctAnswerBox.GetComponent<MeshRenderer>().enabled = false;
        correctAnswerText.GetComponent<Text>().enabled = false;
        correctAnswerDismissButton.GetComponent<Image>().enabled = false;
        correctAnswerDismissButtonText.GetComponent<Text>().enabled = false;

        //tutorial pop-ups
        tutorial.taskOne();
    }

    void Update ()
    {
        if (movingPlatformLower)
        {
            if (correctAnswerTimer >= 0f)
            {
                correctAnswerTimer -= Time.deltaTime;

                //show correct answer
                correctAnswerBox.GetComponent<MeshRenderer>().enabled = true;
                correctAnswerText.GetComponent<Text>().enabled = true;
                correctAnswerDismissButton.GetComponent<Image>().enabled = true;
                correctAnswerDismissButtonText.GetComponent<Text>().enabled = true;
            }
            else
            {
                //hide correct answer
                correctAnswerBox.GetComponent<MeshRenderer>().enabled = false;
                correctAnswerText.GetComponent<Text>().enabled = false;
                correctAnswerDismissButton.GetComponent<Image>().enabled = false;
                correctAnswerDismissButtonText.GetComponent<Text>().enabled = false;
            }
        }
        if (movingPlayerRight)
        {
            if (correctAnswerTimer >= 0f)
            {
                correctAnswerTimer -= Time.deltaTime;

                //show correct answer
                correctAnswerBox.GetComponent<MeshRenderer>().enabled = true;
                correctAnswerText.GetComponent<Text>().enabled = true;
                correctAnswerDismissButton.GetComponent<Image>().enabled = true;
                correctAnswerDismissButtonText.GetComponent<Text>().enabled = true;
            }
            else
            {               
                //hide correct answer
                correctAnswerBox.GetComponent<MeshRenderer>().enabled = false;
                correctAnswerText.GetComponent<Text>().enabled = false;
                correctAnswerDismissButton.GetComponent<Image>().enabled = false;
                correctAnswerDismissButtonText.GetComponent<Text>().enabled = false;
            }
        }

        //Moving the platform up/down: Part One
        //going down
        if (movingPlatformLower)
        {
            //Move down until for loop ends
            if (movingPlatform.transform.position.y >  movingPlatformPos.y - (Convert.ToInt32(loopLength) + 1))
            {
                movingPlatform.transform.position += Vector3.down * 1f * Time.deltaTime;
                input.GetComponent<InputField>().interactable = false;
            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(movingPlatform.transform.position.y <= movingPlatformPos.y + (Convert.ToInt32(loopLength) + 1));
            if (movingPlatform.transform.position.y <= movingPlatformPos.y - (Convert.ToInt32(loopLength) + 1))
            {
                input.GetComponent<InputField>().interactable = true;
                movingPlatform.transform.position = new Vector3(movingPlatform.transform.position.x, movingPlatformPos.y - (Convert.ToInt32(loopLength) + 1), movingPlatform.transform.position.z);
                movingPlatformLower = false;
                movingPlatformPos.y = movingPlatformPos.y - (Convert.ToInt32(loopLength) + 1);
                Debug.Log(movingPlatform.transform.position);
                loopLength = "0";
                //input.text = "";

                //Check if the movingPlatform is in the correct position
                if (movingPlatform.transform.position.y == 7f)
                {
                    tutorial.taskTwo();
                    partOneDone = true;
                    Debug.Log("Part One done! :D");
                }
            }
        }

        //going up
        if (movingPlatformHigher)
        {
            //Move up until for loop ends
            if (movingPlatform.transform.position.y < movingPlatformPos.y + (Convert.ToInt32(loopLength) + 1))
            {
                movingPlatform.transform.position += Vector3.up * 1f * Time.deltaTime;
            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(movingPlatform.transform.position.y >= movingPlatformPos.y + (Convert.ToInt32(loopLength) + 1));
            if (movingPlatform.transform.position.y >= movingPlatformPos.y + (Convert.ToInt32(loopLength) + 1))
            {
                movingPlatform.transform.position = new Vector3(movingPlatform.transform.position.x, movingPlatformPos.y + (Convert.ToInt32(loopLength) + 1), movingPlatform.transform.position.z);
                Debug.Log(movingPlatform.transform.position);
                movingPlatformHigher = false;
                movingPlatformPos.y = movingPlatformPos.y + (Convert.ToInt32(loopLength) + 1);
                loopLength = "0";
                //input.text = "";

                //Check if the movingPlatform is in the correct position
                if (movingPlatform.transform.position.y == 7f)
                {
                    tutorial.taskTwo();
                    partOneDone = true;
                    Debug.Log("Part One done! :D");
                }
            }
        }

        //Moving the player left/right: Part Two
        //left
        if (movingPlayerLeft)
        {
            //Move down until for loop ends
            if (player.transform.position.x > playerPos.x - (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.left * 1f * Time.deltaTime;

                //Check if the movingPlatform is in the correct position
                if (player.transform.position.x >= 3f)
                {
                    partTwoDone = true;
                    Application.LoadLevel("LevelFour");
                    Debug.Log("Part Two done! :D");
                }
            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(player.transform.position.x <= playerPos.x + (Convert.ToInt32(loopLength) + 1));
            if (player.transform.position.x <= playerPos.x - (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position = new Vector3(playerPos.x - (Convert.ToInt32(loopLength) + 1), player.transform.position.y, player.transform.position.z);
                movingPlayerLeft = false;
                playerPos.x = playerPos.x - (Convert.ToInt32(loopLength) + 1);
                Debug.Log(player.transform.position);
                loopLength = "0";
                //input.text = "";                
            }
        }

        //right
        if (movingPlayerRight)
        {
            //Move up until for loop ends
            if (player.transform.position.x < playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.right * 1f * Time.deltaTime;
                input.GetComponent<InputField>().interactable = false;

                //Check if the movingPlatform is in the correct position
                if (player.transform.position.x >= 3f)
                {
                    partTwoDone = true;
                    Application.LoadLevel("LevelFour");
                    Debug.Log("Part Two done! :D");
                }

            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            //Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
            if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                input.GetComponent<InputField>().interactable = true;
                player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, movingPlatform.transform.position.z);
                Debug.Log(player.transform.position);
                movingPlayerRight = false;
                playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                loopLength = "0";
                //input.text = "";
            }
        }
    }

    void onRunClick()
    {
        //hide error/hint box
        errorBox.GetComponent<MeshRenderer>().enabled = false;
        errorTitle.GetComponent<Text>().enabled = false;
        errorTitleUnderline.GetComponent<Text>().enabled = false;
        errorMessage.GetComponent<Text>().enabled = false;
        dismissErrorButton.GetComponent<Button>().enabled = false;
        dissmissErrorButtonText.GetComponent<Text>().enabled = false;

        Debug.Log("Button was clicked!");        

        if(!partOneDone)
        {
            moveMovingPlatform();            
        }
        if(partOneDone)
        {
            movePlayer();
        }
    }

    void onResetClick()
    {
        Application.LoadLevel("LevelThree");
    }

    void onDismissClick()
    {
        //hide error/hint box
        errorBox.GetComponent<MeshRenderer>().enabled = false;
        errorTitle.GetComponent<Text>().enabled = false;
        errorTitleUnderline.GetComponent<Text>().enabled = false;
        errorMessage.GetComponent<Text>().enabled = false;
        dismissErrorButton.GetComponent<Button>().enabled = false;
        dissmissErrorButtonText.GetComponent<Text>().enabled = false;
    }

    void onCorrectAnswerDismiss()
    {
        correctAnswerTimer = 0f;
    }

    void moveMovingPlatform()
    {
        Debug.Log(movingPlatformLower);
        inputCopy = input.text;
        Debug.Log("Moving platform! :D");
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        if (inputCopy == "")
        {
            Debug.Log("Input field is empty");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Input field is empty.";

        }
        else if (inputCopy.Contains("movingPlatform") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable 'movingPlatform' is missing.";
        }
        else if (inputCopy.Substring(inputCopy.Length - 1, 1) != "}")
        {
            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Are you missing a curly bracket?";
        }   
        else if ((Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(movingPlatform\.([y])\-\-\;)*\s*}") == false)
        && ((Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(movingPlatform\.([y])\+\+\;)*\s*}") == false)))
        {
            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Expression does not match.";
        }

        //Check if for loop if statement matches: moving platform going down
        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(movingPlatform\.([y])\-\-\;)*\s*}"))    //match regex movingPlatform.y+=100;
        {
            movingPlatformLower = true;
            //Find the object name in the string
            int objectNamePos = inputCopy.IndexOf("{");
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);
            Debug.Log("object name: " + objectName);
            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);
            
            Debug.Log("loop length: " + loopLength);
            

        }
        //Check if for loop if statement matches: moving platform going up
        else if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(movingPlatform\.([y])\+\+\;)*\s*}"))    //match regex movingPlatform.y=100;
        {
            movingPlatformHigher = true;
            //Find the object name in the string
            int objectNamePos = inputCopy.IndexOf("{");
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);

            Debug.Log("object name: " + objectName);
            Debug.Log("loop length: " + loopLength);           
        }
    }

    void movePlayer()
    {
        inputCopy = input.text;
        Debug.Log("input copy inside player: " + inputCopy);
        Debug.Log("Moving player! :D");
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces
        Debug.Log(objectName);
        if (inputCopy == "")
        {
            Debug.Log("Input field is empty");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Input field is empty.";
        }
        else if (!inputCopy.Contains("box"))
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable 'box' is missing.";
        }
        else if (inputCopy.Substring(inputCopy.Length - 1, 1) != "}")
        {
            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Are you missing a curly bracket?";
        }
        else if ((Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(box\.([x])\-\-\;)*\s*}") == false)
        && ((Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(box\.([x])\+\+\;)*\s*}") == false)))
        {
            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Expression does not match.";
        }

        //Check if for loop if statement matches: moving platform going down
        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(box\.([x])\-\-\;)*\s*}"))    //match regex box.x--;
        {
            Debug.Log("moving left");
            //Find the object name in the string
            int objectNamePos = inputCopy.IndexOf("{");
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);
            Debug.Log(objectName);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            Debug.Log(loopLength);
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);
            Debug.Log(loopLength);

            Debug.Log("object name: " + objectName);
            Debug.Log("loop length: " + loopLength);
            movingPlayerLeft = true;
            correctAnswerTimer = 2f;
        }
        //Check if for loop if statement matches: moving platform going down
        else if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(box\.([x])\+\+\;)*\s*}"))    //match regex box.x++;
        {
            Debug.Log("moving right");
            //Find the object name in the string
            int objectNamePos = inputCopy.IndexOf("{");
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);

            Debug.Log("object name: " + objectName);
            Debug.Log("loop length: " + loopLength);
            movingPlayerRight = true;
            correctAnswerTimer = 2f;
        }
    }
}
