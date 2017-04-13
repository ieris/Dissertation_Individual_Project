using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class LevelOne : MonoBehaviour
{
    //user input
    private InputField input;
    private string inputCopy;

    //objects in the scene
    public Button run;
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
        //Moving the player left/right: Part Two
        //right
        if (movingPlayerRight)
        {
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
        if(partOneDone)
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
