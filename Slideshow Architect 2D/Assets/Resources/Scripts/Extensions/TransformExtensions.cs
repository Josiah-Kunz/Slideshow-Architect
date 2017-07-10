using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions {

	/// <summary>
	/// Recursively finds the child with the given name.
	/// </summary>
	/// <returns>The child.</returns>
	/// <param name="name">Name of the desired child.</param>
	public static Transform FindChildDeep(this Transform trans, string name){

		foreach (Transform child in trans) {
			if (child.name == name)
				return child;
			var result = child.FindChildDeep (name);
			if (result != null)
				return result;
		}
		return null;
	}

	/// <summary>
	/// Points this face towards the camera.
	/// </summary>
	/// <param name="camera">The camera GameObject.</param>
	public static void LookAtCameraFace(this Transform trans, GameObject camera){
		trans.LookAt (trans.position + camera.transform.rotation * Vector3.forward,
			camera.transform.rotation * Vector3.up);
	}

	/// <summary>
	/// Points this face towards the camera.
	/// </summary>
	public static void LookAtCameraFace(this Transform trans){
		trans.LookAtCameraFace(Camera.main.gameObject);
	}

	/// <summary>
	/// Points this face towards the camera.
	/// </summary>
	/// <param name="camera">The camera.</param>
	public static void LookAtCameraFace(this Transform trans, Camera camera){
		trans.LookAtCameraFace (camera.gameObject);
	}

	/// <summary>
	/// Sets the x position.
	/// </summary>
	/// <param name="newX">The desired x position.</param>
	public static void SetXPosition(this Transform trans, float newX){
		trans.position = trans.position.SetX (newX);
	}

	/// <summary>
	/// Sets the y position.
	/// </summary>
	/// <param name="newY">The desired y position.</param>
	public static void SetYPosition(this Transform trans, float newY){
		trans.position = trans.position.SetY (newY);
	}

	/// <summary>
	/// Sets the z position.
	/// </summary>
	/// <param name="newZ">The desired z position.</param>
	public static void SetZPosition(this Transform trans, float newZ){
		trans.position = trans.position.SetZ (newZ);
	}

	/// <summary>
	/// Sets the x Euler angle.
	/// </summary>
	/// <param name="newX">The desired x Euler angle.</param>
	public static void SetXAngle(this Transform trans, float newX){
		trans.eulerAngles = trans.eulerAngles.SetX (newX);
	}

	/// <summary>
	/// Sets the y Euler angle.
	/// </summary>
	/// <param name="newY">The desired y Euler angle.</param>
	public static void SetYAngle(this Transform trans, float newY){
		trans.eulerAngles = trans.eulerAngles.SetY (newY);
	}

	/// <summary>
	/// Sets the z Euler angle.
	/// </summary>
	/// <param name="newZ">The desired z Euler angle.</param>
	public static void SetZAngle(this Transform trans, float newZ){
		trans.eulerAngles = trans.eulerAngles.SetZ (newZ);
	}

}
