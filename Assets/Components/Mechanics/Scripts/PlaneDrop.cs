using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDrop : MonoBehaviour
{

    public bool inPlane;
    public Camera PlaneCam;
    public Rigidbody PlayerRig;
    public GameObject Player1;
    public bool playerInJumpZone;

    public GameObject PlayerCanvas;
    public GameObject PlaneCanvas;

    void Start()
    {
        inPlane = true;                                                  //Says that the player is in the plane 
    }

    void OnTriggerStay(Collider other)
    {                                                                   //Checks if the plane goes into the Jumpzone
        if (other.gameObject.tag == "JumpZone")
        {
            playerInJumpZone = true;
            //Debug.Log ("In zone"); Optional
        }
    }

    void OnTriggerExit(Collider Other)
    {                                                                    //Checks if the plane goes out of the Jumpzone
        if (Other.gameObject.tag == "JumpZone")
        {
            playerInJumpZone = false;
            //Debug.Log("Not in zone"); Optional
        }
    }

    void Update()
    {

        if (playerInJumpZone == true)
        {
            if (Input.GetKey(KeyCode.F) && inPlane == true)
            {                                                             //Does the magic of making the player jump out of the plane
                inPlane = false;
                PlaneCam.enabled = false;
                EnablePlayerUI();
                Player1.SetActive(true);
                PlayerRig.velocity = Vector3.zero;
                PlayerRig.angularVelocity = Vector3.zero;
               
            }
        }

        if (inPlane)
        {
            Player1.transform.position = transform.position;               //Makes the player follow the plane
        }
    }

    void EnablePlayerUI ()
    {
        PlayerCanvas.SetActive(true);                                     //Enables the player UI and disables the plane UI 
        PlaneCanvas.SetActive(false);
    }
}
