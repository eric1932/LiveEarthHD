using UnityEngine;
using System.Collections;
using System;

public class GeoLocator {

	public float startDegreesx = -180f;
	public float startDegreesy = -180f;

	public Vector2 CartesianToPolar(Vector3 point)
	{
		Vector2 polar = new Vector2();

		//calc longitude
		polar.y = Mathf.Atan2(point.x,point.z);

		//this is easier to write and read than sqrt(pow(x,2), pow(y,2))!
		float xzLen;
		xzLen = new Vector2(point.x,point.z).magnitude; 
		//atan2 does the magic
		polar.x = Mathf.Atan2(-point.y,xzLen);

		//convert to deg
		polar *= Mathf.Rad2Deg;

		return polar;
	}


	public Vector3 PolarToCartesian(Vector2 polar)
	{
		Vector3 origin = new Vector3(0,0,1);
		//build a quaternion using euler angles for lat,lon
		Quaternion rotation = Quaternion.Euler(polar.x,polar.y,0);
		//transform our reference vector by the rotation. Easy-peasy!
		Vector3 point = rotation * origin;
		return point;
	}

	public Vector3 getVectorFromLatLong(float myradius, double mylatitude, double mylongitude) {
		mylatitude = Mathf.PI  * mylatitude / -180f;
		//mylongitude = Mathf.PI  * mylongitude / 180;
		mylongitude = Mathf.PI  * mylongitude / -180f;
		float degrees90 = 1.570795765134f;
		mylatitude -= (degrees90 * 1); // subtract 90 degrees (in radians)
		mylongitude -= (degrees90 * 1); // subtract 90 degrees (in radians)

		double xPos = (myradius) * ((Math.Sin((mylatitude))) * (Math.Cos((mylongitude))));
		double zPos = (myradius) * (Math.Sin((mylatitude)) * Math.Sin((mylongitude)));
		double yPos = (myradius) * Math.Cos((mylatitude)); 

		// move marker to position
		return new Vector3(System.Convert.ToSingle(xPos),System.Convert.ToSingle(yPos),System.Convert.ToSingle(zPos));
	}


	public Vector3 convertSphericalToCartesian(float myradius, float mylatitude, float mylongitude)
	{
		float lat = DegtoRad(mylatitude);
		float lon = DegtoRad(mylongitude);

		float degrees = 1.570795765134f;

		mylatitude -= (degrees * 2); // subtract 90 degrees (in radians)

		var x = myradius * Mathf.Cos(lat)*Mathf.Cos(lon);
		var y = myradius * Mathf.Cos(lat)*Mathf.Sin(lon);
		var z = myradius * Mathf.Sin(lat);
		return new Vector3(x,y,z);
	}

	private float DegtoRad(float x){
		return x*Mathf.PI/180;
	}

	private float RadtoDeg(float x){
		return x*180/Mathf.PI;
	}
}
