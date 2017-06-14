using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour {

	private GameObject mTextControllerGO;
	private GuiBox mGuiBox;

	// Use this for initialization
	void Start () {

		print("Story.cs start");
		mTextControllerGO = GameObject.Find ("TextController");
		mGuiBox = mTextControllerGO.GetComponent<GuiBox> ();


		mGuiBox.setTextInBox ("text von story.cs");
		mGuiBox.showBox (true);
	}
	
	// Update is called once per fram
	void Update () {

		if(SingletonData.Instance.globalScreenIsVisable) {
			print ("bildschirm ist frei");
			SingletonData.Instance.globalScreenIsVisable = false;
			mGuiBox.setTextInBox ("text zwei von story");
		} 


		if (false) {
			mGuiBox.showBox (false);
		}

	}
}