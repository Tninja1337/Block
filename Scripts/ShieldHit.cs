using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHit : MonoBehaviour {

	//Set up score variables
	public GameObject ScoreCount;
	public Score addScore;

	void Start () {
		//Set addscore to the Score script
		addScore = ScoreCount.GetComponent<Score> ();
	}

	void OnTriggerEnter(Collider other) {

		//When an arrow connects with the shield, increase score by one and call on Score script to update UI
		if (this.gameObject.tag == "ShieldHit" && (other.gameObject.tag == "Arrow" || other.gameObject.tag == "FireArrow" || other.gameObject.tag == "IceArrow")) {
			addScore.score = addScore.score + 1;
			Score.totalScore++;
			Debug.Log (addScore.score);
		}

		//Phase Arrow only provides score if user is wielding the Mirror Shield
		if (this.gameObject.tag == "MirrorShieldHit" && (other.gameObject.tag == "Arrow" || other.gameObject.tag == "FireArrow" || other.gameObject.tag == "IceArrow" || other.gameObject.tag == "PhaseArrow"))
		{
			addScore.score = addScore.score + 1;
			Score.totalScore++;
			Debug.Log(addScore.score);
		}
	}
}
