using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	// Main task: spawning the hazards in our game

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start() 
	{
		StartCoroutine (SpawnWaves ());
	}
	
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		// infinite loop of spawning waves
		while(true) 
		{
			// a wave of 10 hazards
			for (int i = 0; i < hazardCount; i++) 
			{
				Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation =  Quaternion.identity;
				// Instantiate hazard
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

}
