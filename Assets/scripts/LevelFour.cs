using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;

public class LevelFour : MonoBehaviour
{
    //Tutorial references
    levelFourTutorial tutorial;

    //user input
    private InputField input;
    private string inputCopy;

    //objects in the scene
    public Button run;
    public Button resetButton;
    public GameObject platformOne;
    public GameObject platformTwo;
    public GameObject platformThree;
    public GameObject player;

    private GameObject platformToMove;

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
    private string coordinate;
    private string functionName;
    private string intValue;

    //correct answer
    public GameObject correctAnswerBox;
    public Text correctAnswerText;
    public Button correctAnswerDismissButton;
    public Text correctAnswerDismissButtonText;

    private float correctAnswerTimer = 2f;
    //levelComplete
    private bool partOneDone = false;
    private bool partTwoDone = false;
    private bool partThreeDone = false;
    private bool partFourDone = false;
    private bool movingPlayer = false;
    private bool levelCompleted = false;
    private bool movingPlatformLower = false;
    private bool movingPlatformHigher = false;
    private bool movingPlayerLeft = false;
    private bool movingPlayerRight = false;
    private bool runClicked = false;
    private int platformCounter = 0;


    // Use this for initialization
    void Start()
    {
        tutorial = GameObject.FindObjectOfType(typeof(levelFourTutorial)) as levelFourTutorial;
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
        tutorial.tutorialCounter0();
    }

