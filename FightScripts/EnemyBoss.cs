using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyBoss : MonoBehaviour {
	public float enemySpeed;
	public float enemyHealth;
	public Text bossHealth;
	private Rigidbody rb;


	void Start () {
		rb = GetComponent<Rigidbody>();
		enemyHealth = 10;
		bossHealth.text = "Boss Health: "+enemyHealth;
	}


	void Update () {

		transform.Translate (Vector3.forward * enemySpeed * Time.deltaTime);
		if (enemyHealth == 0) {

		}

	}
	public void takeDamage (int damage){
		enemyHealth -= damage;
		bossHealth.text = "Boss Health: "+enemyHealth;
	}
}
