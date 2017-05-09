using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ItemTrigger : MonoBehaviour {


	public string text = "method call - something happend";
	public bool showText = false;

	public Text showTextLabel;
	// Use this for initialization
	void Start () {
		showTextLabel.text = "emptyyy";
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D target) {
		print ("enter box " + Time.fixedTime);

		showTextLabel.text = "erschlagen";

		showTextNow ();
	}

//	void OnTriggerExit2D(Collider2D target) {
//		print ("exit box " + Time.fixedTime);
//	}


	void showTextNow() {
		//showText = true;
	}




	void OnGUI(){
		if (showText) {
			GUI.Box (new Rect (0, Screen.height/2, Screen.width, Screen.height), text + "\nneue Zeile");
			if (Input.GetMouseButtonDown (0)) {
				showText = false; 
			}
		}
	}


}