using UnityEngine;
using System.Collections;

public enum TimeReference
{
	AtStartOfNode,
	AtEndOfNode
};

public enum NodeState
{
	NodeIdle,
	NodeWaiting,
	NodeSpawning,
	NodeFinished
};


//Spawn node is used by the EnemySpawnWave. It encompasses the timing of when spawners activate and how they chain together.
[System.Serializable]
public class EnemySpawnNode
{
	public ISpawner spawner;							//The spawner to activate
	public float waitTimeForSpawn;						//The initial time to wait before activating the current spawner
	public float waitTimeForNextSpawn;					//Time to wait for next spawn node to activate (seconds)
	public TimeReference timeReferenceForNextSpawn;     //Either wait for timeTillNextEnemySpawn from the start or end

	[HideInInspector]
	public EnemySpawnNode nextNode;

	private float nodeTimeElapsed;
	private float nextNodeTimeElapsed;
	private NodeState currentNodeState;		//used to keep state of when to start the current spawner
	private NodeState nextNodeState;		//used to keep state of when to start the NEXT spawner

	public void update(float dt)
	{
		//update state of current node
		switch(currentNodeState)
		{
		case NodeState.NodeWaiting:
		{
			if(nodeTimeElapsed >= waitTimeForSpawn)
			{
				currentNodeState = NodeState.NodeSpawning;
				spawner.TriggerSpawn();
			}
			nodeTimeElapsed += dt;

			break;
		}
		case NodeState.NodeSpawning:
		{
			if(spawner.isFinished())
			{
				currentNodeState = NodeState.NodeFinished;
				if(timeReferenceForNextSpawn == TimeReference.AtEndOfNode)
				{
					if(waitTimeForNextSpawn >= 0.0f)
					{
						nextNodeState = NodeState.NodeWaiting;
					}
					else
					{
						nextNodeState = NodeState.NodeSpawning;
					}
				}
			}
			break;
		}
		case NodeState.NodeFinished:
		{

			break;
		}
		};

		//update nextNodeState to see when to activate next node
		switch(nextNodeState)
		{
		case NodeState.NodeIdle:
		{
			
			break;
		}
		case NodeState.NodeWaiting:
		{
			if(nextNodeTimeElapsed >= waitTimeForNextSpawn)
			{
				nextNodeState = NodeState.NodeFinished;
				nextNode.triggerNode();
			}
			nodeTimeElapsed += dt;
			break;
		}
		case NodeState.NodeSpawning:
		{
			
			break;
		}
		case NodeState.NodeFinished:
		{
			
			break;
		}
		};

	}

	public void triggerNode()
	{
		if(currentNodeState == NodeState.NodeIdle)
		{
			//figure out state for current node
			if(waitTimeForSpawn >= 0.0f)
			{
				currentNodeState = NodeState.NodeWaiting;
			}
			else
			{
				currentNodeState = NodeState.NodeSpawning;
			}

			//figure out state for triggering next node
			if(timeReferenceForNextSpawn == TimeReference.AtStartOfNode)
			{
				if(waitTimeForNextSpawn >= 0.0f)
				{
					nextNodeState = NodeState.NodeWaiting;
				}
				else
				{
					nextNodeState = NodeState.NodeSpawning;
				}
			}
		}
	}




}
