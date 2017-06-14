using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour {

	private GameObject mTextControllerGO;
	private GuiBox mGuiBox;

	private int mTextPos = 0;
	private bool mFirstStartTrue = true;

	// Use this for initialization
	void Start () {

		print("Story.cs start");
		mTextControllerGO = GameObject.Find ("TextController");
		mGuiBox = mTextControllerGO.GetComponent<GuiBox> ();



		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der 1. Text");
		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der 2. Text");
		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der 3. Text");

	

		mGuiBox.showBox (true);


	}
	
	// Update is called once per fram
	void Update () {
		
		prepareText ();
	}

	void prepareText() {
		if(mFirstStartTrue || SingletonData.Instance.globalScreenIsVisable == true) {
			print ("bildschirm ist frei");
			mFirstStartTrue = false;
			SingletonData.Instance.globalScreenIsVisable = false;



			returnTextFromBeginning ();
		} 
	}


	void returnTextFromBeginning() {

		print (mGuiBox.mStoryActionArrayList.Count + " > " + mTextPos);

		if(mGuiBox.mStoryActionArrayList.Count > mTextPos) { 
			mGuiBox.showBox (true);
			mGuiBox.setTextInBox (mGuiBox.mStoryActionArrayList[mTextPos] );



			mTextPos++;
		} else {
			mGuiBox.showBox (false);
			print ("else block");
		}
	}
}