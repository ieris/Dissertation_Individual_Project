using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class LevelTwo : MonoBehaviour
{
    //Tutorial references
    levelTwoTutorial tutorial;

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
    public GameObject player;
    public GameObject fp1;
    public GameObject fp2;
    public GameObject fp3;
    public GameObject fp4;

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
    private string loopLength;
    private string speedVarLength;

    //levelComplete
    private bool partOneDone = false;
    private bool partTwoDone = false;
    private bool movingPlayerLeft = false;
    private bool movingPlayerRight = false;
    private bool movingPlayerLeftWithSpeed = false;
    private bool movingPlayerRightWithSpeed = false;
    private bool runClicked = false;

    // Use this for initialization
    void Start()
    {
        tutorial = GameObject.FindObjectOfType(typeof(levelTwoTutorial)) as levelTwoTutorial;
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
        tutorial.taskOne();
    }

    void Update()
    {
        if (movingPlayerLeft || movingPlayerRight)
        {
            if (correctAnswerTimer >= 0f)
            {
                correctAnswerTimer -= Time.deltaTime;

                //show correct answer
                correctAnswerBox.GetComponent<MeshRenderer>().enabled = true;
                correctAnswerText.GetComponent<Text>().enabled = true;
                correctAnswerDismissButton.GetComponent<Image>().enabled = true;
                correctAnswerDismissButtonText.GetComponent<Text>().enabled = true;

                errorBox.GetComponent<MeshRenderer>().enabled = false;
                errorTitle.GetComponent<Text>().enabled = false;
                errorTitleUnderline.GetComponent<Text>().enabled = false;
                errorMessage.GetComponent<Text>().enabled = false;
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

        if (partOneDone)
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
                correctAnswerText.text = "Correct!";

                errorBox.GetComponent<MeshRenderer>().enabled = false;
                errorTitle.GetComponent<Text>().enabled = false;
                errorTitleUnderline.GetComponent<Text>().enabled = false;
                errorMessage.GetComponent<Text>().enabled = false;
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
        if (partTwoDone)
        {
            if (correctAnswerTimer >= 0f)
            {
                correctAnswerTimer -= Time.deltaTime;

                //show correct answer
                correctAnswerBox.GetComponent<MeshRenderer>().enabled = true;
                correctAnswerText.GetComponent<Text>().enabled = true;
                correctAnswerDismissButton.GetComponent<Image>().enabled = true;
                correctAnswerDismissButtonText.GetComponent<Text>().enabled = true;
                correctAnswerText.text = "Correct!";

                errorBox.GetComponent<MeshRenderer>().enabled = false;
                errorTitle.GetComponent<Text>().enabled = false;
                errorTitleUnderline.GetComponent<Text>().enabled = false;
                errorMessage.GetComponent<Text>().enabled = false;
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

        //Moving the player left/right: Part Two
        //left
        if (movingPlayerLeft)
        {
            //Move down until for loop ends
            if (player.transform.position.x > playerPos.x - (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.left * 1f * Time.deltaTime;
                //correctAnswerTimer = 2f;
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

                //Check if the player is in the correct position
                if (player.transform.position.y <= 2f)
                {                   
                    partOneDone = true;
                    tutorial.hideTutorial();
                    tutorial.taskTwo();
                    reset();
                    runClicked = false;
                    movingPlayerLeft = false;
                    Debug.Log("Part one done! :D");
                    input.text = "";
                }
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
                //correctAnswerTimer = 2f;
            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
            if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                input.GetComponent<InputField>().interactable = true;
                player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, player.transform.position.z);
                Debug.Log(player.transform.position);
                
                playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                loopLength = "0";
                input.text = "";
                inputCopy = "";

                //Check if the player is in the correct position
                if (player.transform.position.y <= 2f)
                {
                    Debug.Log("ddddd Part one done! :D");
                    partOneDone = true;                  
                    reset();                  
                    Debug.Log("part one done is: " + partOneDone);
                    tutorial.taskTwo();
                    input.text = "";
                    runClicked = false;
                    movingPlayerRight = false;
                }
            }
        }

        //right
        if (movingPlayerRightWithSpeed)
        {
            Debug.Log("moving player to the right");

            //Move up until for loop ends
            if (player.transform.position.x < playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.right * Convert.ToInt32(speedVarLength) * Time.deltaTime;
                //correctAnswerTimer = 2f;

                //Check if the player is in the correct position
                if (player.transform.position.x >= 3f)
                {
                    partTwoDone = true;
                    //tutorial.taskThree();
                    Application.LoadLevel("LevelThree");
                    Debug.Log("Part Two done! :D");
                }
            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
            if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, player.transform.position.z);
                Debug.Log(player.transform.position);
                movingPlayerRightWithSpeed = false;
                playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                loopLength = "0";
                input.text = "";
                inputCopy = "";

                //Check if the player is in the correct position
                if (player.transform.position.y <= 2f)
                {
                    Debug.Log("ddddd Part one done! :D");
                    partTwoDone = true;
                    reset();
                    tutorial.hideTutorial();
                    tutorial.taskTwo();
                    movingPlayerRight = false;
                    Debug.Log("part one done is: " + partOneDone);
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

        if (!partOneDone && runClicked)
        {
            movePlayer();
        }
        if (partTwoDone && runClicked)
        {
            movePlayerWithSpeed();
        }
        if (partOneDone && runClicked)
        {
            Debug.Log("yes");
            creatingSpeedVar();
            //movePlayerWithSpeed();
            Debug.Log(partOneDone && runClicked);
        }
        
    }

    void onResetClick()
    {
        Application.LoadLevel("LevelTwo");
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

    void creatingSpeedVar()
    {
        inputCopy = input.text;
        Debug.Log(inputCopy);
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
        else if (!inputCopy.Contains("speed"))
        {
            Debug.Log("The variable 'speed' does not exist");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable 'speed' is missing.";
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
        else if (Regex.IsMatch(inputCopy, @"int[speed]*=\d+;") == false)
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
        if (Regex.IsMatch(inputCopy, @"int[speed]*=\d+;"))    //match regex int speed = 3;
        {
            //Find the object name in the string
            int objectNamePos = 2;
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 4 - objectNamePos);
            Debug.Log("object name: " + objectName);

            //Find how long the loop will run for in the string
            int speedVarPosition = inputCopy.IndexOf("=");
            speedVarLength = inputCopy.Substring(speedVarPosition + 1, 1);

            Debug.Log("speed: " + speedVarLength);
            input.text = "";
            inputCopy = "";
            correctAnswerTimer = 5f;
            tutorial.taskThree();
            partTwoDone = true;
            runClicked = false;
        }
        runClicked = false;
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
        else if (!inputCopy.Contains("player"))
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable 'player' is missing.";
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
        else if ((Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*\d{1,2}\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(player\.([x])\-\-\;)*\s*}")) == false 
        && (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*\d{1,2}\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(player\.([x])\+\+\;)*\s*}")) == false)
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
        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*\d{1,2}\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(player\.([x])\-\-\;)*\s*}"))    //match regex player.y+=100;
        {
            //Find the object name in the string
            int objectNamePos = inputCopy.IndexOf("{");
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);
            Debug.Log("object name: " + objectName);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);
            movingPlayerLeft = true;
            correctAnswerTimer = 2f;
            runClicked = false;
            Debug.Log("loop length: " + loopLength);
        }
        //Check if for loop if statement matches: moving platform going up
        else if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*\d{1,2}\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(player\.([x])\+\+\;)*\s*}"))    //match regex player.y=100;
        {
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
            runClicked = false;
        }
    }

    void movePlayerWithSpeed()
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
        else if (!inputCopy.Contains("player"))
        {
            Debug.Log("variable name does not exist");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable 'player' is missing.";
        }
        else if (!inputCopy.Contains("speed"))
        {
            Debug.Log("The variable 'speed' is missing.");

            //show error/hint box
            errorBox.GetComponent<MeshRenderer>().enabled = true;
            errorTitle.GetComponent<Text>().enabled = true;
            errorTitleUnderline.GetComponent<Text>().enabled = true;
            errorMessage.GetComponent<Text>().enabled = true;
            dismissErrorButton.GetComponent<Button>().enabled = true;
            dissmissErrorButtonText.GetComponent<Text>().enabled = true;

            errorMessage.text = "The variable 'speed' is missing.";
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
        else if ((Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{player\.([x])\+\=[1]\*speed;}")) == false)
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
        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{player\.([x])\+\=[1]\*speed;}"))    //match regex player.y+=100;
        {
            Debug.Log("3rd part");

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);
            movingPlayerRightWithSpeed = true;
            Debug.Log("loop length: " + loopLength);
            correctAnswerTimer = 2f;
            runClicked = false;
        }       
    }

    void reset()
    {
        player.transform.position = new Vector3(-8f, 8f, 0f);
        player.transform.rotation = Quaternion.identity;

        fp1.transform.position = new Vector3(-5.25f, 7f, 0f);
        fp1.transform.rotation = Quaternion.identity;
        Destroy(fp1.GetComponent<Rigidbody>());

        fp2.transform.position = new Vector3(-3.25f, 7f, 0f);
        fp2.transform.rotation = Quaternion.identity;
        Destroy(fp2.GetComponent<Rigidbody>());

        fp3.transform.position = new Vector3(-1.25f, 7f, 0f);
        fp3.transform.rotation = Quaternion.identity;
        Destroy(fp3.GetComponent<Rigidbody>());

        fp4.transform.position = new Vector3(0.75f, 7f, 0f);
        fp4.transform.rotation = Quaternion.identity;
        Destroy(fp4.GetComponent<Rigidbody>());

        //hide error/hint box
        errorBox.GetComponent<MeshRenderer>().enabled = false;
        errorTitle.GetComponent<Text>().enabled = false;
        errorTitleUnderline.GetComponent<Text>().enabled = false;
        errorMessage.GetComponent<Text>().enabled = false;
        dismissErrorButton.GetComponent<Button>().enabled = false;
        dissmissErrorButtonText.GetComponent<Text>().enabled = false;
    }
}
