using UnityEngine;
using System.Collections;

public class Machinegun : MonoBehaviour {
	
	public Transform BulletPrefab;
	private HeroBehaviour hero;
	
	private bool ATTACK_WHILE_MOVING = false;
	private float ATTACK_DOWNTIME = 20.0f;
	private float ATTACK_MOUNTTIME = 200.0f; 
	private float BULLET_SPREAD = 0.15f;
	private float BULLET_SPEED = 5.0f;
	private float BULLET_DAMAGE = 2.0f;
	private int BULLETS_PER_ATTACK = 1;
	
	private float fireCounter;
	private float mountCounter;
	
	// Use this for initialization
	void Start () {
		hero = this.GetComponent<HeroBehaviour> ();
		fireCounter = 0;
		mountCounter = 0;
	}
	
	void Update () {
		if (hero.isStanding() || ATTACK_WHILE_MOVING) {
			if (fireCounter <= 0 && mountCounter <= 0) {
				for(int i = 0; i<BULLETS_PER_ATTACK;i++){
					Attack ();
				}
				fireCounter = ATTACK_DOWNTIME;
			} else {
				mountCounter--;
			}
		} else {
			mountCounter = ATTACK_MOUNTTIME;
		}
		if (fireCounter > 0) 
		{
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
