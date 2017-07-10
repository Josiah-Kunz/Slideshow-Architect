using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerSlide : MonoBehaviour {

	public List<int> slideNumbers = new List<int>();			// Slides that trigger animations
	public List<string> animations = new List<string>();		// Animations that are triggered

	Animator animator;											// Our animator
	string direction="";										// Direction of motion
	float speed=0.7f;												// Motion speed in units/sec

	void Start () {
		animator = GetComponent<Animator> ();
	}

	void Update(){
		if (direction=="down"){
			transform.position -= Vector3.up * speed * Time.deltaTime;
		}
	}

	void FixedUpdate () {
		for (int i = 0; i < slideNumbers.Count; i++) {
			if (Globals.slide == slideNumbers [i]) {
				animator.Play (animations [i]);
				direction = (animations [i]).Split ('_') [1];
			}
		}
	}

}
