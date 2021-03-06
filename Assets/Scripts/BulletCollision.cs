﻿using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {
	
	public EnemyBehaviour _enemy;
	public float ImpulseMagnitude = 0.7f; 
	
	// Use this for initialization
	void Start () {
		//_enemy = this.GetComponent<EnemyBehaviour>();
		if(_enemy == null)
			_enemy = GetComponentInChildren<EnemyBehaviour> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.gameObject.tag == "Bullet") {
			
			_enemy.rigidbody2D.AddForceAtPosition(ImpulseMagnitude * collider.rigidbody2D.velocity.normalized / Time.fixedDeltaTime, collider.transform.position);
			BulletData bullet = collider.GetComponent<BulletData>();
			_enemy.takeDamage(bullet.Damage);
			Destroy(collider.gameObject);
		}
	}
}
