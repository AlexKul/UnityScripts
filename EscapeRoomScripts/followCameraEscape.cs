using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCameraEscape : MonoBehaviour {

	public float mouseSensitivity = 5.0f;
	public Transform target;

	public float xRotation;
	public float yRotation;
	public float targetDistance = 0;
	public Vector2 yMinMax = new Vector2(-30, 25);

	void Update () {

		//Gets the y and x rotation of a mouse and clamps it so you cant rotate around a character 
		yRotation -= Input.GetAxis ("Mouse Y") * mouseSensitivity;
		yRotation = Mathf.Clamp (yRotation, yMinMax.x, yMinMax.y);
		xRotation += Input.GetAxis ("Mouse X") * mouseSensitivity;


		Vector3 mouseRotation = new Vector3 (yRotation, xRotation); 

		transform.eulerAngles = mouseRotation;
		//makes it so that the camera follows the target
		transform.position = target.position - target.forward * targetDistance;
		
	}
}
