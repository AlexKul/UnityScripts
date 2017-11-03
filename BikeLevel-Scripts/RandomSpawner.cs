using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour {

	public Vector3[] spawnPos = new Vector3[3];
	public GameObject[] enemyObj = new GameObject[3];
	public GameObject bus;
	public GameObject car;
	public GameObject van;

	public int spawnSpeed;
	public int randomEnemy;
	public int spawnPoint;

	void Start(){
		spawnPos [0] = new Vector3 (-3f, 1.4f, 30f);
		spawnPos [1] = new Vector3 (-3f, 1.4f, 30f);
		spawnPos [2] = new Vector3 (0f, 1.4f, 30f);
		enemyObj [0] = bus;
		enemyObj [1] = car;
		enemyObj [2] = van;
		spawnSpeed = 4;
		InvokeRepeating ("Spawn", 1.0f, 2.5f);
	}

	void Update(){
		
	}
	void Spawn(){
		randomEnemy = Random.Range(0, 3);
		spawnPoint = Random.Range(0, 3);
		Instantiate(enemyObj[randomEnemy], spawnPos[spawnPoint], Quaternion.Euler(0,180,0));
	}
		
}
