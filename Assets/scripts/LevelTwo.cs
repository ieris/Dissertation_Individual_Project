using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class LevelTwo : MonoBehaviour
{
    //user input
    private InputField input;
    private string inputCopy;

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

    // Use this for initialization
    void Start()
    {
        input = GetComponent<InputField>();
        run.onClick.AddListener(onRunClick);
        resetButton.onClick.AddListener(onResetClick);

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

            //Move up until for loop ends
            if (player.transform.position.x < playerPos.x + (Convert.ToInt32(loopLength) + 1))
            {
                player.transform.position += Vector3.right * Convert.ToInt32(speedVarLength) * Time.deltaTime;

                //Check if the player is in the correct position
                if (player.transform.position.x >= 3f)
                {
                    partTwoDone = true;
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

    void onResetClick()
    {
        Application.LoadLevel("LevelTwo");
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

        //Check if for loop if statement matches: moving platform going down
        if (Regex.IsMatch(inputCopy, @"for\(int(\w*)\s?=\s?[0]\s?\;\s*\1\s*[<]?=?\s*[1-9]\s*\;((\s*\1([++])\4)|(\s*\1\s*=\s*\1\s*[+/*-]\s*\d{1,15}))\s*\)\s*{[\w]+\S\.([x])\+\=[1]\*speed;}"))    //match regex player.y+=100;
        {
            Debug.Log("3rd part");
            //Find the object name in the string
            //Find how long the loop will run for in the string
            /*int speedVarPosition = 9;
            speedVarLength = inputCopy.Substring(speedVarPosition, 1);
            Debug.Log("speed: " + speedVarLength);*/

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
        else
        {
            Debug.Log("part 3 is not a match");

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
