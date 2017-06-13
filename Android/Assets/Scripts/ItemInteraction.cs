using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour {


	private ShowText ShowTextScript;
	private GameObject TextControllerGO;

	private GuiBox GuiBoxScript;
	private GameObject GuiBoxGO;

	private float startTime = 0.0f;
	private float pressDuration = 1.0f;
	private float timePassed = 0.0f;
	private bool isPressed = false;
	
	private string targetName;

	// Use this for initialization
	void Start () {
		// displays a text in the inventory section
		TextControllerGO = GameObject.Find ("TextController");
		ShowTextScript = TextControllerGO.GetComponent<ShowText>();


		GuiBoxGO = GameObject.Find ("TextController");
		GuiBoxScript = GuiBoxGO.GetComponent<GuiBox> ();

		targetName = gameObject.transform.name;
	}


	// Update is called once per frame
	void Update () {
		if (isPressed) {
			timePassed = Time.time - startTime;
			print ("timePassed: " + timePassed);

			// zeit abgelaufen?
			if ((timePassed > pressDuration) ) {
				print ("Sekunde/n abgelaufen");

				ShowTextScript.setText (targetName + " long pressed " + Time.time);

				resetTimer ();
			}
		}
	}
		

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {

			if (startTime == 0.0F) {
				startTime = Time.time;
				print ("time set");
			}

			isPressed = true;

			print ("startTime: " + startTime + " pressDuration: " + pressDuration + " timePassed: " + timePassed);

			GuiBoxScript.showBox (true);

			ShowTextScript.setText (targetName + " angeklickt " + Time.time);



			// code for java connection
			AndroidJNIHelper.debug = true;
			AndroidJavaClass jc = new AndroidJavaClass("com.works.forme.BlankFragment");
			print ("## knoblauch");
			jc.CallStatic ("showAd");
		} 


		if (Input.GetMouseButtonUp (0)) {
			resetTimer ();
		}
	}
	

	void OnMouseExit() {
		resetTimer ();
	}


	void resetTimer() {
		isPressed = false;
		startTime = 0.0F;
		print ("resetTimer");
	}
}