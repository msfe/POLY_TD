using UnityEngine;
using System.Collections;

public class OrphanageBehaviour : MonoBehaviour {

	private float _health;
	private bool _destroyed;

	public static OrphanageBehaviour s_ORPHANAGE;

	// Use this for initialization
	void Start () {
		s_ORPHANAGE = this;
		s_ORPHANAGE.setHealth(100);
		s_ORPHANAGE.setDestroyed(false);
	}

	public void repair(float amount){
			_health += amount;
			if (_health > 100) {
					_health = 100;
			}
	}

	public void damage(float amount){
		_health -= amount;
		if (_health < 0 && !_destroyed) {
			_destroyed = true;
			Application.LoadLevel(0);
		}
	}

	private void setHealth(float health){
		_health = health;
	}

	public float getHealth(){
		return _health;
	}

	private void setDestroyed(bool destroyed){
		_destroyed = destroyed;
	}
	public bool isDestoryed(){
		return _destroyed;
	}
}
