using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNextWave : MonoBehaviour
{
    //Create a public game object that holds the Score Counter
    public GameObject toNextWave;
    // Create a public variable to hold the Score Script
    public Score updateWave;

    //Create public variables and text mesh linkage
    TextMesh Txt;
    public int scoreTotal;
    public int subtractor;
    public static int Wave;

    void Start()
    {
        //Get the number of how many points needed to get to the next wave, then set the UI text
        updateWave = toNextWave.GetComponent<Score>();
        Txt = gameObject.GetComponent<TextMesh>();
        Txt.text = "Wave: " + Wave + "                 Next Wave: " + scoreTotal;
        Wave = 1;
    }

    void Update()
    {
        //Update score total, how much is left until the next wave, and update the UI text
        scoreTotal = updateWave.levelTotal;
        subtractor = updateWave.score;
        scoreTotal = scoreTotal - subtractor;
        Txt.text = "Wave: " + Wave + "                 Next Wave: " + scoreTotal;
    }
}
