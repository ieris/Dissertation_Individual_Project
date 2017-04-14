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

    //store coordinatees
    private Vector3 playerPos;

    private float timer = 1f;

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
    private bool movingPlayer = false;
    private bool movingPlayerLeft = false;
    private bool movingPlayerRight = false;


    void Start ()
    {
        input = GetComponent<InputField>();
        run.onClick.AddListener(onRunClick);

        //Store original object coordinates
        playerPos = player.transform.position;
    }
	
	void Update ()
    {
        //Move the platform back and forth
        if (!back)
        {
            Debug.Log("right");
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
        if (back)
        {
            Debug.Log("left");
            movingPlatform.transform.position += Vector3.left * 0.75f * Time.deltaTime;

            if (movingPlatform.transform.position.x <= -7.75f)
            {
                back = false;
            }
        }

        //Move the player on the platform back and forth
        if (!playerBack && movingPlayer == false)
        {
            Debug.Log("right");
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
        if (playerBack && movingPlayer == false)
        {
            Debug.Log("left");
            player.transform.position += Vector3.left * 0.75f * Time.deltaTime;

            if (player.transform.position.x <= -7.75f)
            {
                playerBack = false;
            }
        }

        if(movingPlayer)
        {
            Debug.Log("moving");
            //Moving platform position
            if (movingPlatform.transform.position.x >= -1f)
            {
                Debug.Log("platform reached position");
                //Move up until for loop ends
                if (player.transform.position.x < -0.75f + (Convert.ToInt32(loopLength) + 1))
                {
                    player.transform.position += Vector3.right * 5f * Time.deltaTime;
                }
                //When coordinate is met, set it to that coordinate (ensuring it's an int)
                //Debug.Log(player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1));
                if (player.transform.position.x >= playerPos.x + (Convert.ToInt32(loopLength) + 1))
                {
                    //player.transform.position = new Vector3(playerPos.x + (Convert.ToInt32(loopLength) + 1), player.transform.position.y, player.transform.position.z);
                    //Debug.Log(player.transform.position);

                    input.text = "";

                    //Check if the player is in the correct position
                    if (player.transform.position.y >= 4f)
                    {
                        Debug.Log("ddddd Finished! :D");
                        partTwoDone = true;
                        input.text = "";
                    }
                }
            }
        }
    }

    void onRunClick()
    {
        Debug.Log("Button was clicked!");

        if (partOneDone == false)
        {
            movePlayer();
        }
        if (partOneDone)
        {
            movingPlayer = true;
        }
        if (partTwoDone)
        {

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
            if (objectToMove == "player")
            {
                Debug.Log("let's move the player! :D");
                partOneDone = true;
            }
            else
            {
                Debug.Log("cannot move this");
            }
        }
    }
}
