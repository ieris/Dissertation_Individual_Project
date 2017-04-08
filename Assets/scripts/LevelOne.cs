using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class LevelOne : MonoBehaviour
{
    //Regular expressions used to restrict user input and check syntax

    private string noSpaces = @"/[\s\r\n]+/gim";
	private string regexLevelOne = @"/([a-zA-Z])+([.])+([x, y])+([+][=]||[=]||[-][=])+([0-9\d])+([;])/g";
	private string regexLevelTwo = @"/(\bfor\b)+\((\bvar\b)+( [a-zA-Z])+([:])+(\bint\b)+([=])+([0-9])+([;])+([a-zA-Z])+([<>=])+([0-9]\d)+([;])+([a-zA-Z])+([+][+])+([)])+([{])+([}])/g";

    private string userInput = "";

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
