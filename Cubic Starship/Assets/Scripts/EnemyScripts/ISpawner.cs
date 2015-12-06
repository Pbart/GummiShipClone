using UnityEngine;
using System.Collections;

public enum SpawnerState
{
	SpawnerIdle,
	SpawnerSpawning,
	SpawnerFinished
}

public abstract class ISpawner : MonoBehaviour 
{
	abstract public void TriggerSpawn();

	protected SpawnerState m_State;

	public bool isFinished() {
		return m_State == SpawnerState.SpawnerFinished;
	}

}
