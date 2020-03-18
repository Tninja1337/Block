using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour {


	void Update () {

		if(Input.GetButtonDown("Fire2"))
		{
			//Alternates between normal speed and 10% speed when pressed
			if (Time.timeScale == 1.0f) {
				Time.timeScale = 0.1f;
			} else {
				Time.timeScale = 1.0f;
			}
			//Multiplies the physics and frame rate updates by the current timescale
			Time.fixedDeltaTime = 0.02f * Time.timeScale;
	}
	}
}
