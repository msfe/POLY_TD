using UnityEngine;
using System.Collections;

public class HeroBehaviour : MonoBehaviour {

    public float MaxMoveForce;
    public float MoveForce;
    public float Torque;

    private Vector2 _moveTarget;
    private bool selected;
    private Vector2 _targetLookAt;
	private bool _active;
	private Color _startcolor;

	void Start () 
    {
		_active = false;
		_startcolor = renderer.material.color;
		_moveTarget = Vec.xy (transform.position);
	}
	
	void Update () 
    {
		if (_active) {
			renderer.material.color = Color.yellow;
			if (Input.GetMouseButtonDown (0)) {
				if(Vector2.Distance(Vec.xy (Camera.main.ScreenToWorldPoint (Input.mousePosition)), transform.position)>0.6f){
					Move (Vec.xy (Camera.main.ScreenToWorldPoint (Input.mousePosition)));
				} 
				_active = false;
			}
			if (Input.GetMouseButton (1)) {
					Vector2 mousePos = Vec.xy (Camera.main.ScreenToWorldPoint (Input.mousePosition));
					Vector2 toMouse = mousePos - Vec.xy (transform.position);
					toMouse.Normalize ();
					_targetLookAt = toMouse;
			}
		} else {
			renderer.material.color = _startcolor;
			if (Input.GetMouseButtonDown (0)) {
				if(Vector2.Distance(Vec.xy (Camera.main.ScreenToWorldPoint (Input.mousePosition)), transform.position)<0.6f){
					_active = true;
				}
			}
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

	public bool isStanding(){
		return rigidbody2D.velocity.magnitude < 0.01f;
	}
}
