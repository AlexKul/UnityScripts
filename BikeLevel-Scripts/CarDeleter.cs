using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A class that follows an invisible plane that deletes car objects
public class CarDeleter : MonoBehaviour {

	public Transform target;

	public float targetDistance = 15;

	void Update () {

		//makes it so that the delete plane
		transform.position = target.position - target.forward * targetDistance;

	}
	void OnTriggerEnter(Collider other)
	{
		//If the character gets hit by a car it will respawn 
		if (other.gameObject.CompareTag ("Enemy")) {
			other.gameObject.SetActive (false);
		}
	}
}