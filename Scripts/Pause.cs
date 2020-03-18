using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    //Set up paused boolean, and gameobject variables
    private bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject laserPointer;
    public GameObject timeSlower;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            //When Oculus Y is pressed, stop time, activate pause menu and pointer, deactivate timeslower
            if(isPaused == false)
            {
                Time.timeScale = 0;
                isPaused = true;
                pauseMenu.SetActive(true);
                laserPointer.SetActive(true);
                timeSlower.SetActive(false);
            }
            else
            {
                //Like above, but the opposite
                Time.timeScale = 1;
                isPaused = false;
                pauseMenu.SetActive(false);
                laserPointer.SetActive(false);
                timeSlower.SetActive(true);
            }
        }
    }

    public void Unpause()
    {
        //Unpauses like the else before, this is the the menu option vs the oculus button
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(false);
        laserPointer.SetActive(false);
        timeSlower.SetActive(true);      
    }
}
