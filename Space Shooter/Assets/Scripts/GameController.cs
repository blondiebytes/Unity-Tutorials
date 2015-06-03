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

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;

	void Start() 
	{
		gameOver = false;
		restart = false;
		score = 0;
		restartText.text = "";
		gameOverText.text = "";
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update() 
	{
		if (restart) { 
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
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

			if (gameOver) 
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore(int increment) 
	{
		score += increment;
		UpdateScore ();
	}

	void UpdateScore() 
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver() 
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

}
