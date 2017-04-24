using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onObjectClicked : MonoBehaviour
{
    public Texture objectTexture;
    public Texture originalObjectTexture;
    private bool clicked = false;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !clicked)
        {
            //Debug.Log("Name: " + gameObject.name);
            clicked = true;
            GetComponent<MeshRenderer>().material.mainTexture = objectTexture;

            Debug.Log("click");
        }
        else if (Input.GetMouseButtonDown(0) && clicked)
        {
            //Debug.Log("Name: " + gameObject.name);
            clicked = false;
            GetComponent<MeshRenderer>().material.mainTexture = originalObjectTexture;
            Debug.Log("unclick");
        }
    }
}
