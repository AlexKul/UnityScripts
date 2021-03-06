using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerEscape : MonoBehaviour {

	//Variables
	public float xRotation;
	public float mouseSensitivity=5.0f;
	public float timeLeft = 300.0f;
	public float minutes =5.0f;
	public float seconds;
	public Text timeLeftText;

	private bool gameOver;
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
		timeLeft -= Time.deltaTime;
		minutes = Mathf.FloorToInt(timeLeft / 60);
		seconds = Mathf.FloorToInt(timeLeft % 60);
		if (seconds < 10) {
			timeLeftText.text = "Time Left: " + Mathf.Round (minutes) + ":0" + Mathf.Round (seconds);
		}
		else{
			timeLeftText.text = "Time Left: " + Mathf.Round (minutes) + ":" + Mathf.Round (seconds);
		}


		//If the boolean gameOver is true it will set the win text
		if (gameOver) {
			SceneManager.LoadScene ("EscapeRoom");
		}

	}
		
}
