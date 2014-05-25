using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour {

	public Transform BulletPrefab;
	private HeroBehaviour hero;

	private float ATTACK_DOWNTIME = 100.0f;
	private float BULLET_SPREAD = 0.3f;
	private float BULLET_SPEED = 5.0f;
	private float BULLET_DAMAGE = 4.0f;

	private float fireCounter;

	// Use this for initialization
	void Start () {
		hero = this.GetComponent<HeroBehaviour> ();
		fireCounter = 0;
	}

	void Update () {
		if (hero.isStanding()) {
			if (fireCounter <= 0) {
				Attack ();
				Attack ();
				Attack ();
				Attack ();
				Attack ();
				fireCounter = ATTACK_DOWNTIME;
			} else {
				fireCounter--;
			}
		} else if (fireCounter > 0) {
			fireCounter--;
		}
	}

	public void Attack(){
		Transform t = (Transform)Instantiate (BulletPrefab, transform.position, Quaternion.identity);
		BulletData bullet = t.GetComponent<BulletData> ();
		bullet.Damage = BULLET_DAMAGE;
		bullet.AutoAiming = false;
		Vector2 dir = Vec.xy (transform.rotation * Vector3.up) + BULLET_SPREAD * Random.insideUnitCircle;
		dir.Normalize ();
		t.rigidbody2D.velocity = -BULLET_SPEED * dir;
	}
	
}
