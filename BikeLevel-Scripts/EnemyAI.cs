using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	public float enemySpeed;
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	

	void Update () {
		
		transform.Translate (Vector3.forward * enemySpeed * Time.deltaTime);	
		
	}
}
