using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	// what the enemy is moving toward
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    NavMeshAgent nav;


    void Awake ()
    {
		// where the player is
        player = GameObject.FindGameObjectWithTag ("Player").transform; 
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <NavMeshAgent> ();
    }

	// not fixed update because not keeping in time with physics
    void Update ()
    {
		// only set the dude's destination if both the player and enemy are alive
        if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
       	{
		// This is where I want to go. Towards the player.
            nav.SetDestination (player.position);
        }
        else
        {
			// if one is dead, we don't want to go anywhere, so disable the nav mesh
            nav.enabled = false;
        }
    }
}
