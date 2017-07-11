using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickListener : MonoBehaviour {

	GameObject currentSlide;
	GameObject slidesParent;

	void Start () {

		slidesParent = GameObject.Find ("Slides");
		
		// Hide all but the title slide
		foreach(Transform trans in slidesParent.transform){
			if (trans.gameObject.name == "Slide") {
				currentSlide = trans.gameObject;
				continue;
			}
			trans.gameObject.SetActive (false);
		}
	}

	void Update () {

		// Update Globals
		Globals.frameCount += 1;
		Globals.timeCount += Time.deltaTime;

		// Arrow right
		if (Input.GetKeyDown (KeyCode.RightArrow)){
			ChangeSlide ();

		// Arrow left
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)){
			ChangeSlide (-1);
		}
			
	}

	void ChangeSlide(int amount=1){
		currentSlide.SetActive (false);
		Globals.slide += amount;
		string slideName = "Slide (" + Globals.slide.ToString () + ")";
		if (Globals.slide == 0)
			slideName = "Slide";
		currentSlide = slidesParent.transform.FindChild (slideName).gameObject;
		currentSlide.SetActive (true);
	}

}
