using UnityEngine;
using System.Collections;

public enum TimeReference
{
	AtStartOfNode,
	AtEndOfNode
};

//Spawn node is used by the EnemySpawningTree. It encompasses the timing of when spawners activate and how they chain together.
[System.Serializable]
public class EnemySpawnNode
{
	public EnemySpawner_Eric spawner;				//The spawner to activate
	public float spawnerTimeOffset;					//The initial time to wait before activating the current spawner
	public EnemySpawnNode nextEnemySpawn;			//The next spawn node to activate after/during the current spawner
	public float timeUntilNext;						//Time to wait for next spawn node to activate
	public TimeReference nextSpawnTimeReference;     //Either wait for timeTillNextEnemySpawn from the start or end
}
