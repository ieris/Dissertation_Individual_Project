using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using System;

public class LevelFive : MonoBehaviour
{
    //user input
    private InputField input;
    private string inputCopy;

    public GameObject movingPlatform;
    public GameObject platformOne;
    public GameObject player;
    public Button run;
    public Button resetButton;

    //store coordinatees
    private Vector3 playerPos;

    private float timer = 1f;

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
    private string loopLength;
    private string objectToMove;

    //levelComplete
    private bool back = false;
    private bool playerBack = false;
    private bool partOneDone = false;
    private bool partTwoDone = false;
    private bool partThreeDone = false;
    private bool movingPlayer = false;
    private bool movingPlayerPartTwo = false;
    private bool movingPlayerLeft = false;
    private bool movingPlayerRight = false;
    private bool platformReachedPosition = false;
    private bool runClicked = false;


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
        //Move the platform back and forth
        if (!back && platformReachedPosition == false)
        {
            //Debug.Log("right");
            movingPlatform.transform.position += Vector3.right * 0.75f * Time.deltaTime;

            if (movingPlatform.transform.position.x >= -0.75f)
            {
                /*if(timer >= 0)
                {
                    timer -= Time.deltaTime;
                }
                else
                {*/
                    back = true;
                   // timer = 1f;
                //}              
            }
        }
        if (back && platformReachedPosition == false)
        {
            //Debug.Log("left");
            movingPlatform.transform.position += Vector3.left * 0.75f * Time.deltaTime;

            if (movingPlatform.transform.position.x <= -7.75f)
            {
                back = false;
            }
        }

        //Move the player on the platform back and forth
        if (!playerBack && platformReachedPosition == false)
        {
            //Debug.Log("right");
            player.transform.position += Vector3.right * 0.75f * Time.deltaTime;

            if(player.transform.position.x == platformOne.transform.position.x)
            {
                Debug.Log("hello");
            }
            else if (player.transform.position.x >= -0.75f)
            {
                playerBack = true;

            }
        }
        if (playerBack && platformReachedPosition == false)
        {
            //Debug.Log("left");
            player.transform.position += Vector3.left * 0.75f * Time.deltaTime;

            if (player.transform.position.x <= -7.75f)
            {
                playerBack = false;
            }
        }

        if(movingPlayer)
        {
            //Debug.Log("moving");
            //Moving platform position
            if (movingPlatform.transform.position.x >= -0.78f)
            {
                platformReachedPosition = true;
                Debug.Log("platform reached position");
                //Move up until for loop ends                
            }
        }
        if(movingPlayerPartTwo)
        {
            if(player.transform.position.x < playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.right * 1f * Time.deltaTime;
            }

            if(player.transform.position.x >= 4f)
            {
                partThreeDone = true;
                Application.LoadLevel("FinalLevel");
                input.text = "";
            }
        }

        if(platformReachedPosition)
        {
            movingPlatform.transform.position = new Vector3(-0.75f, movingPlatform.transform.position.y, movingPlatform.transform.position.z);

            if (player.transform.position.x < -0.75f + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.right * 1f * Time.deltaTime;
                partTwoDone = true;
            }

            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            //Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
            if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                //player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, player.transform.position.z);
                //Debug.Log(player.transform.position);

                playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                Debug.Log("player position: " + playerPos.x);
                if (player.transform.position.x >= 4f)
                {
                    partThreeDone = true;
                    Application.LoadLevel("FinalLevel");
                    input.text = "";
                }
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

        if (partOneDone == false)
        {
            movePlayer();
        }
        if (partOneDone)
        {
            movingPlayer = true;
        }
        if (partTwoDone && runClicked)
        {
            movePlayerPartTwo();
        }
    }

    void onResetClick()
    {
        Application.LoadLevel("LevelFive");
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
        Debug.Log("Part Two! :D");
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

            errorMessage.text = "The variable type 'movingPlatform' is missing.";
        }
        else if (inputCopy.Contains("platformOne") == false)
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable type 'platformOne' is missing.";
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
        else if ((Regex.IsMatch(inputCopy, @"if\(([\w]+)\.[x][+]\1.width==[\w]+.x\){for\(int[\w]=0;i<\d;i\+\+\){[\w]+.x\+\+;}}") == false))
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
        /*if (Regex.IsMatch(inputCopy, @"if\([\w]+\.[x][+][\w]+.width==[\w]+.x\){for\(int[\w]=0;i<\d;i\+\+\){[\w]+.x\+\+;}}"))    //match regex if(movingPlatform.x+movingPlatform.width==platformOne.x){for(inti=0;i<2;i++){player.x++;}}
        {
            //Find the object name in the string
            int objectNamePos = inputCopy.IndexOf("{");
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);
            Debug.Log("object name: " + objectName);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);

            Debug.Log("loop length: " + loopLength);

            //Check if correct variable name is used
            if (inputCopy.Contains("player"))
            {
                Debug.Log("variable name exists! :D");
                movingPlayerLeft = true;
            }
            else
            {
                Debug.Log("variable name does not exist");
            }
        }*/
        //Check if for loop if statement matches: moving platform going up
        if (Regex.IsMatch(inputCopy, @"if\(([\w]+)\.[x][+]\1.width==[\w]+.x\){for\(int[\w]=0;i<\d;i\+\+\){[\w]+.x\+\+;}}"))    //match regex if(movingPlatform.x+movingPlatform.width==platformOne.x){for(inti=0;i<2;i++){player.x++;}}
        {
            Debug.Log("MATCHES!");
            //If statement object
            int objectNamePos = inputCopy.IndexOf("(");
            int dotPos = inputCopy.IndexOf(".");
            objectName = inputCopy.Substring(objectNamePos + 1, dotPos - 3);
            Debug.Log("object name: " + objectName);

            //If statement object2
            int objectNamePos2 = inputCopy.IndexOf("=");
            int bracketPos = inputCopy.IndexOf(")");
            //Debug.Log(bracketPos - 1);
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
            partOneDone = true;
        }
        runClicked = false;
    }

    void movePlayerPartTwo()
    {
        inputCopy = input.text;
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(player\.([x])\+\+\;)*\s*}"))    //match regex if(movingPlatform.x+movingPlatform.width==platformOne.x){for(inti=0;i<2;i++){player.x++;}}
        {
            Debug.Log("moving right again");
            //Find the object name in the string
            int objectNamePos = inputCopy.IndexOf("{");
            Debug.Log(objectNamePos);
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);
            Debug.Log(objectName);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            Debug.Log(loopLength);
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);
            Debug.Log(loopLength);

            Debug.Log("object name: " + objectName);
            Debug.Log("loop length: " + loopLength);
            movingPlayerPartTwo = true;
            runClicked = false;
        }
    }
}
