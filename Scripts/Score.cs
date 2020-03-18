using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    //Set UI Text Mesh component and public variables
    TextMesh Txt;
	public int score = 0;
    public static int totalScore;
    public int index; //Set to current level
    public int levelTotal;
    
	void Start () {
        //Set text mesh to the UI component and set beginning score
        Txt = gameObject.GetComponent<TextMesh>();
        Txt.text = "Blocked: " + score;
        
    }

    void Update() {
        //Update the current total score
        Txt.text = "Blocked: " + score;
       
        //If the score is higher than the level's total score, load the next scene
        if (score >= levelTotal)
        {
            ToNextWave.Wave += 1;
            Debug.Log("Next level loading...");
            if(index == 0)
            {
                //Load Summer
                SceneManager.LoadScene(4);
            }
            else if (index == 1)
            {
                //Load SummerNight
                SceneManager.LoadScene(5);
            }
            else if (index == 2)
            {
                //Load Fall
                SceneManager.LoadScene(6);
            }
            else if (index == 3)
            {
                //Load FallNight
                SceneManager.LoadScene(7);
            }
            else if (index == 4)
            {
                //Load Winter
                SceneManager.LoadScene(8);
            }
            else if (index == 5)
            {
                //Load Winter Night
                SceneManager.LoadScene(9);
            }
            else if (index == 6)
            {
                //Load MainMenu
                SceneManager.LoadScene(0);
            }

        }

    }


}
