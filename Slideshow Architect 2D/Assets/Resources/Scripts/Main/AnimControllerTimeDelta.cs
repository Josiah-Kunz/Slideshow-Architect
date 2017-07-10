using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimControllerTimeDelta : MonoBehaviour {

	public List<int> times = new List<int>();					// When to trigger animations
	public List<string> animations = new List<string>();		// Animations that are triggered

	Animator animator;											// Our animator
	string direction="";										// Direction of motion
	int index=0;												// The current index
	float speed=0.7f;											// Motion speed in units/sec
	float time0=-10000f;												// The previous time

	void Start () {
		animator = GetComponent<Animator> ();
	}

	void Update(){
		if (direction == "down") {
			transform.position -= Vector3.up * speed * Time.deltaTime;
		} else if (direction == "up") {
			transform.position += Vector3.up * speed * Time.deltaTime;
		} else if (direction=="left"){
			transform.position -= Vector3.right * speed * Time.deltaTime;
		} else if (direction=="right"){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
	}

	void FixedUpdate () {
		if (Globals.timeCount - time0 >= times [index]) {
			time0 = Globals.timeCount;
			animator.Play (animations [index]);
			direction = (animations [index]).Split ('_') [1];
			index += 1;
			if (index >= times.Count)
				index = 0;
		}
	}

}
