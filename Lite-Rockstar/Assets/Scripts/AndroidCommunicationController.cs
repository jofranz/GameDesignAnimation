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

	public GameObject object0;
	bool visible0 = false;

	public GameObject object1;
	bool visible1 = false;

	string aFullName = "";


	void Start () { // Use this for initialization

		// displays a text in the inventory section
		TextControllerGO = GameObject.Find ("TextController");
		ShowTextScript = TextControllerGO.GetComponent<ShowText>();


		GuiBoxScript = TextControllerGO.GetComponent<GuiBox> ();



		// displays a gui box which can be set visible or invisible
		GuiBoxGO = GameObject.Find ("TextController");
		GuiBoxScript = GuiBoxGO.GetComponent<GuiBox> ();

		// displays a debug console text line in the left upper corner
		GuiLabelGO = GameObject.Find ("TextController");
		GuiLabelScript = GuiLabelGO.GetComponent<GuiLabel> ();


		object0 = GameObject.Find ("BierflascheVoll");
		object1 = GameObject.Find ("coins");

		object0.SetActive (false);
		object1.SetActive (false);


		print("AndroidCommunicationController class started");



		// SendFullNameToUnity ("##TestFullName");


		// code for java connection
		AndroidJNIHelper.debug = true;
		//AndroidJavaClass jc = new AndroidJavaClass("com.works.forme");

		AndroidJavaObject jo = new AndroidJavaObject ("com.works.forme.BlankFragment");
		jo.CallStatic ("showAd");
	}
	

	void Update () { // Update is called once per frame

	}


	// will be called from java android
	void JavaMessageIn(string aString) {

		// bottle coin passwort cloths
		switch(aString) {
		case "01":

			if (visible0) {
				visible0 = false;
			} else {
				visible0 = true;
			}

			print ("### visible0" + visible0);

			object0.SetActive (visible0);

			print ("#### item0 bottle");
			break;
		case "11":
			

			if(visible1) {
				visible1 = false;
			} else {
				visible1 = true;
			}

			print ("### visible1" + visible1);

			object1.SetActive (visible1);

			print ("#### item1 coin");
			break;
		default:
			print ("#### default case");
			break;
		}


		ShowTextScript.setText ("### buy item via JavaMessageIn() :: " + aString);
		print ("### print:: JavaMessageIn() :: " + aString);
	}


	void SendFullNameToUnity(string aFullName) {

		ShowTextScript.setText ("### from Java: " + aFullName);


		GuiBoxScript.showBox (true);
		GuiBoxScript.setTextBox ("Hallo, dein Name ist\n" + aFullName + "\nund du bist gerade ins Spiel gestartet.");

		print ("### name via SendFullNameToUnity() :: " + aFullName);




	}
}