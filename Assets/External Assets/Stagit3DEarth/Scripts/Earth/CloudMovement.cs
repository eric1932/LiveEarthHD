using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour
{
	public float rotationX;
	public float rotationY;
	public float rotationZ;
		
	void Update () {
		transform.Rotate(rotationX*Time.deltaTime,rotationY*Time.deltaTime, rotationZ*Time.deltaTime);
	}

}

