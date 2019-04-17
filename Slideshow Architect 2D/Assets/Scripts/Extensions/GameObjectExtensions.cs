using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions{

	public static float GetWidth(this GameObject go){
		return go.GetComponent<RectTransform> ().GetWidth ();
	}

	public static void SetWidth(this GameObject go, float value){
		go.GetComponent<RectTransform> ().SetWidth (value);
	}

	public static float GetHeight(this GameObject go){
		return go.GetComponent<RectTransform> ().GetHeight ();
	}

	public static void SetHeight(this GameObject go, float value){
		go.GetComponent<RectTransform> ().SetHeight (value);
	}

	public static RectTransform rectTransform(this GameObject go){
		return go.GetComponent<RectTransform> ();
	}

}
