using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidCommunicationController : MonoBehaviour {


	// labels
	private ShowText mShowTextScript;
	private GameObject mTextControllerGO;

	private GuiBox mGuiBoxScript;
	private GameObject mGuiBoxGO;

	private GuiLabel mGuiLabelScript;
	private GameObject mGuiLabelGO;


	// items
	private GameObject mObject0;
	private bool mVisible0 = false;

	private GameObject mObject1;
	private bool mVisible1 = false;

	private GameObject mObject2;
	private bool mVisible2 = false;

	private GameObject mObject3;
	private bool mVisible3 = false;


	//name
	private string mFullName = "";


	void Start () { // Use this for initialization

		// displays a text in the inventory section
		mTextControllerGO = GameObject.Find ("TextController");
		mShowTextScript = mTextControllerGO.GetComponent<ShowText>();

		mGuiBoxScript = mTextControllerGO.GetComponent<GuiBox> ();

		// displays a gui box which can be set visible or invisible
		mGuiBoxGO = GameObject.Find ("TextController");
		mGuiBoxScript = mGuiBoxGO.GetComponent<GuiBox> ();

		// displays a debug console text line in the left upper corner
		mGuiLabelGO = GameObject.Find ("TextController");
		mGuiLabelScript = mGuiLabelGO.GetComponent<GuiLabel> ();


		mObject0 = GameObject.Find ("BierflascheVoll");
		mObject0.SetActive (false);


		mObject1 = GameObject.Find ("coins");
		mObject1.SetActive (false);


		mObject2 = GameObject.Find ("Ausweis");
		mObject2.SetActive (false);


		mObject3 = GameObject.Find ("Handschuhe");
		mObject3.SetActive (false);

		print("AndroidCommunicationController class started");



		// SendFullNameToUnity ("##TestFullName");


		// code for java connection
		//AndroidJNIHelper.debug = true;
		//AndroidJavaClass jc = new AndroidJavaClass("com.works.forme");

		//AndroidJavaObject jo = new AndroidJavaObject ("com.works.forme.BlankFragment");
		//jo.CallStatic ("showAd");
	}
	

	void Update () { // Update is called once per frame

	}


	// will be called from java android
	public void JavaMessageIn(string aString) {

		// 0bottle 1coin 2passwort 3cloths
		switch(aString) {
		case "01":

			print ("### visible0" + mVisible0);

				mObject0.SetActive (true);
			break;

		case "11":

			print ("### visible1" + mVisible1);

				mObject1.SetActive (true);

			print ("#### item1 coin");
			break;


		case "21":

			print ("### visible2" + mVisible2);

				mObject2.SetActive (true);

			print ("#### item2 ausweis");
			break;

		case "31":

			print ("### visible3" + mVisible3);

				mObject3.SetActive (true);

			print ("#### item3 ausweis");
			break;

		default:
			print ("#### default case");
			break;
		}


		mShowTextScript.setText ("### buy item via JavaMessageIn() :: " + aString);
		print ("### print:: JavaMessageIn() :: " + aString);
	}


	public void SendFullNameToUnity(string aFullName) {

		mGuiBoxScript.showBox (true);
		mGuiBoxScript.setTextBox ("Hallo, dein Name ist\n" + aFullName + "\nund du bist gerade ins Spiel gestartet.");
	}
}