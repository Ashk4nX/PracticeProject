using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Orbiter : MonoBehaviour {

	public Transform Pivot = null;

	private Quaternion RotDest = Quaternion.identity;
	private Transform ThisTransform = null;

	public float PivotDistance = 5f;
	private float RotX = 0f;
	private float RotY = 0f;
	public float RotSpeed = 10f;

	// Use this for initialization
	void Awake () {

		ThisTransform = this.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

		float Horz = CrossPlatformInputManager.GetAxis ("Horizontal");
		float Vert = CrossPlatformInputManager.GetAxis ("Vertical");

		RotY += Horz * Time.deltaTime * RotSpeed;
		RotX += Vert * Time.deltaTime * RotSpeed;

		Quaternion Yrot = Quaternion.Euler(0f, RotY, 0f);
		RotDest = Yrot * Quaternion.Euler (RotX, 0f, 0f);

		ThisTransform.rotation = RotDest;

		ThisTransform.position =  Pivot.transform.position + ThisTransform.rotation * Vector3.forward * -PivotDistance;

		
	}
}
