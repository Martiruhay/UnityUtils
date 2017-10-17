using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour 
{
	public Transform target;

	public float smoothTime = 0.3F;

	private float vx = 0, vz = 0;

	void FixedUpdate ()
	{
		float newX = Mathf.SmoothDamp (transform.position.x, target.position.x, ref vx, smoothTime, Mathf.Infinity, Time.fixedDeltaTime);
		float newZ = Mathf.SmoothDamp (transform.position.z, target.position.z, ref vz, smoothTime/2.0f, Mathf.Infinity, Time.fixedDeltaTime);

		transform.position = new Vector3 (newX, transform.position.y, newZ);
	}
}
