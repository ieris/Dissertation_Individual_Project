using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class LevelOne : MonoBehaviour
{
    //Regular expressions used to restrict user input and check syntax

    private Regex noSpaces = new Regex (@"/[\s\r\n]+/gim");
	private Regex regexLevelOne = new Regex(@"/([a-zA-Z])+([.])+([x, y])+([+][=]||[=])+([0-9\d])+([;])/g");
	private Regex regexLevelTwo = new Regex (@"/(\bfor\b)+\((\bvar\b)+( [a-zA-Z])+([:])+(\bint\b)+([=])+([0-9])+([;])+([a-zA-Z])+([<>=])+([0-9]\d)+([;])+([a-zA-Z])+([+][+])+([)])+([{])+([}])/g");

    //user input
    private InputField input;
    private string inputCopy;

    //objects in the scene
    private string [] objects = new string[] { "platformOne", "platformTwo", "movingPlatform" };
    public Button run;
    public GameObject platformOne;
    public GameObject platformTwo;
    public GameObject movingPlatform;
    public GameObject player;

    //store coordinatees
    private Vector3 movingPlatformPos;

    //split the string to check if object name exists
    private string dot = ".";
    private string equals = "=";
    private string semicolon = ";";
    private string enteredCoordinate;
    private float coordinateFloat;
    private float finalCoordinate;
    private string[] array;
    

    //levelComplete
    private bool levelCompleted = false;
    private bool movingPlatformLower = false;
    private bool movingPlatformHigher = false;

    // Use this for initialization
    void Start ()
    {
        run.onClick.AddListener(onRunClick);
        input = GetComponent<InputField>();

        //Store object coordinates
        movingPlatformPos = movingPlatform.transform.position;
    }

    void Update ()
    {
        //going down
        Debug.Log("coordinate " + coordinateFloat);
        if (movingPlatformLower)
        {
            //Move down until it reaches the final coordinate
            if (movingPlatform.transform.position.y > finalCoordinate)
            {
                movingPlatform.transform.position += Vector3.down * coordinateFloat * Time.deltaTime;
            }
            else if (movingPlatform.transform.position.y <= finalCoordinate)
            {
                movingPlatform.transform.position = new Vector3(movingPlatform.transform.position.x, finalCoordinate, movingPlatform.transform.position.z);
                levelCompleted = true;
            }
        }

        //going up
        else if(movingPlatformHigher)
        {
            //Move up until it reaches the final coordinate
            if (movingPlatform.transform.position.y < finalCoordinate)
            {
                Debug.Log("going up");
                movingPlatform.transform.position += Vector3.up * coordinateFloat * Time.deltaTime;
            }
            else if (movingPlatform.transform.position.y >= finalCoordinate)
            {
                movingPlatform.transform.position = new Vector3(movingPlatform.transform.position.x , finalCoordinate, movingPlatform.transform.position.z);
                levelCompleted = true;
            }
        }
    }

    void onRunClick()
    {
        Debug.Log("y" + movingPlatform.transform.position.y);
        inputCopy = input.text;
        Debug.Log("Run was clicked! :D");
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

        if(input == null)
        {
            Debug.Log("Input field is empty");
        }
        if (inputCopy.EndsWith(semicolon))                          //check for semicolon
        {
            Debug.Log("Semicolon is here! :D");
        }
        else
        {
            Debug.Log("Are you missing a semicolon ;");
        }

        if (Regex.IsMatch(inputCopy, @"[\w]+\S\.([x|y])(-|\+)=\d+;"))    //match regex movingPlatform.y+=100;
        {
            //split the object name from the input
            array = inputCopy.Split(new string[] { dot }, StringSplitOptions.None);
            //Debug.Log("object name " + array[0]);

            //check if variable name exists
            foreach(string str in objects)
            { 
                if (str.Contains(array[0]))
                {
                    Debug.Log(array[0] + " Object exists! :D");                    

                    int coordinatePosition = inputCopy.IndexOf(equals);
                    enteredCoordinate = inputCopy.Substring(coordinatePosition + 1, inputCopy.Length - 2 - coordinatePosition);

                    //store coordinate value
                    coordinateFloat = float.Parse(enteredCoordinate);

                    if (Regex.IsMatch(inputCopy, @"[\w]+\S\.([x|y])(\+)=\d+;"))      //match regex movingPlatform.y+=100;
                    {
                        Debug.Log("Going up");
                        finalCoordinate = movingPlatformPos.y + coordinateFloat;
                        movingPlatformHigher = true;
                    }
                    else if (Regex.IsMatch(inputCopy, @"[\w]+\S\.([x|y])(-)=\d+;")) //match regex movingPlatform.y-=100;
                    {
                        Debug.Log("Going down");
                        finalCoordinate = movingPlatformPos.y - coordinateFloat;
                        movingPlatformLower = true;
                    }
                }
                else
                {
                    Debug.Log("The object name does not exist");
                }
            }
        }
        else if (Regex.IsMatch(inputCopy, @"[\w]+\S\.([x|y])=\d+;"))    //match regex movingPlatform.y=100;
        {
            Debug.Log("You are setting the coordinate instead of increasing/decreasing it");
        }
    }

    void moveObject(float coord)
    {
        movingPlatform.transform.Translate(0,coord * Time.deltaTime, 0);
    }
}
