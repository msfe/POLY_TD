using UnityEngine;
using System.Collections;

public class BulletCollision : MonoBehaviour {
	
	EnemyBehaviour _enemy;
	
	// Use this for initialization
	void Start () {
		_enemy = this.GetComponent<EnemyBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Bullet") {
			_enemy.takeDamage(10);
			Destroy(collider.gameObject);
		}
	}
}
