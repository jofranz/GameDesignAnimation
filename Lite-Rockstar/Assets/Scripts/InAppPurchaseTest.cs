using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InAppPurchaseTest : MonoBehaviour {

	private GameObject mAndroidCCGO;
	private AndroidCommunicationController mAndroidCCScript;
	public bool mSendText = false;
	public string mText = "bla";
	public string mFullName = "J F";

	// Use this for initialization
	void Start () {
		mAndroidCCGO = GameObject.Find ("AndroidCommunication");
		mAndroidCCScript = mAndroidCCGO.GetComponent<AndroidCommunicationController> ();
	}


	// Update is called once per frame
	void Update () {

		// use checkbox as a button to send a single text
		if(mSendText) {
			mSendText = false;
			mAndroidCCScript.JavaMessageIn (mText);
			mAndroidCCScript.SendFullNameToUnity (mFullName);
		}
		
	}
}