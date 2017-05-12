using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour {

	public Text textLabel;

	public ShowText() {

	}

	// Use this for initialization
	void Start () {
		textLabel.text = "default-leer";

		print ("ShowText :: Start()");
		setText ("blaaaaaa via setText()");

		// code for java connection
		AndroidJNIHelper.debug = true;
		AndroidJavaClass jc = new AndroidJavaClass("com.works.forme");
		jc.CallStatic ("recMessage");
	}
	
	// Update is called once per frame
	void Update () {

	}


	public void setText(string aText) {
		textLabel.text = aText;
	}


	// will be called from java android
	void javaMessageIn(string data) {
		print ("ShowText :: javaMessageIn() :: " + data);
		setText ("from Java: " + data);
	}

}