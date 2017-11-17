using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControllerFight : MonoBehaviour {

	//Variables

	public float speed;
	public float sprint;
	public float xRotation;
	public float mouseSensitivity=5.0f;
	public float timeLeft = 300.0f;
	public float minutes =5.0f;
	public float seconds;

	public GameObject enemy;
	public EnemyBoss enemyBoss;
	private bool gameOver;
	private Rigidbody rb;
	private Scene currentScene;
	private string sceneName;
	public Text timeLeftText;


	void Start ()
	{
		currentScene = SceneManager.GetActiveScene ();
		sceneName = currentScene.name;
		enemy = GameObject.Find ("Enemy");
		enemyBoss = enemy.GetComponent<EnemyBoss>();
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

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 100.0f)) {
				if (hit.collider.isTrigger) {
					enemyBoss.takeDamage (1); 
				}
			}
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

		//If the boolean gameOver is true it will set the win text
		if (gameOver) {
			SceneManager.LoadScene ("FightScene");
		}
		timeLeft -= Time.deltaTime;
		minutes = Mathf.FloorToInt(timeLeft / 60);
		seconds = Mathf.FloorToInt(timeLeft % 60);
		if (seconds < 10) {
			timeLeftText.text = "Time Left: " + Mathf.Round (minutes) + ":0" + Mathf.Round (seconds);
		}
		else{
			timeLeftText.text = "Time Left: " + Mathf.Round (minutes) + ":" + Mathf.Round (seconds);
		}

	}
	void OnTriggerEnter(Collider other)
	{
		//If the character gets hit by a car it will respawn 
		if (other.gameObject.CompareTag ("Enemy")) {
			rb.AddForce(Vector3.back*15);
		}
	}
		
}
