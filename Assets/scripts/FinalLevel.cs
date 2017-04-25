using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class FinalLevel : MonoBehaviour
{
    //Tutorial references
    finalLevelTutorial tutorial;

    //user input
    private InputField input;
    private string inputCopy;

    public Button run;
    public Button resetButton;
    public GameObject exit;
    public GameObject player;
    public GameObject platform;
    public GameObject movingPlatformOne;
    public GameObject movingPlatformTwo;

    movingPlatformOne mpo;
    movingPlatformTwo mpt;

    //store coordinatees
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
    private string objectName2;
    private string objectToMove;
    private string loopLength;

    //correct answer
    public GameObject correctAnswerBox;
    public Text correctAnswerText;
    public Button correctAnswerDismissButton;
    public Text correctAnswerDismissButtonText;

    private float correctAnswerTimer = 2f;

    //platform movement back and forth
    private bool movingPlatformOneBool = true;
    private bool movingPlatformTwoBool = false;
    private bool playerBool = false;

    //levelComplete
    private bool runClicked = false;
    public bool stopPlatformOne = false;
    public bool stopPlatformTwo = false;
    private bool inputEntered = false;
    private bool partOneDone = false;
    private bool partTwoDone = false;
    private bool partThreeDone = false;
    private bool partFourDone = false;
    private bool movingPlayerRight = false;
    private bool movingPlayerRight2 = false;
    private bool movingPlayerRight3 = false;
    private bool movingPlayerRightIfStatement = false;
    private bool movingPlayerRightIfStatement2 = false;

    void Start ()
    {
        tutorial = GameObject.FindObjectOfType(typeof(finalLevelTutorial)) as finalLevelTutorial;
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
        playerPos = player.transform.position;

        //correct answer
        correctAnswerBox.GetComponent<MeshRenderer>().enabled = false;
        correctAnswerText.GetComponent<Text>().enabled = false;
        correctAnswerDismissButton.GetComponent<Image>().enabled = false;
        correctAnswerDismissButtonText.GetComponent<Text>().enabled = false;

        //tutorial pop-ups
        //tutorial.taskOne();
    }
	
	void Update ()
    {
        if (movingPlayerRightIfStatement || partOneDone || partTwoDone || partThreeDone || partFourDone)
        {
            if (correctAnswerTimer >= 0f)
            {
                correctAnswerTimer -= Time.deltaTime;               

                //show correct answer
                correctAnswerBox.GetComponent<MeshRenderer>().enabled = true;
                correctAnswerText.GetComponent<Text>().enabled = true;
                correctAnswerDismissButton.GetComponent<Image>().enabled = true;
                correctAnswerDismissButtonText.GetComponent<Text>().enabled = true;

                //hide error/hint box
                errorBox.GetComponent<MeshRenderer>().enabled = false;
                errorTitle.GetComponent<Text>().enabled = false;
                errorTitleUnderline.GetComponent<Text>().enabled = false;
                errorMessage.GetComponent<Text>().enabled = false;
                dismissErrorButton.GetComponent<Button>().enabled = false;
                dissmissErrorButtonText.GetComponent<Text>().enabled = false;
            }
            else
            {
                //input.GetComponent<InputField>().interactable = true;

                //hide correct answer
                correctAnswerBox.GetComponent<MeshRenderer>().enabled = false;
                correctAnswerText.GetComponent<Text>().enabled = false;
                correctAnswerDismissButton.GetComponent<Image>().enabled = false;
                correctAnswerDismissButtonText.GetComponent<Text>().enabled = false;
            }
        }

        if (movingPlayerRightIfStatement && !partOneDone)
        {
            if((movingPlatformOne.transform.position.y <= movingPlatformTwo.transform.position.y) && (movingPlatformOne.transform.position.y >= 6.43f))
            {
                player.transform.position = new Vector3(player.transform.position.x, 11, movingPlatformOne.transform.position.z);
                movingPlatformOne.transform.position = new Vector3(movingPlatformOne.transform.position.x, movingPlatformTwo.transform.position.y, movingPlatformOne.transform.position.z);
                Debug.Log("coordinate");
                //mpo.movePlatformOne = false;
                //Destroy(player.GetComponent<Rigidbody>());
                Debug.Log("loop " + loopLength);
                //Move player right until for loop ends

                if (Convert.ToInt32(loopLength) > 2)
                {
                    loopLength = "2";
                }
                if (player.transform.position.x < playerPos.x + Convert.ToInt32(loopLength) + 1)
                {
                    Debug.Log("--> moving to the right :" + (player.transform.position.x + (Convert.ToInt32(loopLength) + 1)));
                    player.transform.position += Vector3.right * 1f * Time.deltaTime;
                                       
                    //Destroy(player.GetComponent<Rigidbody>());
                }
                //Check if the player is in the correct position
                //When coordinate is met, set it to that coordinate (ensuring it's an int)
                Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
                if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
                {
                    input.GetComponent<InputField>().interactable = true;
                    //player.AddComponent<Rigidbody>();
                    player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, 0);
                    Debug.Log(player.transform.position);

                    playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                    //loopLength = "0";

                    partOneDone = true;
                    Debug.Log("part one done is: " + partOneDone);
                    tutorial.hideTutorial();
                    tutorial.taskTwoActive = true;
                    movingPlayerRightIfStatement = false;
                    //movingPlayerRightIfStatement2 = false;
                }
            }           
        }
        if(movingPlayerRightIfStatement2 && !partTwoDone)
        {
            Debug.Log("x is correct? > -4.9 " + (player.transform.position.x > -4.9f));
            Debug.Log("stationary platform y: " + platform.transform.position.y);
            Debug.Log("inline to second and third: " + (movingPlatformTwo.transform.position.y <= platform.transform.position.y));
            if ((movingPlatformTwo.transform.position.y <= platform.transform.position.y) && (movingPlatformTwo.transform.position.y > 3.2f) && (player.transform.position.x >= -4.75f))
            {
                player.transform.position = new Vector3(player.transform.position.x, 7.75f, movingPlatformTwo.transform.position.z);
                movingPlatformTwo.transform.position = new Vector3(movingPlatformTwo.transform.position.x, platform.transform.position.y, movingPlatformTwo.transform.position.z);
                Debug.Log("inline to second and third: " + (movingPlatformTwo.transform.position.y <= platform.transform.position.y));
                //stopPlatformOne = true;
                //Destroy(player.GetComponent<Rigidbody>());
                Debug.Log("loop " + loopLength);
                //Move player right until for loop ends
                if (player.transform.position.x < playerPos.x + (Convert.ToInt32(loopLength) + 1))
                {
                    player.transform.position += Vector3.right * 1f * Time.deltaTime;

                    //Destroy(player.GetComponent<Rigidbody>());
                }
                //Check if the player is in the correct position
                //When coordinate is met, set it to that coordinate (ensuring it's an int)
                Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
                if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
                {
                    input.GetComponent<InputField>().interactable = true;
                    //player.AddComponent<Rigidbody>();
                    player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, 0);
                    Debug.Log(player.transform.position);

                    playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                    //loopLength = "0";

                    //Destroy(player.GetComponent<Rigidbody>());
                    //movingPlayerRight2 = false;
                    //partOneDone = false;
                        partTwoDone = true;
                        tutorial.taskThreeActive = true;
                    tutorial.hideTutorial();
                        movingPlayerRightIfStatement2 = false;
                        //movingPlayerRight = false;
                        //movingPlayerRightIfStatement = false;
                }
            }
        }
        if (movingPlayerRight3 && partTwoDone)
        {
            Debug.Log("_______________________________partThreeeee");
            //stopPlatformOne = true;
            Destroy(player.GetComponent<Rigidbody>());
            Debug.Log("loop " + loopLength);
            //Move player right until for loop ends
            if (player.transform.position.x < playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.right * 1f * Time.deltaTime;
                //Destroy(player.GetComponent<Rigidbody>());
            }
            //Check if the player is in the correct position
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
            if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                movingPlayerRight3 = false;
                input.GetComponent<InputField>().interactable = true;
                //player.AddComponent<Rigidbody>();
                player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, 0);
                Debug.Log(player.transform.position);

                playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                //loopLength = "0";

                if (player.transform.position.x >= 4f)
                {
                    partThreeDone = true;                    
                    tutorial.hideTutorial();
                    movingPlayerRight3 = false;
                }
                //movingPlayerRightIfStatement2 = false;
            }
        }        
    }

    void onRunClick()
    {
        runClicked = true;

        //hide error/hint box
        errorBox.GetComponent<MeshRenderer>().enabled = false;
        errorTitle.GetComponent<Text>().enabled = false;
        errorTitleUnderline.GetComponent<Text>().enabled = false;
        errorMessage.GetComponent<Text>().enabled = false;
        dismissErrorButton.GetComponent<Button>().enabled = false;
        dissmissErrorButtonText.GetComponent<Text>().enabled = false;

        Debug.Log("Button was clicked!");

        if (!partOneDone && runClicked)
        {
            movePlayer();
        }
        if (partOneDone && !partTwoDone && runClicked)
        {
            Debug.Log("__________________part two");
            movePlayerPartTwo();
        }
        if (partTwoDone && runClicked)
        {
            movePlayerPartThree();
        }
        if (partThreeDone)
        {
            Debug.Log("GAME OVER");
        }
    }

    void onResetClick()
    {
        Application.LoadLevel("FinalLevel");
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

    public void dismissError()
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

    void movePlayer()
    {
        Debug.Log("11111 one");
        inputCopy = input.text;
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        Debug.Log(inputCopy);

        if (inputCopy == "")
        {
            Debug.Log("Input field is empty");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Input field is empty.";

        }
        else if (inputCopy.Length < 4)
        {
            Debug.Log("The function is unfinished");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The function is unfinished.";
        }
        else if (inputCopy.Contains("platformOne") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'platformOne' is missing.";
        }
        else if (inputCopy.Contains("platformTwo") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'platformTwo' is missing.";
        }
        else if (inputCopy.Contains("box") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'box' is missing.";
        }
        else if (inputCopy.Substring(inputCopy.Length - 1, 1) != "}")
        {
            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Are you missing a curly bracket?";
        }
        else if ((Regex.IsMatch(inputCopy, @"if\((platformOne)\.[y]==[platformTwo]+.y\){for\(int[\w]=0;i<\d;i\+\+\){[\w]+.x\+\+;}}") == false))
        {
            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Expression does not match.";
        }

        //Check if moving player using the if statement
        if (Regex.IsMatch(inputCopy, @"if\((platformOne)\.[y]==[platformTwo]+.y\){for\(int[\w]=0;i<\d;i\+\+\){[\w]+.x\+\+;}}"))        
        {            
            Debug.Log("Move player if statement! :D");
            //If statement object
            int objectNamePos = inputCopy.IndexOf("(");
            int dotPos = inputCopy.IndexOf(".");
            objectName = inputCopy.Substring(objectNamePos + 1, dotPos - 3);
            Debug.Log("object name: " + objectName);

            //If statement object2
            int objectNamePos2 = inputCopy.IndexOf("=");
            int bracketPos = inputCopy.IndexOf(")");
            Debug.Log(bracketPos - 1);
            objectName2 = inputCopy.Substring(objectNamePos2 + 2, bracketPos - 4 - objectNamePos2);
            Debug.Log("object name 2: " + objectName2);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);

            //Find if the object to move is player
            int semicolonPos = inputCopy.IndexOf(";");
            objectToMove = inputCopy.Substring(semicolonPos + 10, 6);

            Debug.Log("object to move: " + objectToMove);
            Debug.Log("object name2: " + objectName2);
            Debug.Log("loop length: " + loopLength);
            correctAnswerTimer = 2f;
            movingPlayerRightIfStatement = true;
            input.GetComponent<InputField>().interactable = false;
            tutorial.hideTutorial();
        }
        //Check if for loop if moving player using a simple for loop
        /*else if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(\s*[\w]+\S\.([x])\+\+\;)*\s*}"))    //match regex player.y=100;
        {
            inputEntered = true;
            Debug.Log("Move player! :D");
            //Find the object name in the string
            int objectNamePos = inputCopy.IndexOf("{");
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);

            Debug.Log("object name: " + objectName);
            Debug.Log("loop length: " + loopLength);

            //Check if correct variable name is used
            if (inputCopy.Contains("player"))
            {
                Debug.Log("variable name exists! :D");
                movingPlayerRight = true;
            }
            else
            {
                Debug.Log("variable name does not exist");
            }
        }   */
        runClicked = false;
    }

    void movePlayerPartTwo()
    {
        Debug.Log("222222 partTwoo");
        inputCopy = input.text;
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        Debug.Log(inputCopy);

        if (inputCopy == "")
        {
            Debug.Log("Input field is empty");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Input field is empty.";

        }
        else if (inputCopy.Length < 4)
        {
            Debug.Log("The function is unfinished");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The function is unfinished.";
        }
        else if (inputCopy.Contains("platformTwo") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'platformTwo' is missing.";
        }
        else if (inputCopy.Contains("platformThree") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'platformThree' is missing.";
        }
        else if (inputCopy.Contains("box") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'box' is missing.";
        }
        else if (inputCopy.Substring(inputCopy.Length - 1, 1) != "}")
        {
            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Are you missing a curly bracket?";
        }
        else if ((Regex.IsMatch(inputCopy, @"if\((platformTwo)\.[y]==[platformThree]+.y\){for\(int[\w]=0;i<\d;i\+\+\){[\w]+.x\+\+;}}") == false))
        {
            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Expression does not match.";
        }

        //Check if moving player using the if statement
        if (Regex.IsMatch(inputCopy, @"if\((platformTwo)\.[y]==[platformThree]+.y\){for\(int[\w]=0;i<\d;i\+\+\){[\w]+.x\+\+;}}"))    //match regex if(platformOne.y==platformTwo.y){for(inti=0;i<2;i++){player.x++;}}
        {
            Debug.Log("Move player if statement! :D");
            //If statement object
            int objectNamePos = inputCopy.IndexOf("(");
            int dotPos = inputCopy.IndexOf(".");
            objectName = inputCopy.Substring(objectNamePos + 1, dotPos - 3);
            Debug.Log("object name: " + objectName);

            //If statement object2
            int objectNamePos2 = inputCopy.IndexOf("=");
            int bracketPos = inputCopy.IndexOf(")");
            Debug.Log(bracketPos - 1);
            objectName2 = inputCopy.Substring(objectNamePos2 + 2, bracketPos - 4 - objectNamePos2);
            Debug.Log("object name 2: " + objectName2);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);

            //Find if the object to move is player
            int semicolonPos = inputCopy.IndexOf(";");
            objectToMove = inputCopy.Substring(semicolonPos + 10, 6);

            Debug.Log("object to move: " + objectToMove);
            Debug.Log("object name2: " + objectName2);
            Debug.Log("loop length: " + loopLength);
            movingPlayerRightIfStatement2 = true;
            correctAnswerTimer = 2f;
            tutorial.hideTutorial();
            input.GetComponent<InputField>().interactable = false;
        }
        //Check if for loop if moving player using a simple for loop
        /*else if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(\s*[\w]+\S\.([x])\+\+\;)*\s*}"))    //match regex player.y=100;
        {
            inputEntered = true;
            Debug.Log("Move player! :D");
            //Find the object name in the string
            int objectNamePos = inputCopy.IndexOf("{");
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);

            Debug.Log("object name: " + objectName);
            Debug.Log("loop length: " + loopLength);

            //Check if correct variable name is used
            if (inputCopy.Contains("player"))
            {
                Debug.Log("variable name exists! :D");
                movingPlayerRight2 = true;
            }
            else
            {
                Debug.Log("variable name does not exist");
            }
        }*/
        runClicked = false;
    }

    void movePlayerPartThree()
    {
        Debug.Log("333333 three");
        inputCopy = input.text;
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        Debug.Log(inputCopy);
        if (inputCopy == "")
        {
            Debug.Log("Input field is empty");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Input field is empty.";

        }
        else if (inputCopy.Length < 4)
        {
            Debug.Log("The function is unfinished");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The function is unfinished.";
        }
        else if (inputCopy.Contains("box") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'box' is missing.";
        }
        else if (inputCopy.Substring(inputCopy.Length - 1, 1) != "}")
        {
            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Are you missing a curly bracket?";
        }
        else if ((Regex.IsMatch(inputCopy, @"^(?!{\S)for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*\d{1,2}\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(box\.([x])\+\+\;)*\s*}") == false))
        {
            //show error/hint box
            tutorial.hideTutorial();
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Expression does not match.";
        }

        //Check if moving player using the if statement
        if (Regex.IsMatch(inputCopy, @"^(?!{\S)for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*\d{1,2}\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(box\.([x])\+\+\;)*\s*}"))    //match regex if(platformOne.y==platformTwo.y){for(inti=0;i<2;i++){box.x++;}}
        {
            Debug.Log("Move box if statement! :D");
            //If statement object
            int objectNamePos = inputCopy.IndexOf("(");
            int dotPos = inputCopy.IndexOf(".");
            objectName = inputCopy.Substring(objectNamePos + 1, dotPos - 3);
            Debug.Log("object name: " + objectName);

            //If statement object2
            int objectNamePos2 = inputCopy.IndexOf("=");
            int bracketPos = inputCopy.IndexOf(")");
            Debug.Log(bracketPos - 1);
            objectName2 = inputCopy.Substring(objectNamePos2 + 2, bracketPos - 4 - objectNamePos2);
            Debug.Log("object name 2: " + objectName2);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);

            //Find if the object to move is player
            int semicolonPos = inputCopy.IndexOf(";");
            objectToMove = inputCopy.Substring(semicolonPos + 10, 6);

            Debug.Log("object to move: " + objectToMove);
            Debug.Log("object name2: " + objectName2);
            Debug.Log("loop length: " + loopLength);

            movingPlayerRight3 = true;
            correctAnswerTimer = 2f;
            input.GetComponent<InputField>().interactable = false;
            tutorial.hideTutorial();
        }
        runClicked = false;
    }

    void reset()
    {
        player.transform.position = new Vector3(-7.75f, 11.25f, 0f);
        player.transform.rotation = Quaternion.identity;

        movingPlatformOne.transform.position = new Vector3(-7.75f, 9.25f, 0f);
        movingPlatformOne.transform.rotation = Quaternion.identity;

        movingPlatformTwo.transform.position = new Vector3(-4.75f, 6.5f, 0f);
        movingPlatformTwo.transform.rotation = Quaternion.identity;

        platform.transform.position = new Vector3(0.75f, 3.25f, 0f);
        movingPlatformTwo.transform.rotation = Quaternion.identity;

        exit.transform.position = new Vector3(2.75f, 8.25f, 0f);
        exit.transform.rotation = Quaternion.identity;
        Destroy(exit.GetComponent<Rigidbody>());
    }
}
