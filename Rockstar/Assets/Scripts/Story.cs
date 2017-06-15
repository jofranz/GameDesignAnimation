using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour {

	private GameObject mTextControllerGO;
	private GuiBox mGuiBox;

	private int mTextPos = 0;
	public bool mDisplayGuiBox = true;

	// Use this for initialization
	void Start () {

		print("Story.cs start method");
		mTextControllerGO = GameObject.Find ("TextController");
		mGuiBox = mTextControllerGO.GetComponent<GuiBox> ();

		SingletonData.Instance.globalClickWalkingIsDisabled = false;

		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der 1. Text");
		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der 2. Text");
		mGuiBox.mStoryActionArrayList.Add ("_Action:testStr1");
		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der 3. Text");

	

		//mGuiBox.showBox (true);


	}
	
	// Update is called once per fram
	void Update () {
		
		if( mDisplayGuiBox && SingletonData.Instance.globalScreenIsVisible == true ) {
			print ("bildschirm ist frei");
			mDisplayGuiBox = false;
			SingletonData.Instance.globalScreenIsVisible = false;

			returnTextFromBeginning ();
		} 
	}


	void returnTextFromBeginning() {

		// print (mGuiBox.mStoryActionArrayList.Count + " > " + mTextPos);
		if(mGuiBox.mStoryActionArrayList.Count > mTextPos) { 


			if( mGuiBox.mStoryActionArrayList[mTextPos].StartsWith("_Action:") ) {
				print( "Action Str: " + mGuiBox.mStoryActionArrayList[mTextPos].Substring(8) );
				handleAction( mGuiBox.mStoryActionArrayList[mTextPos].Substring(8) );
				mGuiBox.showBox (false);
				mDisplayGuiBox = false;
				SingletonData.Instance.globalScreenIsVisible = true;

			} else {
				mGuiBox.showBox (true);
				mGuiBox.setTextInBox (mGuiBox.mStoryActionArrayList[mTextPos] );
			}

			mTextPos++;
		} else {
			mGuiBox.showBox (false);
			print ("else block");
		}
	}

	void handleAction(string aActionStr) {
		print (aActionStr);


		switch (aActionStr) {

			case "testStr1":
				print("testStr1 case");
				break;

			default:
				print("switch default action string");
				break;
		}

	}

}