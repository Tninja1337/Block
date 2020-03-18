using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
	//Set up public variables
	public GameObject HealthCount;
	public HealthSystem changeHealth;
	//Set up sound and hit UI
	public AudioSource audioSource;
	public GameObject hitPanel;

	// Use this for initialization
	void Start()
	{
		//Set changeHealth to the HealthCount component
		changeHealth = HealthCount.GetComponent<HealthSystem>();
	}

	void OnTriggerEnter(Collider other)
	{
		//On a collider collision with an Arrow, reduce health by 1
		if (other.gameObject.tag == "Arrow" || other.gameObject.tag == "FireArrow" || other.gameObject.tag == "IceArrow" || other.gameObject.tag == "PhaseArrow")
		{
			changeHealth.health = changeHealth.health - 1;
			Debug.Log(changeHealth.health);
			//Play hit sound and flash screen red
			audioSource.Play();
			hitPanel.SetActive(true);
			StartCoroutine(DamageReset());
		}
	}

	IEnumerator DamageReset()
	{
		//turn off the red flash after 1 second
		yield return new WaitForSeconds(1);
		hitPanel.SetActive(false);
	}
}
