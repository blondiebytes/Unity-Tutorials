using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame --> 
	// called after everything else is updated
	// guaranteed that the player has already moved for that frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
