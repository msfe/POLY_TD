using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroupMembers : MonoBehaviour {

    public List<EnemyBehaviour> enemies = new List<EnemyBehaviour>();

	void Start()
	{
		if(enemies == null)
			enemies = new List<EnemyBehaviour>();

	}
}
