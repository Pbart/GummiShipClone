using UnityEngine;
using System.Collections;

public enum SpawnTiming
{
	AtStartOfNodeReference,
	AtEndOfNodeReference
};

//Spawn node is used by the EnemySpawningTree. It encompasses the timing of when spawners activate and how they chain together.
[System.Serializable]
public class EnemySpawnNode
{
	public GameObject spawn;		//The enemy to spawn
	public GameObject spawnPath;    //The path each enemy will follow when spawned.
									//10-21-15 Eric: For right now, they will only follow a BezierSpline script. The BezierSpline script must 
									// be attached to the game object. If there is no BezierSpline script, the enemy will spawn at the transform's
									// origin only and sit there.

	public uint spawnAmount;		//Total amount of enemies spawned
	public float spawnRate;         //Time between each enemy spawned
//	public float timeOffset;        //The time to wait before spawning the first enemy
	public GameObject spawnParent;  //The parent to attach the enemies too.
//	public SpawnTiming nodeSpawnTiming;
//	public SpawnNode nodeSpawnTimingReference;
}
