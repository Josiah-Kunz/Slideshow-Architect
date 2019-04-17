using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions {

	/// <summary>
	/// Converts Unity vectors to Beamline Architect vectors.
	/// </summary>
	/// <returns>The BLA Vector3.</returns>
	/// <param name="v">The Unity Vector3.</param>
	public static Vector3 UnityToBLA(this Vector3 v){
		Vector3 ret = new Vector3(v[1],-v[2],v[0]);
		return ret;
	}

	/// <summary>
	/// Converts Beamline Architect vectors to Unity vectors.
	/// </summary>
	/// <returns>The Unity Vector3.</returns>
	/// <param name="v">The BLA Vector3.</param>
	public static Vector3 BLAToUnity(this Vector3 v){
		Vector3 ret = new Vector3(v[2],v[0],-v[1]);
		return ret;
	}

	/// <summary>
	/// Sets the x component.
	/// </summary>
	/// <param name="newX">The desired x component.</param>
	/// <returns> The new vector. </return>
	public static Vector3 SetX(this Vector3 v, float newX){
		v = new Vector3 (newX, v.y, v.z);
		return v;
	}

	/// <summary>
	/// Sets the y component.
	/// </summary>
	/// <param name="newY">The desired y component.</param>
	/// <returns> The new vector. </return>
	public static Vector3 SetY(this Vector3 v, float newY){
		v = new Vector3 (v.x, newY, v.z);
		return v;
	}

	/// <summary>
	/// Sets the z component.
	/// </summary>
	/// <param name="newZ">The desired z component.</param>
	/// <returns> The new vector. </return>
	public static Vector3 SetZ(this Vector3 v, float newZ){
		v = new Vector3 (v.x, v.y, newZ);
		return v;
	}

}
