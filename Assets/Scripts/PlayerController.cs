using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float MoveSpeed;
	public float RotSpeed;
	public float JumpForce = 5f;
	public float FallForce = 5f;
	public float GroundedDist = 2.5f;
	public bool IsGrounded = true;
	public LayerMask GroundLayer;

	private Vector3 Velocity = Vector3.zero;
	private Transform ThisTransform = null;
	private CharacterController ThisController = null;

	// Use this for initialization
	void Awake () {

		ThisTransform = this.GetComponent<Transform>();
		ThisController = this.GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		float Horz = CrossPlatformInputManager.GetAxis ("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis ("Vertical");
		Velocity.z = Vert * MoveSpeed;

		ThisController.Move (ThisTransform.TransformDirection (Velocity) * Time.deltaTime);
		ThisTransform.rotation *= Quaternion.Euler (0f, Horz * RotSpeed * Time.deltaTime, 0f);

		//ThisTransform.position += ThisTransform.forward * Vert * MoveSpeed * Time.deltaTime;
		//ThisController.SimpleMove(ThisTransform.forward * Vert * MoveSpeed);

		//Are we Grounded?
		if (DistanceToGround () < GroundedDist) {

			IsGrounded = true;

		} else {

			IsGrounded = false;

		}

		//Jumping
		if (CrossPlatformInputManager.GetAxis ("Jump") != 0 && IsGrounded == true) {

			Velocity.y = JumpForce;

		}

		//Apply Gravity
		Velocity.y += Physics.gravity.y * FallForce * Time.deltaTime;


		
	}

	public float DistanceToGround ()
	{
		RaycastHit hit;
		float distanceToGround = 0;
		if (Physics.Raycast (ThisTransform.position, -Vector3.up , out hit, Mathf.Infinity, GroundLayer)) {

			distanceToGround = hit.distance;
			print (distanceToGround);
		}

		return distanceToGround;

	}
}
