using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public Transform target;
	public float smoothing = 5f;

	// Distance between player and camera
	Vector3 offset;

	void Start() 
	{
		// setting our original offset
		offset = transform.position - target.position;
	}

	void FixedUpdate() 
	{
		// where we want the camera to be in relation to player at all times
		Vector3 targetCamPos = target.position + offset;
		// slowly moving towards that goal position
		// multiply by Time.deltaTime so we don't do it 50 times a second
		transform.position = Vector3.Lerp (transform.position, targetCamPos, smoothing * Time.deltaTime);
	}
}
