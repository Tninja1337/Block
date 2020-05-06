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

    //Chuck Variables
    float pitchMin = 0;
    float pitchMax = 4;
    string time = "second";

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
            GetComponent<ChuckSubInstance>().RunCode(string.Format(@"

		        Gain master => dac;
                Mandolin m => master;

                fun void playNote(float bodySize, float position, float passTime)
                {{
                    [300, 310, 320, 330, 360] @=> int pitches[];
    
                    Math.random2({0}, {1}) => int randomPitch;
                    Math.random2f(0.02, 0.08) => float randomDetune;
                    Math.random2f(0.4, 0.6) => float randomDamping;
    
    
                    position => m.pluckPos;
                    pitches[randomPitch] => m.freq;
                    randomDetune => m.stringDetune;
                    bodySize => m.bodySize;
                    randomDamping => m.stringDamping; //shortens the chord
                    1.0 => m.noteOn; //also known as pluck, plays the Note
    
                    passTime::{2} => now;
                }}


                playNote(0.12, 0.17, 0.2);
                playNote(0.06, 0.37, 0.8);
                //playNote(0.12, 0.67, 0.8);
		     ", pitchMin, pitchMax, time));
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

        GetComponent<ChuckSubInstance>().RunCode(@"

		        Gain master => dac;
                Mandolin m => master;

                fun void playNote(float bodySize, float position, float passTime)
                {
                    [300, 310, 320, 330, 360] @=> int pitches[];
    
                    Math.random2(0, 4) => int randomPitch;
                    Math.random2f(0.02, 0.08) => float randomDetune;
                    Math.random2f(0.4, 0.6) => float randomDamping;
    
    
                    position => m.pluckPos;
                    pitches[randomPitch] => m.freq;
                    randomDetune => m.stringDetune;
                    bodySize => m.bodySize;
                    randomDamping => m.stringDamping; //shortens the chord
                    1.0 => m.noteOn; //also known as pluck, plays the Note
    
                    passTime::second => now;
                }


                playNote(0.12, 0.17, 0.2);
                playNote(0.06, 0.37, 0.8);
                //playNote(0.12, 0.67, 0.8);
		     ");
    }
}
