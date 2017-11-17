using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerPuzzle : MonoBehaviour {

	//Variables

	public float speed;
	public float sprint;
	public float xRotation;
	public float mouseSensitivity=5.0f;
	public Vector3 gravity;
	public float x;

	private bool gameOver;
	private Rigidbody rb;
	private Scene currentScene;
	private string sceneName;
	public Text timeLeftText;


	void Start ()
	{
		currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
		rb = GetComponent<Rigidbody>();
		gameOver = false;
		gravity = Physics.gravity;
	}

	// Updates the character based on what keys are pressed
	void Update ()
	{
		Physics.gravity = gravity;
		//If the shift key is pressed gravity will change
		Vector3 up = transform.TransformDirection (Vector3.up);

		//Creates a raycast to see if the player can change gravity
		Vector3 casterUp = new Vector3(transform.position.x, transform.position.y+7, transform.position.z);
		Ray gravityRayUp = new Ray (casterUp, Vector3.up);
		Vector3 casterDown = new Vector3(transform.position.x, transform.position.y-3, transform.position.z);
		Ray gravityRayDown = new Ray (casterDown, Vector3.down);

		RaycastHit hit;
		if(Physics.Raycast(gravityRayUp, out hit, 8))
		{
			if (Input.GetKey (KeyCode.LeftShift)) {
				gravity.y = 180;
				transform.Translate (Vector3.up * speed * Time.deltaTime);
				x += Time.deltaTime * 180;
				transform.rotation = Quaternion.Euler(x,0,0);
			}
		} 
		if(Physics.Raycast(gravityRayDown, out hit, -5))
		{
			if (Input.GetKey (KeyCode.LeftShift)) {
				gravity.y = 0;
				transform.Translate (Vector3.down * speed * Time.deltaTime);
			}
		} 
		if (!Input.GetKey (KeyCode.LeftShift)) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			//Makes it so that mouse movement only moves the character around the y axis. 
			xRotation += Input.GetAxis ("Mouse X") * mouseSensitivity;
			Vector3 mouseRotation;

			if (gravity.y > -11 && gravity.y < -2) {
				 mouseRotation = new Vector3 (0, xRotation);
			} else {
				mouseRotation = new Vector3 (180, xRotation);
			}

			transform.eulerAngles = mouseRotation;

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		}

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

		//If the boolean gameOver will reload the level on failure
		if (gameOver) {
			SceneManager.LoadScene ("FightScene");
		}

	}
	void OnTriggerEnter(Collider other)
	{
		//If the character gets hit by an enemy the character goes back
		if (other.gameObject.CompareTag ("Enemy")) {
			rb.AddForce(Vector3.back*15);
		}
	}
		
}