    void Update()
    {
        if (partOneDone)
        {
            if (correctAnswerTimer >= 0f)
            {
                correctAnswerTimer -= Time.deltaTime;

                //input.GetComponent<InputField>().interactable = false;

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
        if(partTwoDone)
        {
            if (correctAnswerTimer >= 0f)
            {
                correctAnswerTimer -= Time.deltaTime;

                input.GetComponent<InputField>().interactable = false;

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
                input.GetComponent<InputField>().interactable = true;

                //hide correct answer
                correctAnswerBox.GetComponent<MeshRenderer>().enabled = false;
                correctAnswerText.GetComponent<Text>().enabled = false;
                correctAnswerDismissButton.GetComponent<Image>().enabled = false;
                correctAnswerDismissButtonText.GetComponent<Text>().enabled = false;
            }
        }

        //Moving the platform up/down: Part One
        //going down
        /*if (movingPlatformLower)
        {
            //Move down until for loop ends
            if (movingPlatform.transform.position.y > movingPlatformPos.y - Convert.ToInt32(intValue))
            {
                movingPlatform.transform.position += Vector3.down * 1f * Time.deltaTime;
            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(movingPlatform.transform.position.y <= movingPlatformPos.y + (Convert.ToInt32(loopLength) + 1));
            if (movingPlatform.transform.position.y <= movingPlatformPos.y - (Convert.ToInt32(loopLength) + 1))
            {
                movingPlatform.transform.position = new Vector3(movingPlatform.transform.position.x, movingPlatformPos.y - (Convert.ToInt32(loopLength) + 1), movingPlatform.transform.position.z);
                movingPlatformLower = false;
                movingPlatformPos.y = movingPlatformPos.y - (Convert.ToInt32(loopLength) + 1);
                Debug.Log(movingPlatform.transform.position);
                loopLength = "0";
                input.text = "";

                //Check if the movingPlatform is in the correct position
                if (movingPlatform.transform.position.y == 7f)
                {
                    partOneDone = true;
                    Debug.Log("Part One done! :D");
                }
            }
        }*/

        //going up
        if (partTwoDone)
        {
            Debug.Log("moving moving moving");
            //Move up until for loop ends
            if(movingPlatformPos.y + (Convert.ToInt32(intValue)) > 9)
            {
                intValue = "2";
            }
            if (platformToMove.transform.position.y < movingPlatformPos.y + (Convert.ToInt32(intValue)))
            {
                platformToMove.transform.position += Vector3.up * 1f * Time.deltaTime;
                input.GetComponent<InputField>().interactable = false;                         
            }
            
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            //Debug.Log(platformToMove.transform.position.y >= movingPlatformPos.y + (Convert.ToInt32(intValue)));
            if (platformToMove.transform.position.y >= movingPlatformPos.y + (Convert.ToInt32(intValue)))
            {
                input.GetComponent<InputField>().interactable = true;
                platformToMove.transform.position = new Vector3(platformToMove.transform.position.x, movingPlatformPos.y + (Convert.ToInt32(intValue)), platformToMove.transform.position.z);
                Debug.Log(platformToMove.transform.position);
                //movingPlatformHigher = false;
                //movingPlatformPos.y = movingPlatformPos.y + (Convert.ToInt32(intValue));
                intValue = "0";
                //input.text = "";

                //Check if the movingPlatform is in the correct position
                if (platformToMove.transform.position.y == 9f)
                {
                    if (partTwoDone)
                    {
                        if(tutorial.taskThreeAnswerActive == false)
                        {
                            tutorial.taskThree();
                        }
                        else
                        {
                            tutorial.taskThreeAnswer();
                        }
                    }
                    platformCounter++;
                    partTwoDone = false;
                    Debug.Log("Part One done! :D");
                }
            }

            if(platformCounter == 3)
            {
                input.text = "";
                partThreeDone = true;
                Debug.Log("PART THREE DONE!");
                tutorial.taskFour();
            }
        }

        //Moving the player left/right: Part Two
        //left
        /*if (movingPlayerLeft)
        {
            //Move down until for loop ends
            if (player.transform.position.x > playerPos.x - (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.left * 1f * Time.deltaTime;
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
                input.text = "";

                //Check if the movingPlatform is in the correct position
                if (player.transform.position.x == 3f)
                {
                    partTwoDone = true;
                    Debug.Log("Part Two done! :D");
                }
            }
        }*/

        //right
        if (partThreeDone && movingPlayer)
        {
            Debug.Log("part three done & moving player");
            //Move up until for loop ends
            if (player.transform.position.x < playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.right * 1f * Time.deltaTime;
                input.GetComponent<InputField>().interactable = false;

                //Check if the movingPlatform is in the correct position
                if (player.transform.position.x >= 4f)
                {
                    partFourDone = true;
                    Application.LoadLevel("LevelFive");
                    Debug.Log("Complete!!!! :D");
                }
            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
            if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                input.GetComponent<InputField>().interactable = true;
                player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, player.transform.position.z);
                Debug.Log(player.transform.position);
                movingPlayerRight = false;
                playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                loopLength = "0";
                input.text = "";               
            }
        }
    }

    void onRunClick()
    {
        runClicked = true;
        Debug.Log("Button was clicked!");

        if (partThreeDone && runClicked)
        {
            Debug.Log("part three is done");
            movePlayer();
        }
        if (partOneDone == false && runClicked)
        {
            makeFunction();
        }
        if (partOneDone && runClicked)
        {
            movePlatform();
        }
        if(!partThreeDone && partTwoDone && platformCounter < 3 && runClicked)
        {
            Debug.Log("part two and counter < 3");
            movePlatform();
            //partTwoDone = false;
            //Debug.Log("Complete!");
        }        
    }

    void onResetClick()
    {
        Application.LoadLevel("LevelFour");
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

    void makeFunction()
    {
        inputCopy = input.text;
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
        else if (inputCopy.Length < 4)
        {
            Debug.Log("The function is unfinished");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The function is unfinished.";
        }
        else if(inputCopy.Substring(0,4) != "void")
        {
            Debug.Log("The function must start with 'void'");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The function must start with 'void'.";
        }
        else if (inputCopy.Contains("object") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'object' is missing.";
        }
        else if (inputCopy.Contains("int") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'int' is missing.";
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
        else if ((Regex.IsMatch(inputCopy, @"void[\w]+\([object]+[platform]+\,int(x)\){for\(int(\w*)\s?=\s?[0]\s?\;\s*\2\s*[<]?=?\s*x-1\s*\;((\s*\2([++])\5)|(\s*\2\s*=\s*\2\s*[+/*-]\s*[1-9]))\s*\)\s*{[platform]+\S\.([y])\+\+;}}") == false))
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

        Debug.Log(inputCopy);

        //Check if for loop if statement matches: moving platform going down
        if (Regex.IsMatch(inputCopy, @"void[\w]+\([object]+[platform]+\,int(x)\){for\(int(\w*)\s?=\s?[0]\s?\;\s*\2\s*[<]?=?\s*x-1\s*\;((\s*\2([++])\5)|(\s*\2\s*=\s*\2\s*[+/*-]\s*[1-9]))\s*\)\s*{[platform]+\S\.([y])\+\+;}}"))    //match regex voidmoveUp(objectplatform,intx){for(inti=0;i<x;i++){platform.y++;}}
        {
            /*int objectNamePos = inputCopy.IndexOf("{");
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);*/

            //Pick up the function name
            int functionNamePos = 3;
            int leftBracketPos = inputCopy.IndexOf("(");
            functionName = inputCopy.Substring(functionNamePos + 1, leftBracketPos - functionNamePos - 1);

            Debug.Log("function name: " + functionName);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);
            Debug.Log("loop length: " + loopLength);
            partOneDone = true;
            //tutorial.taskTwo();           
            //if(tutorial.tas)
            if(tutorial.taskThreeActive)
            {
                Debug.Log("task three is active = task three");
                tutorial.taskThree();
            }
            else if(tutorial.taskThreeAnswerActive)
            {
                Debug.Log("task three answer is active = task three answer");
                tutorial.taskThreeAnswer();
            }
            else if (!tutorial.taskThreeActive)
            {
                Debug.Log("task three is not active = task two");
                tutorial.taskTwo();
            }
            correctAnswerTimer = 2f;
            input.text = "";
        }

        runClicked = false;
    }

    void movePlatform()
    {
        inputCopy = input.text;
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
        else if(inputCopy.Length < 4)
        {
            Debug.Log("The function is unfinished");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The function is unfinished.";
        }
        else if (inputCopy.Contains(functionName) == false)
        {
            Debug.Log("function name does not exist");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Is the function name correct?";
        }
        else if (inputCopy.Substring(inputCopy.Length - 1, 1) != ";")
        {
            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "Are you missing a semicolon?";
        }
        else if ((Regex.IsMatch(inputCopy, @"[\w]+\([\w]+\,\d\);") == false))
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

        Debug.Log("inside movePlatform function");
        Debug.Log(inputCopy);
        if (Regex.IsMatch(inputCopy, @"[\w]+\([\w]+\,\d\);"))    //match regex moveup(platformOne,5);
        {
            Debug.Log("regex matches");
            if (inputCopy.Contains(functionName))
            {
                Debug.Log("function exists! :D");

                //Find how long the loop will run for in the string
                int intValuePos = inputCopy.IndexOf(")");
                intValue = inputCopy.Substring(intValuePos - 1, 1);
                Debug.Log("intValue: " + intValue);

                if (inputCopy.Contains("platformOne") || inputCopy.Contains("platformTwo") || inputCopy.Contains("platformThree"))
                {
                    //Find the object player wants to move in the string                  
                    int objectNamePos = inputCopy.IndexOf("(");
                    objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 5 - objectNamePos);
                    Debug.Log("object to move is: " + objectName);

                    if (inputCopy.Contains("platformOne") && platformCounter < 3 && platformOne.transform.position.y != 9)
                    {
                        platformToMove = platformOne;
                        movingPlatformPos = platformToMove.transform.position;
                        Debug.Log("platform to move eposition is 1: " + movingPlatformPos);
                    }
                    else if (inputCopy.Contains("platformTwo") && platformCounter < 3 && platformTwo.transform.position.y != 9)
                    {
                        platformToMove = platformTwo;
                        movingPlatformPos = platformToMove.transform.position;
                        Debug.Log("platform to move eposition is 2: " + movingPlatformPos);
                    }
                    else if (inputCopy.Contains("platformThree") && platformCounter < 3 && platformThree.transform.position.y != 9)
                    {
                        platformToMove = platformThree;
                        movingPlatformPos = platformToMove.transform.position;
                        Debug.Log("platform to move eposition is 3: " + movingPlatformPos);
                    }

                    partTwoDone = true;
                    correctAnswerTimer = 2f;
                    if (platformCounter >= 1)
                    {
                        if (tutorial.taskThreeAnswerActive == false)
                        {
                            tutorial.taskThree();
                        }
                        else
                        {
                            tutorial.taskThreeAnswer();
                        }
                    }
                    else
                    {
                        tutorial.taskTwo();
                    }
                    //input.text = "";
                }
                else
                {
                    //show error/hint box
                    errorBox.GetComponent<MeshRenderer>().enabled = true;
                    errorTitle.GetComponent<Text>().enabled = true;
                    errorTitleUnderline.GetComponent<Text>().enabled = true;
                    errorMessage.GetComponent<Text>().enabled = true;
                    dismissErrorButton.GetComponent<Button>().enabled = true;
                    dissmissErrorButtonText.GetComponent<Text>().enabled = true;

                    errorMessage.text = "The object you are trying to move does not exist.";
                }
            }
        }
        runClicked = false;
    }

    void movePlayer()
    {
        inputCopy = input.text;
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        if (!inputCopy.Contains("box"))
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
        else if ((Regex.IsMatch(inputCopy, @"^(?!{\S)for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(box\.([x])\-\-\;)*\s*}") == false))       
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
        if (Regex.IsMatch(inputCopy, @"^(?!{\S)for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(box\.([x])\+\+\;)*\s*}"))    //match regex box.x--;
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
            movingPlayer = true;
            correctAnswerTimer = 2f;
        }
        //Check if for loop if statement matches: moving platform going down
        /*if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*\d\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(player\.([x])\+\+\;)*\s*}"))    //match regex player.x++;
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

            //Check if correct variable name is used
            if (inputCopy.Contains("player"))
            {
                Debug.Log("variable name exists! :D");
                partThreeDone = true;
            }
            else
            {
                Debug.Log("variable name does not exist");
            }
        }*/

        runClicked = false;
    }
}