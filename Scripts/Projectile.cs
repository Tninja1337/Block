using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	//Credit for projectile script: Volkan Ilbeyli, https://vilbeyli.github.io/Projectile-Motion-Tutorial-for-Arrows-and-Missiles-in-Unity3D/

	//Launch variables
	[SerializeField] private Transform TargetObject; //Set Target.
	[Range(1.0f, 10.0f)] public float TargetRadius; //How far around the target?
	[Range(20.0f, 75.0f)] public float LaunchAngle; //How high to launch?
	[Range(0.0f, 10.0f)] public float TargetHeightOffsetFromGround; //How tall is target's height?

	public bool randomizeHeightOffset; //Randomize height to aim at.

    //Booleans
	private bool bTargetReady; //Ready to fire
	private bool bTouchingGround; 

	private Rigidbody rigid; //Call rigidbody.
	private Vector3 initialPosition; //Set initial position and rotation.
    private Quaternion initialRotation;
    //Transform target; T: Outdated

    // Use this for initialization
    void Start () {
		rigid = GetComponent<Rigidbody> ();
		bTargetReady = true;
		initialPosition = transform.position;
		initialRotation = transform.rotation;

		Launch ();
      //target = GameObject.Find("CenterEyeAnchor").transform; //VR Targeting. T: Outdated
	}

    //Reset position, rotation, and velocity
	void ResetState() {
		rigid.velocity = Vector3.zero;
		this.transform.SetPositionAndRotation (initialPosition, initialRotation);
		bTargetReady = false;
	}

	// Update is called once per frame
	void Update () {

        /*Manually fire an arrow using spacebar.
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (bTargetReady) {
				Launch ();
			} else {
				ResetState ();
				SetNewTarget (); //(changes position of the target location); T: Do not need new target.
				bTargetReady = true;
			}
		}

        //Reset arrow with the R key.
		if (Input.GetKeyDown (KeyCode.R)) {
			ResetState();
		}*/

        //If the arrow is not touching the ground, and it is still ready...
		if (!bTouchingGround && !bTargetReady) {
			//update rotation of projectile during motion
			transform.rotation = Quaternion.LookRotation(rigid.velocity) * initialRotation;
		}
	}

    //When it collides set touching ground to true, or vice versa.
	void OnCollisionEnter() {
		bTouchingGround = true;
	}

	void OnCollisionExit() {
		bTouchingGround = false;
	}

    //Finds the offset of the ground.
	float GetPlatformOffset() {
		float platformOffset = 0.0f;

		foreach (Transform childTransform in TargetObject.GetComponentInChildren<Transform>()) {
			//take into account y-offset of plane
			if (childTransform.name == "Plane") {
				platformOffset = childTransform.localPosition.y;
				break;
			}
		}
		return platformOffset;
	}

	//Launches object towards target with launch angle
	void Launch() { 

        //Set projectile position and find target position.
		Vector3 projectileXZPos = new Vector3 (transform.position.x, 0.0f, transform.position.z);
		Vector3 targetXZPos = new Vector3 (TargetObject.position.x, 0.0f, TargetObject.position.z);

		//Rotate object to face target
		transform.LookAt(targetXZPos);

		//Formula
        //Finds the distance, takes gravity into account, and calculates launch statistics to get the arrow to the players position..
		float R = Vector3.Distance (projectileXZPos, targetXZPos);
		float G = Physics.gravity.y;
		float tanAlpha = Mathf.Tan (LaunchAngle * Mathf.Deg2Rad);
		float H = (TargetObject.position.y + GetPlatformOffset ()) - transform.position.y;

		//Calculate initial speed to land on target
		float Vz = Mathf.Sqrt( G * R * R / (2.0f * (H - R * tanAlpha)) );
		float Vy = tanAlpha * Vz;

		//Create velocity vector
		Vector3 localVelocity = new Vector3(0f, Vy, Vz);
		Vector3 globalVelocity = transform.TransformDirection (localVelocity);

		//Launch it
		rigid.velocity = globalVelocity;
		bTargetReady = false;
		//
	}

    //Destroys arrow gameobject.
	IEnumerator removeArrow () {
		yield return new WaitForSeconds (10);
		this.gameObject.SetActive(false);
	}


	//Randomizes the location of the target.
	void SetNewTarget() {
		Transform targetTF = TargetObject.GetComponent<Transform> ();
		//Acquire a new target from a point around the projectile
		//Start with a vector, use quaternion to rotate our vector
		Vector3 rotationAxis = Vector3.up;
		float randomAngle = Random.Range (0.0f, 360.0f);
		Vector3 randomVectorOnGroundPlane = Quaternion.AngleAxis (randomAngle, rotationAxis) * Vector3.right;

		//Scale randomVector with target radius, and add an offset to make the start
		//position the same height as the target
		float heightOffset = (randomizeHeightOffset ? Random.Range(0.2f, 1.0f) : 1.0f) * TargetHeightOffsetFromGround;
		float aboveOrBelowGround = (Random.Range (0.0f, 1.0f) > 0.5f ? 1.0f : 1.0f);
		Vector3 heightOffsetVector = new Vector3(0, heightOffset, 0) * aboveOrBelowGround;
		
		Vector3 randomPoint = randomVectorOnGroundPlane * TargetRadius + heightOffsetVector;//new Vector3(0, targetTF.position.y, 0);

		//Set target objects position and update our state
		TargetObject.SetPositionAndRotation(randomPoint, targetTF.rotation);
		bTargetReady = true;
	}




}
