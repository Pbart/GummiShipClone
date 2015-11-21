using UnityEngine;
using System.Collections;

enum SpawnerState
{
	SpawnerIdle,
	SpawnerSpawning
}


public class EnemySpawner_Eric : MonoBehaviour {
	public SpawnNode spawn;

	private bool m_bSpawning;
	private SpawnerState m_State;



	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TriggerSpawn()
	{
		m_State = SpawnerState.SpawnerSpawning;

		//start spawning all 
	}
}
