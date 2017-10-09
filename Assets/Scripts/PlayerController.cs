using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public float MoveSpeed;
	public float RotSpeed;

	private Transform ThisTransform = null;
	private CharacterController ThisController = null;

	// Use this for initialization
	void Awake () {

		ThisTransform = this.GetComponent<Transform>();
		ThisController = this.GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {

		float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis("Vertical");

		ThisTransform.rotation *= Quaternion.Euler(0f, Horz * RotSpeed * Time.deltaTime, 0f);

		//ThisTransform.position += ThisTransform.forward * Vert * MoveSpeed * Time.deltaTime;
	
		ThisController.SimpleMove(Vector3.forward * Vert * MoveSpeed);
		
	}
}
