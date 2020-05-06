using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //Chuck Variables
    float pitchMin = 0;
    float pitchMax = 4;
    string time = "second";

    //This class pertains to any scene loading or changing
    public void GoToMain()
    {
        //Load Main Menu
        playMandarin();
        Time.timeScale = 1;
        StartCoroutine(MainChord());
    }

    IEnumerator MainChord()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
        
    }

    public void RestartLevel1()
    {
        //Load Summer
        playMandarin();
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
        
    }

    public void Quit()
    {
        playMandarin();
        Time.timeScale = 1;
        Application.Quit();
    }

    public void LoadLevel0()
    {
        //Load Tutorial
        playMandarin();
        Time.timeScale = 1;
        SceneManager.LoadScene(3);
        
    }

    public void LoadLevel1()
    {
        //Load Summer
        playMandarin();
        Time.timeScale = 1;
        SceneManager.LoadScene(4);
        
    }

    public void LoadLevel2()
    {
        //Load SummerNight
        playMandarin();
        Time.timeScale = 1;
        SceneManager.LoadScene(5);
        
    }

    public void LoadLevel3()
    {
        //Load Fall
        playMandarin();
        Time.timeScale = 1;
        SceneManager.LoadScene(6);
        
    }

    public void LoadLevel4()
    {
        //Load FallNight
        playMandarin();
        Time.timeScale = 1;
        SceneManager.LoadScene(7);
        
    }
    public void LoadLevel5()
    {
        //Load FallNight
        playMandarin();
        Time.timeScale = 1;
        SceneManager.LoadScene(8);
        
    }
    public void LoadLevel6()
    {
        //Load FallNight
        playMandarin();
        Time.timeScale = 1;
        SceneManager.LoadScene(9);
        
    }

    public void LevelSelect()
    {
        //Load Level Select
        playMandarin();
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        
    }

    public void playMandarin()
    {
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
