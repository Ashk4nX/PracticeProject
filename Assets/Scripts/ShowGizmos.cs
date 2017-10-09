using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGizmos : MonoBehaviour {

	public bool ShowGizmo;

	[Range(0f, 100f)]
	public float Range = 10f;

	public string Icon = string.Empty;


	void OnDrawGizmos ()
	{

		if (ShowGizmo == false)
		return;

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(this.transform.position, Range);

		Gizmos.color = Color.blue;
		Gizmos.DrawLine(this.transform.position, this.transform.position + transform.forward * Range);

		Gizmos.DrawIcon(this.transform.position, Icon);

	}

}
