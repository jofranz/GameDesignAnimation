using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidCommunicationController : MonoBehaviour {



	ShowText ShowTextScript;
	public GameObject TextControllerGO;




	void Start () { // Use this for initialization

		// sets up TextController Game Object
		TextControllerGO = GameObject.Find ("TextController");
		ShowTextScript = TextControllerGO.GetComponent<ShowText>();

		// code for java connection
		AndroidJNIHelper.debug = true;
		AndroidJavaClass jc = new AndroidJavaClass("com.works.forme");
		jc.CallStatic ("recMessage");
	}
	

	void Update () { // Update is called once per frame
		
	}


	// will be called from java android
	void javaMessageIn(string data) {
		print ("ShowText :: javaMessageIn() :: " + data);
		ShowTextScript.setText ("from Java: " + data);
	}
}