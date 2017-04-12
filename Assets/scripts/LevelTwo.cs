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
    public GameObject platformOne;
    public GameObject platformTwo;
    public GameObject fallingPlatformOne;
    public GameObject fallingPlatformTwo;
    public GameObject fallingPlatformThree;
    public GameObject fallingPlatformFour;
    public GameObject player;

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
    private string coordinate;

    //levelComplete
    private bool partOneDone = false;
    private bool partTwoDone = false;
    private bool levelCompleted = false;
    //private bool movingPlayerLeft = false;
    private bool movingPlayerRight = false;
    private bool movingPlayerLeftPartTwo = false;
    private bool movingPlayerRightPartTwo = false;

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
        /*if (fallingPlatformOne.transform.position.y > 2)
        {
            fallingPlatformOne.transform.position += Vector3.down * 1f * Time.deltaTime;
            fallingPlatformTwo.transform.position += Vector3.down * 0.8f * Time.deltaTime;
            fallingPlatformThree.transform.position += Vector3.down * 0.6f * Time.deltaTime;
            fallingPlatformFour.transform.position += Vector3.down * 0.4f * Time.deltaTime;
        }
        if (fallingPlatformOne.transform.position.y <= 2)
        {
            Destroy(fallingPlatformOne);
        }*/



        //Moving the player left/right: Part Two
        //right
        if (movingPlayerRight)
        {
            //Debug.Log((Convert.ToInt32(loopLength) + 1));
            //Debug.Log(player.transform.position);
            //Move up until for loop ends
            if (player.transform.position.x < playerPos.x + 2f)
            {
                player.transform.position += Vector3.right * 1f * Time.deltaTime;
            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(player.transform.position.x >= playerPos.x + 2f);
            if (player.transform.position.x >= playerPos.x + 2f)
            {
                player.transform.position = new Vector3(playerPos.x + 2f, player.transform.position.y, player.transform.position.z);
                Debug.Log(player.transform.position);
                movingPlayerRight = false;
                playerPos.x = playerPos.x + 2f;
                input.text = "";

                //Check if the player is in the correct position
                if (player.transform.position.x == -4f)
                {
                    partOneDone = true;
                    Debug.Log("Part Two done! :D");
                }
            }
        }

        //Moving the player left/right: Part Two
        //left
        if (movingPlayerLeftPartTwo)
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
                movingPlayerLeftPartTwo = false;
                playerPos.x = playerPos.x - (Convert.ToInt32(loopLength) + 1);
                Debug.Log(player.transform.position);
                loopLength = "0";
                input.text = "";

                //Check if the player is in the correct position
                if (player.transform.position.x == 3f)
                {
                    partTwoDone = true;
                    Debug.Log("Part Two done! :D");
                }
            }
        }

        //right
        if (movingPlayerRightPartTwo)
        {
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
                movingPlayerRightPartTwo = false;
                playerPos.x = playerPos.x + (Convert.ToInt32(loopLength) + 1);
                loopLength = "0";
                input.text = "";

                //Check if the player is in the correct position
                if (player.transform.position.x == 3f)
                {
                    partTwoDone = true;
                    Debug.Log("Part Two done! :D");
                }
            }
        }
    }

    void onRunClick()
    {
        Debug.Log("Button was clicked!");

        if (movingPlayerRight == false && partOneDone == false)
        {
            movePlayer();
        }
        if (partOneDone)
        {
            Debug.Log("part two");
            movePlayerPartTwo();
        }
    }

    void movePlayer()
    {
        inputCopy = input.text;
        Debug.Log("input copy inside player: " + inputCopy);
        Debug.Log("Moving player! :D");
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces
        Debug.Log(objectName);
        if (input == null)
        {
            Debug.Log("Input field is empty");
        }

        //Check if for loop if statement matches: moving player to the right
        if (Regex.IsMatch(inputCopy, @"([a-zA-Z])+([.])+([x])+([+][=]||[=])+([2])+([;])"))    //match regex player.x+=2;
        {
            Debug.Log("moving right");
            //Find the object name in the string
            int objectNamePos = inputCopy.IndexOf("{");
            objectName = inputCopy.Substring(objectNamePos + 1, inputCopy.Length - 7 - objectNamePos);

            Debug.Log("object name: " + objectName);

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

    void movePlayerPartTwo()
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
                movingPlayerLeftPartTwo = true;

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
                movingPlayerRightPartTwo = true;
            }
            else
            {
                Debug.Log("variable name does not exist");
            }
        }
    }
}
