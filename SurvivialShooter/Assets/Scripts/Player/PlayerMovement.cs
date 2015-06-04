using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f; // just saying this is a floating point variable

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	// getting the quad
	int floorMask;
	// length of the ray we cast from the camera
	float camRayLength = 100f;

	void Awake() 
	{
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	// since we are using a character with physics
	void FixedUpdate() 
	{
		// 0 or 1 --> snaps to full speed
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		Move (h, v);
		Turning ();
		Animating (h, v);
	}

	void Move (float h, float v) 
	{
		movement.Set (h, 0f, v);
		// so our character always moving the same speed
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	}

	void Turning() 
	{
		// takes a point on the screen and casts a ray further into the scene
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
	
		RaycastHit floorHit;

		// if the ray has hit something...
		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) 
		{
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;
			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v) 
	{
		// if h and v are nonzero, then we are walking
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);


	}

}
