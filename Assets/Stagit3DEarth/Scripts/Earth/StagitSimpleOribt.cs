using UnityEngine;
using System.Collections;

public class StagitSimpleOribt : MonoBehaviour
{


	public Transform center;
	public Vector3 axis = Vector3.forward;

	public Vector3 desiredPosition;
	public float radius = 2.0f;
	public float radiusSpeed = 0.5f;
	public float rotationSpeed = 80.0f;

	void Start () {

		transform.position = (transform.position - center.position).normalized * radius + center.position;
		radius = 2.0f;
	}

	void FixedUpdate () {
		transform.RotateAround (center.position, axis, rotationSpeed * Time.deltaTime);

		desiredPosition = (transform.position - center.position).normalized * radius + center.position;
	}
}

