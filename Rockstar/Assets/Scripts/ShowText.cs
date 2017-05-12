using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour {

	public Text textLabel;


	// Use this for initialization
	void Start () {
		textLabel.text = "default-leer";

		setText ("Starttext via code via setText()");

	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void setText(string aText) {
		textLabel.text = aText;
	}
}