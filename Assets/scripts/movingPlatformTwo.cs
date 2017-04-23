using UnityEngine;
using System.Collections;

public class movingPlatformTwo : MonoBehaviour
{
    public GameObject player;
    public GameObject platformTwo;
    public static bool colliding = false;
    public bool playerGoUp = false;

    void Update()
    {
        //Debug.Log(colliding);
        if (colliding && player.transform.position.x == -4.75f)
        {
            if (!playerGoUp)
            {
                platformTwo.transform.position += Vector3.down * 0.75f * Time.deltaTime;
                player.transform.position += Vector3.down * 0.75f * Time.deltaTime;

                if (player.transform.position.y <= 6.75f)
                {
                    Debug.Log("go up now");
                    playerGoUp = true;
                }
            }

            //Move the player on the platform back and forth
            if (playerGoUp)
            {
                //Debug.Log("right");
                platformTwo.transform.position += Vector3.up * 0.75f * Time.deltaTime;
                player.transform.position += Vector3.up * 0.75f * Time.deltaTime;

                if (player.transform.position.y >= 11f)
                {
                    Debug.Log("go down now");
                    playerGoUp = false;
                }
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(name + " collided");
        if (col.gameObject.tag == "movingPlatformTwo")
        {
            colliding = true;
            Debug.Log(platformTwo.transform.position);
            Debug.Log("Collided Two! :D");
        }
    }

    void OnCollisionExit(Collision col)
    {
        colliding = false;
    }
}
