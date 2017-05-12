using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour {


	private ShowText ShowTextScript;
	private GameObject TextControllerGO;

	private GuiLabel GuiLabelScript;
	private GameObject GuiLabelGO;


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

		if (Input.GetMouseButtonDown (0) ) {
			GuiLabelScript.showBox (true);
			//clickedBefore = true;
			string targetName = gameObject.transform.name;
			ShowTextScript.setText (targetName + " angeklickt " + Time.fixedTime);
		} 

//		if(Input.GetMouseButtonDown (0) && clickedBefore){
//			GuiLabelScript.showBox (false);
//			clickedBefore = true;
//		}
	}
}