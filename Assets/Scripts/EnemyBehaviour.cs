using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public Vector2 MoveTarget;
    public float MoveForce;
    public float AngularForce;
    public float Drag { get { return rigidbody2D.drag; } set { rigidbody2D.drag = value; } }
    public Waypoints _waypoints;

	public float ATTACK_DOWNTIME = 60;
	public float ATTACK_DAMAGE = 5;

	private bool _closeToOrphanage;
	private float fireCounter;

	public float Health{
		get;
		private set;
	}


	void Start () 
    {
		Health = 20;
		_closeToOrphanage = true;
		fireCounter = 0;
	}
	
	void Update () 
    {
		if (_closeToOrphanage) {
				if (fireCounter <= 0) {
					Attack ();
					fireCounter = ATTACK_DOWNTIME;
				} else {
						fireCounter--;
				}
		} else if (fireCounter > 0) {
				fireCounter--;
		}
	}

	private void Attack(){
		OrphanageBehaviour.s_ORPHANAGE.damage (ATTACK_DAMAGE);
	}

	public void takeDamage(float damage) {
		if (damage < 0) {
				return;
		}
		Health -= damage;
		if (Health <= 0) { //Dead
				Destroy (this.gameObject);
		}
	}

	public void setCloseToOrphanage(bool closeToOrphanage)
	{
		_closeToOrphanage = closeToOrphanage;
	}

    void FixedUpdate()
    {
        Vector2 toTarget = Vec.xy(transform.position) - MoveTarget;
        float dist = toTarget.magnitude;
        toTarget /= dist;

        Vector2 look = transform.rotation * Vector3.up;
        Vector2 lookPerp = Vec.PerpendicularCW(look);
        float rot = Vector2.Dot(lookPerp, toTarget);

        rigidbody2D.AddForce(look * MoveForce);
        rigidbody2D.AddTorque(rot * AngularForce);
    }
}
