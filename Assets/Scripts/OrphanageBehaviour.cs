using UnityEngine;
using System.Collections;

public class OrphanageBehaviour : MonoBehaviour {

	private float _health;
	private bool _isDestroyed;

	// Use this for initialization
	void Start () {
		_health = 100;
		_isDestroyed = false;
	}

	void repair(float amount){
			_health += amount;
			if (_health > 100) {
					_health = 100;
			}
	}

	void damage(float amount){
		_health -= amount;
		if (_health < 0) {
			_isDestroyed = true;
		}
	}

	float getHealth(){
		return _health;
	}

	bool isDestoryed(){
		return _isDestroyed;
	}
}
