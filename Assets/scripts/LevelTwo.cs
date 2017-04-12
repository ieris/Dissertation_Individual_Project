using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class LevelTwo : MonoBehaviour
{
    //Regular expressions used to restrict user input and check syntax

    private Regex noSpaces = new Regex(@"/[\s\r\n]+/gim");
    private Regex regexLevelOne = new Regex(@"/([a-zA-Z])+([.])+([x, y])+([+][=]||[=])+([0-9\d])+([;])/g");
    private Regex regexLevelTwo = new Regex(@"/(\bfor\b)+\((\bvar\b)+( [a-zA-Z])+([:])+(\bint\b)+([=])+([0-9])+([;])+([a-zA-Z])+([<>=])+([0-9]\d)+([;])+([a-zA-Z])+([+][+])+([)])+([{])+([}])/g");

    //user input
    private InputField input;
    private string inputCopy;

    //objects in the scene
    private string[] objects = new string[] { "player" };
    public Button run;
    public GameObject player;
    public GameObject fp1;
    public GameObject fp2;
    public GameObject fp3;
    public GameObject fp4;

    //store coordinatees
    private Vector3 movingPlatformPos;
    private Vector3 playerPos;

    //split the string to check if object name exists
    private string dot = ".";
    private string equals = "=";
    private string semicolon = ";";
    private string enteredCoordinate;
    private float coordinateFloat;
    private float finalCoordinate;
    private string[] array;

    //seperating the code into variables
    private string objectName;
    private string loopLength;
    private string speedVarLength;
    private string coordinate;

    //levelComplete
    private bool partOneDone = false;
    private bool partTwoDone = false;
    private bool levelCompleted = false;
    private bool createSpeedVar = false;
    private bool movingPlayerLeft = false;
    private bool movingPlayerRight = false;
    private bool movingPlayerLeftWithSpeed = false;
    private bool movingPlayerRightWithSpeed = false;

    // Use this for initialization
    void Start()
    {
        input = GetComponent<InputField>();
        run.onClick.AddListener(onRunClick);

        //Store original object coordinates
        playerPos = player.transform.position;
    }

    void Update()
    {
        //Moving the player left/right: Part Two
        //left
        if (movingPlayerLeft)
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

                //Check if the player is in the correct position
                if (player.transform.position.y <= 2f)
                {
                    partOneDone = true;
                    reset();
                    input.text = "";
                    movingPlayerLeft = false;
                    Debug.Log("Part one done! :D");
                }
            }
        }

        //right
        if (movingPlayerRight)
        {
            Debug.Log("moving player to the right");
            //Debug.Log((Convert.ToInt32(loopLength) + 1));
            //Debug.Log(player.transform.position);
            //Move up until for loop ends
            if (player.transform.position.x < playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.right * 1f * Time.deltaTime;
            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
            if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, player.transform.position.z);
                Debug.Log(player.transform.position);
                
                playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                loopLength = "0";
                input.text = "";

                //Check if the player is in the correct position
                if (player.transform.position.y <= 2f)
                {
                    Debug.Log("ddddd Part one done! :D");
                    partOneDone = true;
                    reset();
                    input.text = "";
                    movingPlayerRight = false;
                    Debug.Log("part one done is: " + partOneDone);
                }
            }
        }

        //right
        if (movingPlayerRightWithSpeed)
        {
            Debug.Log("moving player to the right");
            //Debug.Log((Convert.ToInt32(loopLength) + 1));
            //Debug.Log(player.transform.position);
            //Move up until for loop ends
            if (player.transform.position.x < playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.right * Convert.ToInt32(speedVarLength) * Time.deltaTime;
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

                //Check if the player is in the correct position
                if (player.transform.position.x == 3f)
                {
                    partTwoDone = true;
                    Debug.Log("Part Two done! :D");
                }
                //Check if the player is in the correct position
                if (player.transform.position.y <= 2f)
                {
                    Debug.Log("ddddd Part one done! :D");
                    partOneDone = true;
                    reset();
                    input.text = "";
                    movingPlayerRight = false;
                    Debug.Log("part one done is: " + partOneDone);
                }

            }
        }
    }

    void onRunClick()
    {
        Debug.Log("Button was clicked!");

        if (movingPlayerRight == false && movingPlayerLeft == false)
        {
            movePlayer();
        }
        if(partOneDone)
        {
            Debug.Log("yes");
            creatingSpeedVar();
            //movePlayerWithSpeed();
        }
        if(partTwoDone)
        {
            movePlayerWithSpeed();
        }
    }

    void creatingSpeedVar()
    {
        inputCopy = input.text;
        Debug.Log("Part Two! :D");
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        if (input == null)
        {
            Debug.Log("Input field is empty");
        }
        /*if (inputCopy.EndsWith(semicolon))                          //check for semicolon
        {
            Debug.Log("Semicolon is here! :D");
        }
        else
        {
            Debug.Log("Are you missing a semicolon ;");
        }*/
        Debug.Log(inputCopy);

        //Check if for loop if statement matches: moving platform going down
        if (Regex.IsMatch(inputCopy, @"int[speed]*=\d+;"))    //match regex int speed = 3;
        {
            //Find the object name in the string
            int objectNamePos = 2;
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 4 - objectNamePos);
            Debug.Log("object name: " + objectName);

            //Find how long the loop will run for in the string
            int speedVarPosition = inputCopy.IndexOf(equals);
            speedVarLength = inputCopy.Substring(speedVarPosition + 1, 1);

            Debug.Log("loop length: " + speedVarLength);

            partTwoDone = true;
        }
    }

    void movePlayer()
    {
        inputCopy = input.text;
        Debug.Log("Part Two! :D");
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        if (input == null)
        {
            Debug.Log("Input field is empty");
        }
        /*if (inputCopy.EndsWith(semicolon))                          //check for semicolon
        {
            Debug.Log("Semicolon is here! :D");
        }
        else
        {
            Debug.Log("Are you missing a semicolon ;");
        }*/
        Debug.Log(inputCopy);

        //Check if for loop if statement matches: moving platform going down
        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(\s*[\w]+\S\.([x])\-\-\;)*\s*}"))    //match regex player.y+=100;
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
        }
        //Check if for loop if statement matches: moving platform going up
        else if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(\s*[\w]+\S\.([x])\+\+\;)*\s*}"))    //match regex player.y=100;
        {
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
        }
    }

    void movePlayerWithSpeed()
    {
        inputCopy = input.text;
        Debug.Log("Part Two! :D");
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        if (input == null)
        {
            Debug.Log("Input field is empty");
        }
        /*if (inputCopy.EndsWith(semicolon))                          //check for semicolon
        {
            Debug.Log("Semicolon is here! :D");
        }
        else
        {
            Debug.Log("Are you missing a semicolon ;");
        }*/
        Debug.Log(inputCopy);

        //Check if for loop if statement matches: moving platform going down
        if (Regex.IsMatch(inputCopy, @"int[speed]*=\d+;for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{[\w]+\S\.([x])\+\=[1]\*speed;}"))    //match regex player.y+=100;
        {
            //Find the object name in the string
            //Find how long the loop will run for in the string
            int speedVarPosition = 9;
            speedVarLength = inputCopy.Substring(speedVarPosition, 1);
            Debug.Log("speed: " + speedVarLength);

            //Find how long the loop will run for in the string
            int loopLengthPos = inputCopy.IndexOf("<");
            loopLength = inputCopy.Substring(loopLengthPos + 1, 1);

            Debug.Log("loop length: " + loopLength);

            //Check if correct variable name is used
            if (inputCopy.Contains("player"))
            {
                Debug.Log("variable name exists! :D");
                movingPlayerRightWithSpeed = true;
            }
            else
            {
                Debug.Log("variable name does not exist");
            }
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
    }
}
