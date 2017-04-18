using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class LevelThree : MonoBehaviour
{
    //user input
    private InputField input;
    private string inputCopy;

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

    //seperating the code into variables
    private string objectName;
    private string loopLength;

    //levelComplete
    private bool partOneDone = false;
    private bool partTwoDone = false;
    private bool movingPlatformLower = false;
    private bool movingPlatformHigher = false;
    private bool movingPlayerLeft = false;
    private bool movingPlayerRight = false;

    // Use this for initialization
    void Start ()
    {
        input = GetComponent<InputField>();
        run.onClick.AddListener(onRunClick);
        resetButton.onClick.AddListener(onResetClick);

        //Store original object coordinates
        movingPlatformPos = movingPlatform.transform.position;
        playerPos = player.transform.position;
    }

    void Update ()
    {   
        //Moving the platform up/down: Part One
        //going down
        if (movingPlatformLower)
        {
            //Move down until for loop ends
            if (movingPlatform.transform.position.y >  movingPlatformPos.y - (Convert.ToInt32(loopLength) + 1))
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
                input.text = "";

                //Check if the movingPlatform is in the correct position
                if (movingPlatform.transform.position.y == 7f)
                {
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
                input.text = "";                
            }
        }

        //right
        if (movingPlayerRight)
        {
            //Move up until for loop ends
            if (player.transform.position.x < playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.right * 1f * Time.deltaTime;

                //Check if the movingPlatform is in the correct position
                if (player.transform.position.x >= 3f)
                {
                    partTwoDone = true;
                    Application.LoadLevel("LevelFour");
                    Debug.Log("Part Two done! :D");
                }

            }
            //When coordinate is met, set it to that coordinate (ensuring it's an int)
            Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
            if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, movingPlatform.transform.position.z);
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
        Debug.Log("Button was clicked!");        

        if(movingPlatformHigher == false && movingPlatformLower == false)
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

    void moveMovingPlatform()
    {
        inputCopy = input.text;
        Debug.Log("Moving platform! :D");
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        if (input == null)
        {
            Debug.Log("Input field is empty");
        }

        //Check if for loop if statement matches: moving platform going down
        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(\s*[\w]+\S\.([y])\-\-\;)*\s*}"))    //match regex movingPlatform.y+=100;
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
            if (inputCopy.Contains("movingPlatform"))
            {
                Debug.Log("variable name exists! :D");
                movingPlatformLower = true;
            }
            else
            {
                Debug.Log("variable name does not exist");
            }
        }
        //Check if for loop if statement matches: moving platform going up
        else if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(\s*[\w]+\S\.([y])\+\+\;)*\s*}"))    //match regex movingPlatform.y=100;
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
            if (inputCopy.Contains("movingPlatform"))
            {
                Debug.Log("variable name exists! :D");
                movingPlatformHigher = true;
            }
            else
            {
                Debug.Log("variable name does not exist");
            }
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

        //Check if for loop if statement matches: moving platform going down
        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(\s*[\w]+\S\.([x])\-\-\;)*\s*}"))    //match regex player.x--;
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
        //Check if for loop if statement matches: moving platform going down
        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{(\s*[\w]+\S\.([x])\+\+\;)*\s*}"))    //match regex player.x++;
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
                movingPlayerRight = true;

            }
            else
            {
                Debug.Log("variable name does not exist");
            }
        }
    }
}
