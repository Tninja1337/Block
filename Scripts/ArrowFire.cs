using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFire : MonoBehaviour {

	//Setup gameobject to launch
	public GameObject arrow;
	//Allows custom fire rate on each 'archer' object and sets base rate
	public int fireRate = 4;
	//Set a random rate of fire
	private int randomFire;

	void Start () {
		//Start Arrow Spawning after a delay to allow orientation in Oculus
		StartCoroutine ("FirstSpawnArrow");
		//Set range of Random Firing
		randomFire = Random.Range(fireRate, fireRate+4);
	}

	IEnumerator FirstSpawnArrow()
	{
		//First arrow spawn of the map to allow extra time to orient and grab Shield, activates Launch()
		yield return new WaitForSeconds(10);
		Launch();
	}
	IEnumerator SpawnArrow () {
		//Activates Launch() at the fireRate or the Random rate
		yield return new WaitForSeconds (randomFire);
		Launch ();
	}

	void Launch () {
		//Set the arrow at a slightly randomized position before instantiating. then start the SpawnArrow() coroutine
		Vector3 position = new Vector3 (Random.Range (-0.1f, 0.1f), 1, Random.Range (-0.1f, 0.1f));
		//Vector3 position = new Vector3(0,0,0);
		position = transform.localPosition;
		Instantiate (arrow, position, Quaternion.Euler(90, 0, 0));

		StartCoroutine ("SpawnArrow");
	}
}
