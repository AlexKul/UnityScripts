using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//Variables

	public float speed;
	public float xRotation;
	public float mouseSensitivity=5.0f;
	public Vector3 still = new Vector3 (0.0f, 0.0f, 0.0f);

	private bool gameOver;
	private Animator anim;
	private Rigidbody rb;
	private Scene currentScene;
	private string sceneName;


	void Start ()
	{
		currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
		rb = GetComponent<Rigidbody>();
		gameOver = false;
	}

	// Updates the character based on what keys are pressed
	void Update ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		//Makes it so that mouse movement only moves the character around the y axis. 
		xRotation += Input.GetAxis ("Mouse X") * mouseSensitivity;

		Vector3 mouseRotation = new Vector3 (0, xRotation);

		transform.eulerAngles = mouseRotation;


		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		//If the A key is pressed move left
		if (Input.GetKey (KeyCode.A)) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		//If the W key is pressed move Up
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime); 
		}
		//If the D key is pressed move Right
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (Vector3.right * speed * Time.deltaTime); 
		}
		//If the S key is pressed move back
		if (Input.GetKey (KeyCode.S)) {
			transform.Translate (Vector3.back * speed * Time.deltaTime); 
		} 

		//If the velocity is to high, does not allow for a double jump
		if (rb.velocity.y < 2 && rb.velocity.y > -2) {
			//If the velocity was low enough allow for the Jump button (space) to be pushed
			//the character will then jump 
			if (Input.GetButtonDown ("Jump")) {
				rb.velocity = new Vector3 (rb.velocity.x, 8.0f, rb.velocity.z);
			}
		}
		//If the boolean gameOver is true it will set the win text
		if (gameOver) {
			
		}

	}

	//If a trigger is entered this will run
	void OnTriggerEnter(Collider other)
	{
		//If the character gets hit by a car it will respawn 
		if (other.gameObject.CompareTag ("Enemy")) {
			SceneManager.LoadScene ("BikeScene");
		}
	}
}
