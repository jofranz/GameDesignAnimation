using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour {

	private GameObject mTextControllerGO;

	private GuiBox mGuiBox;

	private bool mDisplayGuiBox = true;
	private bool mClickedOnce = false;
	private bool mActionCompleted = false;
	private int mArrayPos = 0;
	private bool mActionHasStarted = false;

	// Use this for initialization
	void Start () {

		print("Story.cs start method");
		mTextControllerGO = GameObject.Find ("TextController");


		mGuiBox = mTextControllerGO.GetComponent<GuiBox> ();


		SingletonData.Instance.globalClickWalkingIsDisabled = true;

		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der 1. Text");
		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der 2. Text");
		mGuiBox.mStoryActionArrayList.Add ("_Action:testStr1");
		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der 3. Text");

		SingletonData.Instance.globalMouseHasBeenClicked = false;
		mGuiBox.showBox (false);
		mGuiBox.setTextInBox("angezeigt");
	}
	
	// Update is called once per fram
	void Update () {

		if ( SingletonData.Instance.globalMouseHasBeenClicked ) {
			SingletonData.Instance.globalMouseHasBeenClicked = false;

			if( !mActionHasStarted ) {
				mouseClicked();
			}

		}

	}


	void mouseClicked() {
		print ("mouseClicked this is it!!!");
		mGuiBox.showBox (true);
		mGuiBox.setTextInBox("angezeigt!!!!");

		if(mGuiBox.mStoryActionArrayList.Count > mArrayPos) { // is in bounds of the array
			if( mGuiBox.mStoryActionArrayList[mArrayPos].StartsWith("_Action:") ) { // has "action" keyword in it
				print( "Action Str: " + mGuiBox.mStoryActionArrayList[mArrayPos].Substring(8) );
				handleAction( mGuiBox.mStoryActionArrayList[mArrayPos].Substring(8) );
				mGuiBox.showBox(false);
				mDisplayGuiBox = false;
				mActionHasStarted = true;
				SingletonData.Instance.globalClickWalkingIsDisabled = false;

			} else { // is a normal text phrase
				mGuiBox.showBox (true);
				mGuiBox.setTextInBox (mGuiBox.mStoryActionArrayList[mArrayPos] );
			}
		} else { // not in bounds of the array
			mGuiBox.showBox (false);
			print ("else block");
		}

		mArrayPos++;

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


/*
		if( mDisplayGuiBox && SingletonData.Instance.globalScreenIsVisible == true ) {
			print ("bildschirm ist frei");
			mDisplayGuiBox = false;
			SingletonData.Instance.globalScreenIsVisible = false;

			returnTextFromBeginning ();
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

*/

}