using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {


	ShowText ShowTextScript;
	public GameObject TextController;


	// Use this for initialization
	void Start () {
		TextController = GameObject.Find ("TextController");
		ShowTextScript = TextController.GetComponent<ShowText>();
	}


	// Update is called once per frame
	void Update () {
		
	}
		

	void OnMouseOver() {
		if( Input.GetMouseButtonDown (0) ) {
			ShowTextScript.setText("Box angeklickt " + Time.fixedTime);
		}
	}
}