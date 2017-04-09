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
    public GameObject platformThree;
    public GameObject player;

    //split the string to check if object name exists
    private string dot = ".";
    private string equals = "=";
    private string semicolon = ";";
    private string coordinate;
    private string[] array;
    

    //levelComplete
    private bool levelCompleted = false;

	// Use this for initialization
	void Start ()
    {
        run.onClick.AddListener(onRunClick);
        input = GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void onRunClick()
    {
        inputCopy = input.text;
        Debug.Log("Run was clicked! :D");
        inputCopy = Regex.Replace(inputCopy, @"\s", string.Empty);  //remove spaces

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
                    levelCompleted = true;                              //everything is correct
                }
                else
                {
                    Debug.Log("The object name does not exist");
                }
            }
            
            //Debug.Log("input " + inputCopy);
            //Debug.Log("hello");
        }
        else if (Regex.IsMatch(inputCopy, @"[\w]+\S\.([x|y])=\d+;"))    //match regex movingPlatform.y=100;
        {
            Debug.Log("You are setting the coordinate instead of increasing/decreasing it");
        }

        if(levelCompleted)
        {
            int coordinatePosition = inputCopy.IndexOf(equals);
            coordinate = inputCopy.Substring(coordinatePosition + 1, inputCopy.Length - 2 - coordinatePosition);

            Debug.Log(coordinate);
            moveObject(Convert.ToInt32(coordinate));

        }
    }

    void moveObject(int coord)
    {

    }
}
