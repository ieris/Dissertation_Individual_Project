using UnityEngine;
using System.Collections;

public class movingPlatformOne : MonoBehaviour
{
    FinalLevel fl;    
    public GameObject player;
    public GameObject platformOne;
    public bool colliding = false;

    public void Start ()
    {
        //fl = GetComponent<FinalLevel>();
        //fl = new FinalLevel();
    }
	
	public void Update ()
    {
	    if(colliding && player.transform.position.x == -7.75f)
        {
            Debug.Log("is colliding? : " + colliding);
            platformOne.transform.position += Vector3.down * 0.05f * Time.deltaTime;
        }
	}

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log(name + " collided");
        if (col.gameObject.tag == "movingPlatformOne")
        {
            //platform = col.gameObject;
            //platform.AddComponent<Rigidbody>();
            colliding = true;
            //Debug.Log(platformOne.transform.position);
            //Debug.Log("Collided One! :D");
        }
    }

    public void OnCollisionExit(Collision col)
    {
        //if (col.gameObject.tag == "movingPlatformOne")
        //{
            //platform = col.gameObject;
            colliding = false;
        //}
    }
}
