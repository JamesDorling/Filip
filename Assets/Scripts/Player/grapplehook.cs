using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapplehook : MonoBehaviour
{
    private float grabLimit = 30f;
    private float maxDistance = 100f; //Max range of the grapple hook

    private LineRenderer lr; //LineRenderer to draw the rope
    private Vector3 grapplePoint; //Coordinates of the point grappled onto
    public Transform guntip, cam, plyr; //Guntip, camera, player position
    private SpringJoint joint; //Springjoint to be created
    public GameObject attach; //Attached gameobject
    private AudioSource audio;

    public int layer;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        lr = GetComponent<LineRenderer>(); //Get the line renderer
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inGameMenu.GamePaused == false) //If the mouse button is clicked
        {
            lr.enabled = true; //Enable the line renderer
            Grapple(); //Player is grappling, use grapple behaviour
        }
        if (!Input.GetMouseButton(0))
        {
            StopGrapple(); //Stop the grapple
        }
    }
    void FixedUpdate()
    {
        if(!joint)
        {
            layer = 0; //This is a sort of error trapping, if the joint is ever destroyed then stop all grapple behaviour
        }
        if(isGrappling()) //If the player is grappling on something
        {
            //If grappling onto a grapplepoint
            if (getLayer() == 1)
            {
                joint.connectedAnchor = attach.transform.position; //Keep updating the grapple position to follow moving objects
                if(Vector3.Distance(plyr.position, grapplePoint) < joint.maxDistance) //If the distance between the player and the grapplepoint is less than the maximum allowed
                    joint.maxDistance = Vector3.Distance(plyr.position, grapplePoint); //Update the max distance to the new distance
            }
            else if (getLayer() == 2) //If grappling onto an interactable
            {
                joint.connectedAnchor = plyr.position; //Keep updating the grapple position to follow the player
                //Debug.Log(Vector3.Distance(plyr.position, grapplePoint));
            }
        }
    }

    void LateUpdate()
    {
        DrawRope(); //Draw the rope
    }

    void Grapple()
    {
        RaycastHit hit; //Raycast to check for a grappleable wall
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxDistance))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Grappleable")) //If the first hit of the raycast has the layer "Grappleable"
            {
                GrappleableBehaviour(hit);
                //If attached to a cannonball
                if (hit.collider.gameObject.tag == "Cannonball")
                {
                    //Disable collisions with the player and the cannonball, as it can cause really annoying interactions if the player hits the ball in the air.
                    joint.enableCollision = false;
                }
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Pullable") && Vector3.Distance(hit.collider.gameObject.transform.position, plyr.position) < grabLimit) //If the first hit of the raycast has the layer "Grappleable"
            {
                GrabbableBehaviour(hit);
            }
            else
            {
                layer = 0;
                return; //If the raycast hits anything but grappleable first, then it stops
            }
        }
    }

    void GrappleableBehaviour(RaycastHit hit)
    {
        layer = 1; //Set the "layer" variable to say its grappling on an grapplepoint
        grapplePoint = hit.collider.transform.position;
        joint = plyr.gameObject.AddComponent<SpringJoint>(); //Use a spring joint here because it creates the most smooth experience. Other joints are either much more restrictive or not correct for the task.

        SetupGrappleUniversalValues(hit);

        joint.connectedAnchor = grapplePoint; //set the position of the joint

        float dist = Vector3.Distance(plyr.position, grapplePoint);
        joint.maxDistance = dist;
        
        joint.spring = 6f; //Set the springiness of the joint
        joint.damper = 7f; //Set the damper of the joint
    }

    void GrabbableBehaviour(RaycastHit hit)
    {
        layer = 2;//Set the "layer" variable to say its grappling on an interactable
        grapplePoint = hit.collider.transform.position;
        joint = hit.collider.gameObject.AddComponent<SpringJoint>();

        SetupGrappleUniversalValues(hit);

        joint.connectedAnchor = plyr.position;

        joint.maxDistance = 5f;

        joint.spring = 8f; //Set the springiness of the joint
        joint.damper = 8f; //Set the damper of the joint
        
    }

    void SetupGrappleUniversalValues(RaycastHit hit)
    {
        joint.autoConfigureConnectedAnchor = false; //Set the anchor configuration to be manual
        joint.massScale = 4.5f; //Set the massScale of the joint

        joint.minDistance = 0f; //Set the minimum distance to 0

        lr.positionCount = 2; //Set the line renderer's position count (So it can draw a line between them)
        attach = hit.collider.gameObject; //Set attach to the interactable

        audio.Play(); //Play the grapple audio
    }

    void DrawRope()
    {
        if (!joint) return;

        lr.SetPosition(0, guntip.position); //Set the first linerenderer position (Start) to the guntip
        lr.SetPosition(1, attach.transform.position); //Set the second linerenderer position (End) to the grapple point
    }

    public void StopGrapple()
    {
        lr.positionCount = 0; //Delete the positions
        Destroy(joint); //Destroy the spring joint
        layer = 0; //Setting the layer to 0 will stop all grapple behaviour
    }

    public bool isGrappling() //Is the player using a grapple hook? Used in rotateGun.cs
    {
        return joint != null; //If a joint exists then return true
    }

    public int getLayer() //Is the player using a grapple hook? Used in rotateGun.cs
    {
        return layer; //If a joint exists then return true
    }

    public Vector3 GetGrapplePoint() //Location grappled to. Used in rotateGun.cs
    {
        return attach.transform.position; //Return the grapplepoint vector
    }
}
