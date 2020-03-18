using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TotalCounter : MonoBehaviour
{
    //Assign a text mesh variable
    TextMesh Txt;

    void Start()
    {
        //Get the text mesh component and change the text to be equal to the players total score
        Txt = gameObject.GetComponent<TextMesh>();
        Txt.text = "Total Blocked: " + Score.totalScore;
    }

}
