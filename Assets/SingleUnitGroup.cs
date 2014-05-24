using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SingleUnitGroup : MonoBehaviour
{

    public Waypoints _waypoints;
    public float _continueDistance = 1f;
    public float _forwardSpeed = 1f;

    GroupMembers _members;
    float _pathPosition;
    Vector2 _target;

    void Start()
    {
        _members = GetComponent<GroupMembers>();

        _pathPosition = 0;
        updateTarget();
    }

    void FixedUpdate()
    {
        bool update = false;
        foreach (var enemy in _members.enemies)
        {
			if(enemy == null)
				continue;

            float dist = Vector2.Distance(_target, Vec.xy(enemy.transform.position));
            if (dist < _continueDistance)
            {
                _pathPosition += _forwardSpeed * Time.fixedDeltaTime;
                update = true;
                break;
            }
        }

        if (update)
        {
            updateTarget();
        }
    }

    public void updateTarget()
    {
        foreach (var enemy in _members.enemies)
        {
            _target = _waypoints.getPoint(_pathPosition); 
            enemy.MoveTarget = _target;
            transform.position = _target;
        }
    }
}
