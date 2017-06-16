using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour {


	private ShowText mShowTextScript;
	private GameObject mTextControllerGO;

	private GuiBox mGuiBoxScript;
	private GameObject mGuiBoxGO;

	private float mStartTime = 0.0f;
	private float mPressDuration = 1.0f;
	private float mTimePassed = 0.0f;

	private bool mIsPressed = false;
	
	private string mTargetName;

	// Use this for initialization
	void Start () {
		// displays a text in the inventory section
		mTextControllerGO = GameObject.Find ("TextController");
		mShowTextScript = mTextControllerGO.GetComponent<ShowText>();

		mGuiBoxGO = GameObject.Find ("TextController");
		mGuiBoxScript = mGuiBoxGO.GetComponent<GuiBox> ();

		mTargetName = gameObject.transform.name;
	}


	// Update is called once per frame
	void Update () {
		if (mIsPressed) {
			mTimePassed = Time.time - mStartTime;
			// print ("##ItemInteraction.cs: timePassed: " + mTimePassed);

			// zeit abgelaufen?
			if ((mTimePassed > mPressDuration) ) {
				//print ("##ItemInteraction.cs: Sekunde/n abgelaufen");

				mShowTextScript.setText (mTargetName + " long pressed " + Time.time);

				resetTimer ();
			}
		}
	}
		

	void OnMouseOver() {

		if (SingletonData.Instance.globalClicksAllowed && Input.GetMouseButtonDown (0)) {

			if (mStartTime == 0.0F) {
				mStartTime = Time.time;
				print ("##ItemInteraction.cs: time set");
			}

			mIsPressed = true;

			//print ("##ItemInteraction.cs: startTime: " + mStartTime + " pressDuration: " + mPressDuration + " timePassed: " + mTimePassed);

			//print ("##ItemInteraction.cs: clicked once VIA THIS");

			mGuiBoxScript.showBox (true);
			// mShowTextScript.setText (mTargetName + " angeklickt " + Time.time);
			print ("## ItemInteraction.cs : " +  mTargetName + " angeklickt " + Time.time);


			switch (mTargetName) {
				case "BierflascheVoll":
					print ("##ItemInteraction.cs: BierflascheVoll case");
					SingletonData.Instance.globalStoryBeerClicked = true;
					SingletonData.Instance.globalStoryInDalogue = true;

					break;

				default:
					break;
			}
		} 


		if (Input.GetMouseButtonUp (0)) {
			resetTimer ();
		}
	}
	

	void OnMouseExit() {
		resetTimer ();
	}


	void resetTimer() {
		mIsPressed = false;
		mStartTime = 0.0F;
		//print ("##ItemInteraction.cs: resetTimer");
	}
}