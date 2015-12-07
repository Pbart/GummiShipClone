﻿using UnityEngine;
using System.Collections;

public enum TimeReference
{
	AtStartOfSpawn,
	AtEndOfSpawn
};



//Spawn node is used by the EnemySpawnWave. Its just data to hold what spawners activate and when.
[System.Serializable]
public class EnemySpawnNode
{
	public ISpawner spawner;							//The spawner to activate
	public float waitTimeFromPreviousSpawn;					//Time to wait for next spawn node to activate (seconds)
	public TimeReference timeReferenceFromPreviousSpawn;     //Either wait for timeTillNextEnemySpawn from the start or end

	[HideInInspector]
	public float timeStart;		//time to trigger the spawner
	
	[HideInInspector]
	public float timeEnd;		//time the spawner ends (used to find at what time the wave ends)
}