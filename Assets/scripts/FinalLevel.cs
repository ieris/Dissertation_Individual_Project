﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class FinalLevel : MonoBehaviour
{
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

    //platform movement back and forth
    private bool movingPlatformOneBool = true;
    private bool movingPlatformTwoBool = false;
    private bool playerBool = false;

    //levelComplete
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
        input = GetComponent<InputField>();
        run.onClick.AddListener(onRunClick);
        resetButton.onClick.AddListener(onResetClick);
        dismissErrorButton.onClick.AddListener(onDismissClick);

        //hide error/hint box
        errorBox.GetComponent<MeshRenderer>().enabled = false;
        errorTitle.GetComponent<Text>().enabled = false;
        errorTitleUnderline.GetComponent<Text>().enabled = false;
        errorMessage.GetComponent<Text>().enabled = false;
        dismissErrorButton.GetComponent<Button>().enabled = false;
        dissmissErrorButtonText.GetComponent<Text>().enabled = false;

        //Store original object coordinates
        playerPos = player.transform.position;
    }
	
	void Update ()
    {       
        if(movingPlatformOne.transform.position.y == movingPlatformTwo.transform.position.y)
        {
            Debug.Log("NOW!");
        }
        if (inputEntered == false)
        {
            //player.transform.position += Vector3.down * 0.75f * Time.deltaTime;
        }

        if (movingPlayerRightIfStatement)
        {
            if(((movingPlatformOne.transform.position.y <= movingPlatformTwo.transform.position.y) && (movingPlatformOne.transform.position.y > 6.49f) && player.transform.position.x < -4.7))
            {
                inputEntered = true;
                //stopPlatformOne = true;
                Destroy(player.GetComponent<Rigidbody>());
                Debug.Log("loop " + loopLength);
                //Move player right until for loop ends

                if (Convert.ToInt32(loopLength) > 2)
                {
                    loopLength = "2";
                }
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
                    player.AddComponent<Rigidbody>();
                    player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, player.transform.position.z);
                    Debug.Log(player.transform.position);

                    playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                    loopLength = "0";
                    input.text = "";

                    inputEntered = false;
                    partOneDone = true;
                    movingPlayerRightIfStatement = false;
                    //movingPlayerRightIfStatement2 = false;
                }
            }           
        }
        if(movingPlayerRightIfStatement2)
        {
            Debug.Log("x is correct? > -4.9 " + (player.transform.position.x > -4.9f));
            Debug.Log("stationary platform y: " + platform.transform.position.y);
            Debug.Log("inline to second and third: " + (movingPlatformTwo.transform.position.y <= platform.transform.position.y));
            if ((movingPlatformTwo.transform.position.y <= platform.transform.position.y) && (movingPlatformTwo.transform.position.y > 3.2f) && (player.transform.position.x >= -4.75f))
            {
                Debug.Log("inline to second and third: " + (movingPlatformTwo.transform.position.y <= platform.transform.position.y));
                inputEntered = true;
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
                    player.AddComponent<Rigidbody>();
                    player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, player.transform.position.z);
                    Debug.Log(player.transform.position);

                    playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                    loopLength = "0";
                    input.text = "";

                    //Destroy(player.GetComponent<Rigidbody>());
                    //movingPlayerRight2 = false;
                    //partOneDone = false;
                        partTwoDone = true;
                        movingPlayerRightIfStatement2 = false;
                        //movingPlayerRight = false;
                        //movingPlayerRightIfStatement = false;
                        inputEntered = false;
                }
            }
        }
        if (movingPlayerRight3)
        {
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
                player.AddComponent<Rigidbody>();
                player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, player.transform.position.z);
                Debug.Log(player.transform.position);

                playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                loopLength = "0";
                input.text = "";

                inputEntered = false;
                partThreeDone = true;
                //movingPlayerRight = false;
                movingPlayerRightIfStatement = false;
                //movingPlayerRightIfStatement2 = false;
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

        if(movingPlayerRightIfStatement == false && !partOneDone)
        {
            movePlayer();
        }
        if (movingPlayerRightIfStatement == false && movingPlayerRightIfStatement2 == false)
        {
            movePlayerPartTwo();
        }
        if(partTwoDone)
        {
            movePlayerPartThree();
        }
        if(partThreeDone)
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

    void movePlayer()
    {
        inputCopy = input.text;
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        Debug.Log(inputCopy);

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
        else if (inputCopy.Contains("player") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'player' is missing.";
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
        else if ((Regex.IsMatch(inputCopy, @"if\(([\w]+)\.[y]==[\w]+.y\){for\(int[\w]=0;i<\d;i\+\+\){[\w]+.x\+\+;}}") == false))
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

        //Check if moving player using the if statement
        if (Regex.IsMatch(inputCopy, @"if\(([\w]+)\.[y]==[\w]+.y\){for\(int[\w]=0;i<\d;i\+\+\){[\w]+.x\+\+;}}"))        
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
            movingPlayerRightIfStatement = true;
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
    }

    void movePlayerPartTwo()
    {
        inputCopy = input.text;
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        Debug.Log(inputCopy);

        if (input == null)
        {
            Debug.Log("Input field is empty");
        }

        //Check if moving player using the if statement
        if (Regex.IsMatch(inputCopy, @"if\(([\w]+)\.[y]==[\w]+.y\){for\(int[\w]=0;i<\d;i\+\+\){[\w]+.x\+\+;}}"))    //match regex if(platformOne.y==platformTwo.y){for(inti=0;i<2;i++){player.x++;}}
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
    }

    void movePlayerPartThree()
    {
        inputCopy = input.text;
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        Debug.Log(inputCopy);

        if (input == null)
        {
            Debug.Log("Input field is empty");
        }

        //Check if moving player using the if statement
        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*\d{1,2}\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(player\.([x])\+\+\;)*\s*}"))    //match regex if(platformOne.y==platformTwo.y){for(inti=0;i<2;i++){player.x++;}}
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

            //Check if correct variable name is used
            //if (objectToMove == "player")
            //{
                //Debug.Log("let's move the player! :D");
                movingPlayerRight3 = true;
            //}
            //else
            //{
            //    Debug.Log("cannot move this");
            //}
        }
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
