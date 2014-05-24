using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    public Vector2 MoveTarget;
    public float MoveForce;
    public float AngularForce;
    public float Drag { get { return rigidbody2D.drag; } set { rigidbody2D.drag = value; } }
    public Waypoints _waypoints;


	void Start () 
    {
	}
	
	void Update () 
    {
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
