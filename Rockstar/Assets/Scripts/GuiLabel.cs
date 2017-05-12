using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiLabel : MonoBehaviour {

	private bool showBoxStatus = false;

	// Use this for initialization
	void Start () {
		print ("guilabel start");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void showBox(bool state) {
		showBoxStatus = state;
	}

	void OnGUI(){


		GUI.Label( new Rect(1,1,80,20), "textlabel!!! \n nächste zeile1" );

	
		
		if (showBoxStatus) {
			//rect     x, y, width, height
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), "fancy gui \n nächste zeile2");

			// on click disable box
			if (Input.GetMouseButtonDown (0)) {
				showBox (false);
			}

		}
	}

}
