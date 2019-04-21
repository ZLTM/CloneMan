﻿using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour
{
    private int Collected = 0; //Set up a variable to store how many you've collected
    public AudioClip CollectedClip;     //This is the sound that will play after you collect one
    public AudioSource CollectedSource;     //This is the sound that
    public float Volume = 1.0f;
    public float CanvasX = 10f;
    public float CanvasY = 10f;
    public float CanvasWidth = 100f; //NOT smaller than 100 or the score wont show
    public float CanvasHeight = 20f;


    //This is the text that displayed how many you've collected in the top left corner
    void OnGUI()
    {
        GUI.Label(new Rect(CanvasX, CanvasY, CanvasWidth, CanvasHeight), "Collected:" + Collected);
    }

    private void OnTriggerEnter(Collider other)
    { //Checks to see if you've collided with another object

        if (other.CompareTag("Collectable"))
        { //checks to see if this object is tagged with "collectable"
            CollectedSource.PlayOneShot(CollectedClip); //plays the sound assigned to collectedSound
            Collected++; //adds a count of +1 to the collected variable
            Destroy(other.gameObject); //destroy's the collectable
        }

        if (other.CompareTag("Enemy"))
        { //checks to see if this object is tagged with "collectable"
            CollectedSource.PlayOneShot(CollectedClip); //plays the sound assigned to collectedSound
            Collected=666; //adds a count of +1 to the collected variable
        }
    }
}