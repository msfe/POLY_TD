using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {
	
	EnemyBehaviour _enemy;
	public float ImpulseMagnitude = 0.7f; 
	
	// Use this for initialization
	void Start () {
		_enemy = this.GetComponent<EnemyBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.gameObject.tag == "Bullet") {
			
			rigidbody2D.AddForceAtPosition(ImpulseMagnitude * collider.rigidbody2D.velocity.normalized / Time.fixedDeltaTime, collider.transform.position);

			_enemy.takeDamage(1);
			Destroy(collider.gameObject);
		}
	}
}
