using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float m_speed = 0.5f; //acceleration speed
    private float m_maxSpeed = 15f; //Max speed for velocity
    private float maxBoostSpeed = 40f;

    public float gravInt = 10; //Gravity intensity
    public float gravDir = 0; //Gravity direction

    private float xVel; //X velocity (to set the velocity to)
    private float zVel; //Z velocity (to set the velocity to

    public bool cooldown = false; //Boost cooldown

    public PlayerBehaviour pb; //Player's playerbehaviour script
    public Transform dir, orientation; //Player direction, camera orientation
    public grapplehook grapple;

    public Camera cam; //Camera
    private float zoomFOV = 20f; //fov when zooming
    private float normFOV = 90f; //fov when not zooming

    //boolean of if the player has grappled while in the air
    private bool grappled = false;

    //Particle system (For jumping)
    public ParticleSystem parSys;

    //Boost cooldown script
    public boostCooldown booster;

    //Audio source for jumping
    private AudioSource jumpAudio;
    //audio source for boosting
    private AudioSource boostAudio;

    //public PhysicMaterial phys; //Physic material
    //Player's rigidbody
    private Rigidbody m_rb;
    void Awake()
    {
        //Get the player's rigidbody
        m_rb = GetComponent<Rigidbody>();
        //Get the jump audiosource
        jumpAudio = GetComponent<AudioSource>();
        //Get the boost audiosource
        boostAudio = dir.GetChild(2).GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Lock the cursor to the middle of the screen
        Cursor.visible = false; //Make the cursor invisible
        //m_rb.velocity = new Vector3( 0.0f, 0.0f, 0.0f ); //Set velocity to 0 (Just in case)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(gravDir) //Switch for gravity direction, as gravity is all artificial (NOT USED FOR ANYTHING OTHER THAN DOWN, Applies it relative to the player's look direction so doesnt work anyway)
        {
            case 0:
                m_rb.AddForce(-transform.up * gravInt);
                break;
            case 1:
                m_rb.AddForce(transform.up * gravInt);
                break;
            case 2:
                m_rb.AddForce(-transform.right * gravInt);
                break;
            case 3:
                m_rb.AddForce(transform.right * gravInt);
                break;

        }

        if (Input.GetKey(KeyCode.Space) && pb.grounded > 0)
        {
            m_rb.velocity += transform.up * 12.0f; //On space pressed, set the velocity to jump
            pb.grounded -= 1; //Remove one from grounded (Will not error as will set it back to 0 if it goes too low, this is for error trapping)
            //m_rb.AddForce(transform.up * 400f);
            parSys.Play(); //Play the particle system
            // parSys.emission.enabled = true;
            jumpAudio.Play(); //Play the jump audio

        }

        if(m_rb.velocity.y < 0)
        {
            m_rb.velocity = new Vector3(m_rb.velocity.x, Mathf.Lerp(m_rb.velocity.y, -20, 0.025f), m_rb.velocity.z); //Little bit of extra gravity, makes jumping feel a bit less floaty and more realistic.
        }

#if UNITY_EDITOR
        if(Input.GetMouseButton(2)) //Input to set the zoom
        {
            cam.fieldOfView = zoomFOV; //zoom
        }
        else
        {
            cam.fieldOfView = normFOV; //unzoom
        }
#endif


        //Debug.Log("Key pressed");

        //Make the player not be able to increase zVel or xVel over the max speed. Also maybe cap the player's velocity.

        //Vector3 relZVel = VelRelToCam(true);
        //Debug.Log(relZVel);
        //Vector3 relXVel = VelRelToCam(false);
        //Debug.Log(relXVel);

        if (Input.GetKey(KeyCode.W) && pb.grounded > 0 && zVel <= m_maxSpeed)
        { //Spent the longest time with this not working, just to find out the player was encountering friction on the gun he was holding.
            if (zVel < -2f) //Limit zvel if goiong in the other direction
            {
                zVel = -2f;
                //zVel = Mathf.Clamp(zVel, -1f, 0);
                //Debug.Log("Forward slowdown");
            }
            zVel += m_speed; //Add to zvel
        }

        if (Input.GetKey(KeyCode.A) && pb.grounded > 0 && xVel >= -m_maxSpeed)
        {
            if(xVel > 2f) //Limit xvel if goiong in the other direction
            {
                xVel = 2f;
                //xVel = Mathf.Clamp(zVel, 0, 1f);
            }
            xVel -= m_speed; //add to xvel
        }

        if (Input.GetKey(KeyCode.S) && pb.grounded > 0 && zVel >= -m_maxSpeed)
        {
            if (zVel > 2f) //Limit zvel if goiong in the other direction
            {
                zVel = 2f;
                //zVel = Mathf.Clamp(zVel, 0, 1f);
               // Debug.Log("Backward slowdown");
            }
            zVel -= m_speed; //Add to zvel
        }

        if (Input.GetKey(KeyCode.D) && pb.grounded > 0 && xVel <= m_maxSpeed)
        {
            if (xVel < -2f) //Limit xvel if goiong in the other direction
            {
                xVel = -2f;
                //xVel = Mathf.Clamp(zVel, -1f, 0);
            }
            xVel += m_speed; //add to xvel
        }

        if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && pb.grounded > 0)
        { 
            zVel = Mathf.Lerp(zVel, 0, 0.25f); //Lerp zvel down if w and s not pressed
            //m_rb.velocity = new Vector3(m_rb.velocity.x * dir.right.x, m_rb.velocity.y, m_rb.velocity.z * dir.right.z);
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && pb.grounded > 0)
        {
            xVel = Mathf.Lerp(xVel, 0, 0.25f); //Lerp xvel if a and d not pressed
            //m_rb.velocity = new Vector3(m_rb.velocity.x * dir.forward.x, m_rb.velocity.y, m_rb.velocity.z * dir.forward.z);
        }

        if (pb.grounded > 0)
        {
          m_rb.velocity = new Vector3((dir.forward.x * zVel) + (dir.right.x * xVel), m_rb.velocity.y, (dir.forward.z * zVel) + (dir.right.z * xVel)); //Used to be "Move()"
        }
        
        //Debug.Log(new Vector3((dir.forward.x * zVel) + (dir.right.x * xVel), m_rb.velocity.y, (dir.forward.z * zVel) + (dir.right.z * xVel)));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            StartCoroutine(BoostCooldown()); //Boost coroutine starts upon shift pressed
            //Debug.Log("Boost");
        }

        //Debug.Log(new Vector2(zVel, xVel));
    }

    void Update()
    {
        if(zVel > m_maxSpeed && pb.grounded > 0) //If the player is grounded and above the max speed
        {
            zVel = Mathf.Lerp(zVel, m_maxSpeed, 0.02f); //Lessen the speed via a lerp to the max speed
        }

        if (zVel < -m_maxSpeed && pb.grounded > 0) //If the player is grounded and above the max speed
        {
            zVel = Mathf.Lerp(zVel, -m_maxSpeed, 0.02f); //Lessen the speed via a lerp to the max speed
        }

        if(grapple.isGrappling() && pb.grounded == 0)
        {
            grappled = true; //Set grappled to true so that when landing velocity is not kept
        }

        if(grappled == true && pb.grounded > 0) //If the player has grappled and landed afterwards, cut of velocity
        { //This is because without it velocity will be saved afterwards and therefore potentially mean the player will run off the edge. Also, if I just reset xVel and zVel whenever airborn / airborn and grappling, boosting in the air becomes practically worthless.
            //xVel = 0;
            //zVel = 0;
            xVel = xVel / 3;
            zVel = zVel / 3;
            grappled = false;
        }
    }


    IEnumerator BoostCooldown()
    {
        if (cooldown != true) //If not on cooldown
        {
            booster.boost();
            Boost(); //Boost the player
            boostAudio.Play();
            cooldown = true; //Set to be on cooldown
            yield return new WaitForSeconds(3); //Wait for cooldown duration
            cooldown = false; //End the cooldown
        }
    }

    void Boost()
    {
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)) //If W and shift are pressed (Or no keys), boost forward
        {
            if (zVel < -2f) //Limit xvel if goiong in the other direction
            {
                zVel = 0f;
                //xVel = Mathf.Clamp(zVel, -1f, 0);
            }
            zVel += 20f;
        }
        if (Input.GetKey(KeyCode.A)) //If A and shift are pressed, boost left
        {
            if (xVel > 2f) //Limit xvel if goiong in the other direction
            {
                xVel = 0f;
                //xVel = Mathf.Clamp(zVel, -1f, 0);
            }
            xVel -= 20f;
        }
        if (Input.GetKey(KeyCode.S)) //If S and shift are pressed, boost backwards
        {
            if (zVel > 2f) //Limit xvel if goiong in the other direction
            {
                zVel = 0f;
                //xVel = Mathf.Clamp(zVel, -1f, 0);
            }
            zVel -= 20f;
        }
        if (Input.GetKey(KeyCode.D)) //If w and shift are pressed, boost right
        {
            if (xVel < -2f) //Limit xvel if goiong in the other direction
            {
                xVel = 0f;
                //xVel = Mathf.Clamp(zVel, -1f, 0);
            }
            xVel += 20f;
        }
        //Limit the player's speed with maxBoostSpeed being an overall maximum speed, and maxSpeed being like a soft limit
        if (xVel > maxBoostSpeed)
        {
            xVel = maxBoostSpeed;
        }
        else if (xVel < -maxBoostSpeed)
        {
            xVel = -maxBoostSpeed;
        }
        if (zVel > maxBoostSpeed)
        {
            zVel = maxBoostSpeed;
        }
        else if (zVel < -maxBoostSpeed)
        {
            zVel = -maxBoostSpeed;
        }
        //Update the velocity
        m_rb.velocity = new Vector3((dir.forward.x * zVel) + (dir.right.x * xVel), m_rb.velocity.y, (dir.forward.z * zVel) + (dir.right.z * xVel)); //Set the velocity, allowing the player to boost in the air
    }

    public void ResetVel() //Reset the velocity, called when the player is reset to the latest checkpoint.
    {
        xVel = 0;
        zVel = 0;
    }

    public void UpdateVel() //Just used to update velocity after player is reset
    {
        m_rb.velocity = new Vector3((dir.forward.x * zVel) + (dir.right.x * xVel), m_rb.velocity.y, (dir.forward.z * zVel) + (dir.right.z * xVel));
    }

    public void setMaxSpeed(float i, bool boostable) //Setter for the max speed, used in the final level
    {
        //Set the max speed
        m_maxSpeed = i;
        switch(boostable) 
        {
            case true: //If boostable is true
                maxBoostSpeed = 40f; //Dont change boostable value
                break;
            case false: //Else
                maxBoostSpeed = i; //Change the boostable to the same as the max speed
                break;
        }
    }

}
