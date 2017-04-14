using UnityEngine;
using System.Collections;

public class FallingPlatformFour : MonoBehaviour
{
    public GameObject platform;

    private bool fallOne = false;
    private float time = 0.5f;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(name + " collided");
        if (col.gameObject.tag == "fallingPlatformFour")
        {
            platform = col.gameObject;
            Debug.Log("Collided One! :D");
            fallOne = true;
        }
    }

    void Update()
    {
        if (fallOne)
        {
            if (time >= 0)
            {
                //Debug.Log(time);
                time -= Time.deltaTime;
            }
            else
            {
                platform.AddComponent<Rigidbody>();
                time = 0.5f;
                fallOne = false;
            }
        }
    }
}
