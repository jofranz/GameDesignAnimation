using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidCommunicationController : MonoBehaviour {



	private ShowText ShowTextScript;
	private GameObject TextControllerGO;

	private GuiBox GuiBoxScript;
	private GameObject GuiBoxGO;

	private GuiLabel GuiLabelScript;
	private GameObject GuiLabelGO;



	public GameObject object1;
	//public SpriteRenderer spRenderer;
	private bool visible = true;


	void Start () { // Use this for initialization

		// displays a text in the inventory section
		TextControllerGO = GameObject.Find ("TextController");
		ShowTextScript = TextControllerGO.GetComponent<ShowText>();

		// displays a gui box which can be set visible or invisible
		GuiBoxGO = GameObject.Find ("TextController");
		GuiBoxScript = GuiBoxGO.GetComponent<GuiBox> ();

		// displays a debug console text line in the left upper corner
		GuiLabelGO = GameObject.Find ("TextController");
		GuiLabelScript = GuiLabelGO.GetComponent<GuiLabel> ();

		object1 = GameObject.Find ("coins");

		// code for java connection
		AndroidJNIHelper.debug = true;
		//AndroidJavaClass jc = new AndroidJavaClass("com.works.forme");

		AndroidJavaObject jo = new AndroidJavaObject ("com.works.forme.BlankFragment");
		jo.CallStatic ("showAd");
	}
	

	void Update () { // Update is called once per frame



	}


	// will be called from java android
	void javaMessageIn(string data) {

		toggleObject ();

		print ("ShowText :: javaMessageIn() :: " + data);
		ShowTextScript.setText ("from Java: " + data);
	}



	



	void toggleObject() {
		if(visible) {
			visible = false;
		} else {
			visible = true;
		}

		object1.SetActive (visible);
	}



}