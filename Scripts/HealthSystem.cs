using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    //Set up text mesh and public variables
    TextMesh Txt;
    public int health = 10;
    public int death;

    void Start()
    {
        //Set the text mesh to the health UI and change the text
        Txt = gameObject.GetComponent<TextMesh>();
        Txt.text = "" + health;
    }

    void Update()
    {
        //Update current health
        Txt.text = "" + health;
        
        //Change health color to denote low HP
        if (health < 4)
        {
            Txt.color = Color.red;
        }

        //When health is at or lower than the count of death, load GameOver scene
        if (health <= death)
        {
            Debug.Log("You've been pincushioned...");
            //Load Game Over
            SceneManager.LoadScene(2);
        }

    }


}
