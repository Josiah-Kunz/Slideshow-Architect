using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Write{

	public static void Log(params object[] objects){
		Debug.Log ("======");
		foreach(object obj in objects){
			Debug.Log (obj);
		}
	}

}
