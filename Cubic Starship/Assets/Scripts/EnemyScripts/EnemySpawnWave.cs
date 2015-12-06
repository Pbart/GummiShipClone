using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum WaveState
{
	WaveIdle,
	WaveSpawning,
	WaveFinished
}

//This class organizes the EnemySpawners to trigger at customizable times.
//The information for each Spawner is kept in a seperate class called SpawnNode.
public class EnemySpawnWave : MonoBehaviour {

	public EnemySpawnNode[] spawnersInOrder;
	public bool forceSpawnWave; //temp for testing and debugging
	
	private WaveState m_State;

	void Start ()
	{
		WaveInit();
	}
	
	void WaveInit()
	{
		m_State = WaveState.WaveIdle;
	}
	

	void Update () 
	{
		switch (m_State) {
		case WaveState.WaveSpawning:
			{
				//update time elapsed on each node
				for (int i = 0; i < spawnersInOrder.Length; i++) 
				{
					//set up reference so I don't have to type spawnersInOrder[i] everytime
					EnemySpawnNode n = spawnersInOrder [i];

					//update each node
					n.update (Time.deltaTime);

					//check 

				}

				break;
			}
		case WaveState.WaveFinished:
			{
				WaveInit ();
				break;
			}
		case WaveState.WaveIdle:
			{
				//temperary for testing/debugging
				if (forceSpawnWave) 
				{
					TriggerWave ();
					forceSpawnWave = false;
				}
				break;
			}
		}
	}




	public void TriggerWave()
	{
		m_State = WaveState.WaveSpawning;
		
		//link all the nodes together
		for (int i = 0; i < spawnersInOrder.Length - 1; i++) 
		{
			spawnersInOrder[i].nextNode = spawnersInOrder[i+1];
		}

		//trigger first node to start the wave
		spawnersInOrder[0].triggerNode();

	}

}
