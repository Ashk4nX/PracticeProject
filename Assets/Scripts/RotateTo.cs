using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour {

	public float RotSpeed;

	private Transform ThisTransform = null;

	public Transform Target = null;

	// Use this for initialization
	void Awake () {

		ThisTransform = this.GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

		// Function for rotating an object in time
		//ThisTransform.rotation *= Quaternion.AngleAxis(RotSpeed  * Time.deltaTime, Vector3.forward);

		// Function for Looking at a Target and Following it.
		Quaternion RotDest = Quaternion.LookRotation(Target.transform.position - this.transform.position, Vector3.up);
		ThisTransform.rotation = Quaternion.RotateTowards(ThisTransform.rotation, RotDest, RotSpeed * Time.deltaTime);


		
	}
}
