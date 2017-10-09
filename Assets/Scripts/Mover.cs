using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	public float Speed;

	private Transform ThisTransform;

	// Use this for initialization
	void Awake () {

		ThisTransform = this.GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {

		ThisTransform.position += ThisTransform.forward * Speed * Time.deltaTime;
		
	}
}
