using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {


	ShowText ShowTextScript;
	public GameObject TextControllerGO;

	GuiLabel GuiLabelScript;
	public GameObject GuiLabelGO;


	// Use this for initialization
	void Start () {
		TextControllerGO = GameObject.Find ("TextController");
		ShowTextScript = TextControllerGO.GetComponent<ShowText>();



		GuiLabelGO = GameObject.Find ("Main Camera");
		GuiLabelScript = GuiLabelGO.GetComponent<GuiLabel> ();
	}


	// Update is called once per frame
	void Update () {
		
	}
		

	void OnMouseOver() {
		if( Input.GetMouseButtonDown (0) ) {
			GuiLabelScript.showBox (true);
			ShowTextScript.setText("Box angeklickt " + Time.fixedTime);
		}
	}
}