using UnityEngine;
using System.Collections;

public class movingPlatformTwo : MonoBehaviour
{
    FinalLevel fl;
    public GameObject player;
    public GameObject platformTwo;
    public static bool colliding = false;

    void Start()
    {
        /*fl = GetComponent<FinalLevel>();
        fl = new FinalLevel();*/
    }

    void Update()
    {
        if (colliding && player.transform.position.x >= -5.75f && player.transform.position.x < -4.75f)
        {
            platformTwo.transform.position += Vector3.down * 0.2f * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(name + " collided");
        if (col.gameObject.tag == "movingPlatformTwo")
        {
            //platform = col.gameObject;
            //platform.AddComponent<Rigidbody>();
            colliding = true;
            Debug.Log(platformTwo.transform.position);
            Debug.Log("Collided Two! :D");
        }
    }

    void OnCollisionExit(Collision col)
    {
        //if (col.gameObject.tag == "movingPlatformTwo")
        //{
            //platform = col.gameObject;
            colliding = false;
        //}
    }
}
