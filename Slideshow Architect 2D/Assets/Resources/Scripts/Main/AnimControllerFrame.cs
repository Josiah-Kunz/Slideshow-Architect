using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerFrame : MonoBehaviour {

	public List<int> frameCounts = new List<int>();				// Frame count that trigger animations
	public List<string> animations = new List<string>();		// Animations that are triggered

	Animator animator;											// Our animator
	string direction="";										// Direction of motion
	float speed=0.7f;											// Motion speed in units/sec

	void Start () {
		animator = GetComponent<Animator> ();
	}

	void Update(){
		if (direction=="down"){
			transform.position -= Vector3.up * speed * Time.deltaTime;
		}
	}

	void FixedUpdate () {
		for (int i = 0; i < frameCounts.Count; i++) {
			if (Globals.slide == frameCounts [i]) {
				animator.Play (animations [i]);
				direction = (animations [i]).Split ('_') [1];
			}
		}
	}

}
