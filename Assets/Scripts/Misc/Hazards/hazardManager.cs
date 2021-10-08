using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazardManager : MonoBehaviour
{
    //grapple script
    public grapplehook grapple;
    //player gameobject
    public GameObject player;
    //Player's spawnpoint
    public Transform spawn;

    public movement move;

    public deathSound dSound; //Death sound list
    int deaths;

    void Start()
    {
        deaths = PlayerPrefs.GetInt("DeathNo", 0);
    }

    //resetting boolean, so it only resets once at a time
    public bool resetting;

    public IEnumerator reset()
    {
        //Set resetting to true so it only resets once
        resetting = true;
        //increase the death number by 1 (Not used for anything yet, but still tracked)
        PlayerPrefs.SetInt("DeathNo", PlayerPrefs.GetInt("DeathNo", 0) + 1);
        //Get the death's number
        deaths = PlayerPrefs.GetInt("DeathNo", 0);
        //if (deaths > 3)
        //{
        //Play a random death voiceline
        switch (Random.Range(0, 4))
        {
            case 0: //First death voiceline
                dSound.Play("Death1");
                Debug.Log("Sound1");
                break;
            case 1://second death voiceline
                dSound.Play("Death2");
                Debug.Log("Sound2");
                break;
            case 2: //third death voiceline 
                dSound.Play("Death3");
                Debug.Log("Sound3");
                break;
            case 3: //fourth death voiceline
                dSound.Play("Death4");
                Debug.Log("Sound4");
                break;
            default://First death voiceline as default
                dSound.Play("Death1");
                Debug.Log("Sound1");
                break;
        }
        //}
        //wait for 2 seconds
        yield return new WaitForSeconds(2);
        //respawn the player at the spawnpoint (Just moves them there)
        player.transform.position = spawn.position;
        //Stop the player grappling (If they are)
        grapple.StopGrapple();
        //reset teh velocity of the player to 0
        move.ResetVel();
        //update the player's velocity to 0
        move.UpdateVel();
        //set resetting to false, as its now done.
        resetting = false;
    }
}
