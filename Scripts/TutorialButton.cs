using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialButton : MonoBehaviour
{
    //Assign Game Object to Activate
    public GameObject target;
    
    public void ButtonPressed()
    {
        //Activate Arrows
        target.GetComponent<ArrowFire>().enabled = true;

    }

}
