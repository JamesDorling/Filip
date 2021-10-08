using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrigger : MonoBehaviour
{
    //Objects on the trigger
    private float objects = 0;
    //Is the cannon firing
    public bool firing = false;
    //orientation of the cannon
    private Transform orientation;
    //firing direction
    private Vector3 fireDir;
    //power to fire with
    private float power = 50;
    //transform of the ball
    private Transform transform;

    //cannon particle system
    public ParticleSystem parsys;

    //checker to make sure the object hasnt left the cannon
    private GameObject checker;

    //constraints of the object to fire
    private RigidbodyConstraints constraints;
    //audio to polay upon firing
    private AudioSource fireAudio;
    //Charging audio
    private AudioSource chargeAudio;

    //volume of the audio
    float vol;

    void Start()
    {
        //get the orientation
        orientation = GetComponent<Transform>();
        //use the orientation to get the firing direction
        fireDir = orientation.transform.up;
        //get the firing audio audiosource
        fireAudio = GetComponent<AudioSource>();
        //get the charge audiosource from the parent
        chargeAudio = orientation.parent.GetComponent<AudioSource>();
        //Debug.Log(fireDir);

    }

    private void OnTriggerEnter(Collider col)
    {
        //This code could probably be very easily revamped to be more efficient. Having the three if statements is pointless being as the grapplepoint and interactable have the same things happen to them.
        //However, I lack the time to do something like that currently.

        //if the object is not the floor or the grounded check hitbox
        if (col.gameObject.tag != "Floor" && col.gameObject.layer != LayerMask.NameToLayer("Ignore Raycast"))
        {
            //add one to the objects counter
            objects += 1;
           //start the firing coroutine with the gameobject
            StartCoroutine(Fire(col.gameObject));
            //set the checker to the gameobject
            checker = col.gameObject;
            //if the object is a grappleable or an interactable
            if (col.gameObject.layer == LayerMask.NameToLayer("Grappleable") || col.gameObject.layer == LayerMask.NameToLayer("Pullable") || col.gameObject.layer == LayerMask.NameToLayer("Disabled"))
            {
                //get the rigidbody
                Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
                //set the rigidbody's velocity to 0
                rb.velocity = new Vector3(0f, 0f, 0f);
                //get the rigidbodys constraints
                constraints = rb.constraints;
                //set the constraints to all
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
                //get the object's transform
                transform = col.gameObject.GetComponent<Transform>();
                //set the transform to be slightly higher than the cannon (Can go fast enough to glitch through the floor otherwise)
                transform.position = orientation.position + (orientation.transform.up * 0.45f);
            }
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
        {
            //Takes "ignore raycast" as that is the layer of the grounded checker
            //add one to the objects counter
            objects += 1;
            //start the firing coroutine with the player's rigidbody
            StartCoroutine(Fire(col.gameObject.transform.parent.gameObject));
            //Set the checker to the player
            checker = col.gameObject.transform.parent.gameObject;
        }
        else if (col.gameObject.tag == "Floor" && col.gameObject.layer == LayerMask.NameToLayer("Pullable"))
        {
            //add one to the objects counter
            objects += 1;
            //start the firing coroutine with the interactable
            StartCoroutine(Fire(col.gameObject));
            //set the checker to the interactable
            checker = col.gameObject;
            //get the rigidbody
            Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
            //set the velocity to 0
            rb.velocity = new Vector3(0f, 0f, 0f);
            //get the interactable's constraints
            constraints = rb.constraints;
            //set the constraints to all
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        //if an object leaves
        if (col.gameObject.tag != "Floor")
        {
            //remove one from the object counter
            objects -= 1;
            //set the checker to null (Probably shouldnt do it here, as this means that stepping on while a cannonball is on there could break the game. Hence why it is commented out.)
            //checker = null;
        }
    }

    void Update()
    {
        //Debug.Log(objects);
        if (objects > 0)
        {
            //Debug.Log("Firing");
            //if theres an object to fire, set firing to true
            firing = true;
        }
        else
        {
            //else firing is false
            firing = false;
        }
        //play the charging sound
        ChargeSound();
    }

    IEnumerator Fire(GameObject ammo)
    {
        Rigidbody rb = ammo.GetComponent<Rigidbody>();

        for (float i = 0; i < 3; i += Time.deltaTime) //For loop runs once a frame for 3 seconds
        {
            yield return 0; //Wait a frame
            if (objects == 0 || ammo != checker) //If the object is no longer on the cannon
            {
                yield break; //End the coroutine here
            }
        }

        if (ammo.layer == LayerMask.NameToLayer("Grappleable") || ammo.layer == LayerMask.NameToLayer("Pullable") || ammo.layer == LayerMask.NameToLayer("Disabled")) //If the object is a grappleable or a pullable then unrestrain it and fire it
        {
            rb.constraints = constraints;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z) + (fireDir * (power * 1.5f));
        }
        else //Else just fire it, as other objects didnt have their restraints changed
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z) + (fireDir * power);
        }
        //play the firing sound
        StartCoroutine(FireSound());
        parsys.Play(); //Play the particle system either way

    }

    IEnumerator FireSound()
    {
        //play the fire audio
        fireAudio.Play();
        //after 0.5 seconds
        yield return new WaitForSeconds(0.5f);
        //stop the audio so it can be played again
        fireAudio.Stop();
    }

    void ChargeSound()
    {
        //if the game is not paused
        if (inGameMenu.GamePaused == false)
        {
            //if the charge audio is not yet playing
            if(!chargeAudio.isPlaying)
            {
                //play the charge audio
                chargeAudio.Play();
            }
            if (objects > 0)
            {
                //get the sfx volume
                float i = PlayerPrefs.GetFloat("sfxVolume");
                //lerp the volume to the desired volume
                vol = Mathf.Lerp(vol, i * 100, 0.5f * Time.deltaTime);
                //set the volume to the lerped volume (divided by 100 as volume is 0 to 1 with audiosources)
                chargeAudio.volume = (vol / 100);
                //set the pitch to double that of the volume, so it goes from 0 to 2.
                chargeAudio.pitch = (vol / 100) * 2;

            }
            else
            {
                //else reset the volume to 0
                chargeAudio.volume = 0f;
                //reset the pitch to 0
                chargeAudio.pitch = 0f;
                //set vol to 0
                vol = 0;

            }
        }
        else
        {
            //pause the charge audio
            chargeAudio.Pause();
        }
    }
}
