using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	void Update(){
		Globals.frameCount += 1;
		Globals.timeCount += Time.deltaTime;
	}

}
