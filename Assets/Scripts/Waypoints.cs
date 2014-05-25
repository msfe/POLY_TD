using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoints : MonoBehaviour {

	private List<Vector2> wayPoints = new List<Vector2>();
	private float length = 0;

	// Use this for initialization
	void Start () {
		var waypoints = GetComponentsInChildren<Transform>();
		for(int i = 1; i<waypoints.Length; i++) {
			Transform t = waypoints[i];
			Vector2 tempVec = new Vector2(t.position.x, t.position.y);
			wayPoints.Add(tempVec);
		}

		//Calculate Length of map
		
		for (int i = 0; i < wayPoints.Count-1; i++) {
			Vector2 former = wayPoints[i];
			Vector2 next = wayPoints[i+1];

			length += Mathf.Abs(Vector2.Distance(former,next));
		}
	}

	/**
	 * Get total length of the path
	 **/
	public float getLength () {
		return length;
		}
	/*
	 *  
	 */
    public Vector2 getPoint(float dist)
    {
		if (dist <= 0) {
			return wayPoints[0];
		}

		float walked = 0;
		float checkpointsWalked = 0;
		int i = 0;
		Vector2 former = new Vector2(0,0);
		Vector2 next = new Vector2(0,0);
		while (walked < dist) {
			if(i >= wayPoints.Count-1){ //We are at end
				return wayPoints[i];
			}
			checkpointsWalked = walked;
			former = wayPoints[i];
			next = wayPoints[i+1];
			walked += Mathf.Abs(Vector2.Distance(former,next));
			i++;
		}
		float normalizedDist = dist - checkpointsWalked;
		float wayPointLength = Vector2.Distance(former,next);

		float ratio = normalizedDist / wayPointLength;
		float x = former.x *(1 - ratio) + next.x * (ratio);
		float y = former.y *(1 - ratio) + next.y * (ratio);

		return new Vector2(x,y);
	}

	public Vector2 getFinalPoint()
	{
		return wayPoints [wayPoints.Count - 1];
	}

}
