using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseArrow : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{

		//When the phase arrow contacts the mirror shield, disappears and plays sound effect
		if (other.gameObject.tag == "MirrorShieldHit")
		{
			this.gameObject.SetActive(false);
		}

	}

}
