using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiLabel : MonoBehaviour {

	private bool showBoxStatus = false;
	private string textLabelContent = "change this via setTextLabel() \nnew line? \n ";
	private string textBoxContent = "change this via setTextBox() \nnew line? \n ";
 
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


	public void setTextLabel(string str) {
		textLabelContent = str;
	}


	public void setTextBox(string str) {
		textBoxContent = str;
	}


	void OnGUI(){

		//rect     x, y, width, height
		GUI.Label( new Rect(1,1,Screen.width,Screen.height), textLabelContent + Time.fixedTime );

	
		
		if (showBoxStatus) {
			//rect     x, y, width, height
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, Screen.width / 2, Screen.height / 2), textBoxContent + Time.fixedTime);

			// on click disable box
			if (Input.GetMouseButtonDown (0)) {
				showBox (false);
			}

		}
	}

}
