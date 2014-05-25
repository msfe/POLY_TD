using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {

    public float Interval = 7f;
    public Waypoints _waypoints;

	private int ENEMIES_TO_SPAWN = 200;

    public Transform _singleEnemyPrefab;
    public Transform _simpleGroupPrefab;

    float _accumulator;
	int enemyCounter;
    Vector2 _spawn;

	void Start () 
    {
        _accumulator = Interval * 4f / 5f;
        _spawn = _waypoints.getPoint(0);
	}
	
	void Update() 
    {	
		if (allEnemiesSpawned ()) {
			Application.LoadLevel(0); //TODO handle winning correct
		}
        _accumulator += Time.deltaTime;
        if (_accumulator > Interval)
        {
            _accumulator -= Interval;

            SpawnSingle();
			if(Interval > 0.15){
				Interval = Interval * 19f/20f;
			}
        }
	}

    void SpawnSingle()
    {	
		enemyCounter++;
		Transform enemyT = (Transform)Instantiate(_singleEnemyPrefab, _spawn - new Vector2(0,-0.3f), Quaternion.identity);
        Transform groupT = (Transform)Instantiate(_simpleGroupPrefab, _spawn, Quaternion.identity);

        SingleUnitGroup group = groupT.GetComponent<SingleUnitGroup>();
		EnemyBehaviour enemy = enemyT.GetComponent<EnemyBehaviour>();

		group._waypoints = _waypoints;
		group.GetComponent<GroupMembers> ().enemies = new System.Collections.Generic.List<EnemyBehaviour> ();
		group.GetComponent<GroupMembers>().enemies.Add(enemy);
    }

	public bool allEnemiesSpawned(){
		return enemyCounter >= ENEMIES_TO_SPAWN;
	}
}
