using UnityEngine;
using System.Collections;

public class HeroBehaviour : MonoBehaviour {

    public float MaxMoveForce;
    public float MoveForce;
    public float Torque;
    public Transform BulletPrefab;

    private Vector2 _moveTarget;
    private bool selected;
    private Vector2 _targetLookAt;

	void Start () 
    {
	    
	}
	
	void Update () 
    {
        if (Input.GetMouseButton(0))
        {
             Move(Vec.xy(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
        }
        if (Input.GetMouseButton(1))
        {
            Vector2 mousePos = Vec.xy(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            Vector2 toMouse = mousePos - Vec.xy(transform.position);
            toMouse.Normalize();
            _targetLookAt = toMouse;
        }
        if (Input.GetMouseButton(2))
        {
            Transform t = (Transform)Instantiate(BulletPrefab, transform.position, Quaternion.identity);

            Vector2 dir = Vec.xy(transform.rotation * Vector3.up) + 0.5f * Random.insideUnitCircle;
            dir.Normalize();
            t.rigidbody2D.velocity = -5.0f * dir;

        }
	}

    void FixedUpdate()
    {
        Vector2 toTarget = _moveTarget - Vec.xy(transform.position);
        float dist = toTarget.magnitude;
        toTarget /= dist + 0.0001f;
        dist = Mathf.Clamp(dist * MoveForce, 0, MaxMoveForce);     
        rigidbody2D.AddForce(dist * toTarget);

        Vector2 look = transform.rotation * Vector3.up;
        Vector2 lookPerp = Vec.PerpendicularCW(look);
        float rot = Vector2.Dot(lookPerp, _targetLookAt);
        rigidbody2D.AddTorque(rot * Torque);
    }

    void Move(Vector2 target)
    {
        _moveTarget = target;
        _targetLookAt = target - Vec.xy(transform.position);
        _targetLookAt.Normalize();
    }
}
