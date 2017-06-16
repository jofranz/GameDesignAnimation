using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour {

	private GameObject mTextControllerGO;
	private GameObject mBeerFullGO;
	private GameObject mBeerEmptyGO;

	private SingletonData mSingleton;

	private GuiBox mGuiBox;

	private bool mDisplayGuiBox = true;
	private bool mClickedOnce = false;
	private bool mActionCompleted = false;
	private bool mActionHasStarted = false;
	private bool mContinueRunningBeer = true;
	private bool mCheckIfPlayerArrivedLeft = false;
	private bool mBeerFullRunBefore = false;
	private int mArrayPos = 0;




	// Use this for initialization
	void Start () {

		print("Story.cs start method");
		mTextControllerGO = GameObject.Find ("TextController");

		mBeerFullGO = GameObject.Find ("BierflascheVoll");
		mBeerEmptyGO = GameObject.Find ("BierflascheLeer");

		mBeerFullGO.SetActive (false);
		mBeerFullGO.GetComponent<SpriteRenderer> ().enabled = false;

		mBeerEmptyGO.SetActive (false);
		mBeerEmptyGO.GetComponent<SpriteRenderer> ().enabled = false;

		//mSpRendererBeerBootleFull = gameObject.GetComponent<SpriteRenderer> ().GetComponent<BierflascheVoll>(); // prepare sprite renderer

		SingletonData.Instance.globalClickWalkingIsDisabled = true;
		SingletonData.Instance.globalMouseHasBeenClicked = false;
		SingletonData.Instance.globalStoryInDalogue = true;

		mSingleton = new SingletonData ();

		mGuiBox = mTextControllerGO.GetComponent<GuiBox> ();


		mGuiBox.mStoryActionArrayList.Add ("<--- Geh doch mal nach links");
		mGuiBox.mStoryActionArrayList.Add ("_Action:moveCinemaBars");
		mGuiBox.mStoryActionArrayList.Add ("War doch falsch. Rechts gehts weiter. --->");
		mGuiBox.mStoryActionArrayList.Add ("Duncan: Oh eine Flasch Bier. Die ist auch noch fast haltbar.");
		mGuiBox.mStoryActionArrayList.Add ("_Action:activateWalking");
		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der lezte Text 1");
		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der lezte Text 2");
		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der lezte Text 3");
		mGuiBox.mStoryActionArrayList.Add ("Duncan:\nDas ist der lezte Text 4");
		mGuiBox.mStoryActionArrayList.Add ("_Action:changeToScene0");


	


		mGuiBox.showBox (true);
	}
	
	// Update is called once per fram
	void Update () {

		if(!mBeerFullRunBefore && SingletonData.Instance.globalStoryPlayerArrivedMinusX8) {
			mBeerFullRunBefore = true;
			mBeerFullGO.SetActive (true);
			mBeerFullGO.GetComponent<SpriteRenderer> ().enabled = true;
			mBeerEmptyGO.GetComponent<SpriteRenderer> ().enabled = true;
		}

		// one click
		if ( SingletonData.Instance.globalClicksAllowed && SingletonData.Instance.globalMouseHasBeenClicked ) {
			SingletonData.Instance.globalMouseHasBeenClicked = false;
			mouseClicked ();

		}


		// beer has been clicked while globalStoryInDialogue is not true
		if(SingletonData.Instance.globalStoryBeerClicked && SingletonData.Instance.globalStoryInDalogue && mContinueRunningBeer) {
			mBeerFullGO.GetComponent<SpriteRenderer> ().enabled = false;
			mBeerFullGO.GetComponent<BoxCollider2D> ().enabled = false;

			mContinueRunningBeer = false;

			SingletonData.Instance.globalClickWalkingIsDisabled = true;
			SingletonData.Instance.globalStoryInDalogue = true;
		}


		if(SingletonData.Instance.globalStoryPlayerArrivedMinusX8 && mCheckIfPlayerArrivedLeft) {
			SingletonData.Instance.globalClickWalkingIsDisabled = false;
			SingletonData.Instance.globalStoryInDalogue = true;
			mCheckIfPlayerArrivedLeft = false;
		}

	}


	void mouseClicked() {
		print ("## Story.cs: mouseClicked() method + " + SingletonData.Instance.globalStoryInDalogue);
		mGuiBox.showBox (true);
		// mGuiBox.setTextInBox("angezeigt!!!!");


		if(SingletonData.Instance.globalStoryInDalogue &&  mGuiBox.mStoryActionArrayList.Count > mArrayPos) { // is in bounds of the array
			print ("---> first if arr pos: " +mArrayPos);
			if( mGuiBox.mStoryActionArrayList[mArrayPos].StartsWith("_Action:") ) { // has "action" keyword in it
				print( "Action Str: " + mGuiBox.mStoryActionArrayList[mArrayPos].Substring(8) );

				mGuiBox.showBox(false);
				mDisplayGuiBox = false;
				mActionHasStarted = true;
				SingletonData.Instance.globalClickWalkingIsDisabled = false;
				SingletonData.Instance.globalStoryInDalogue = false;
				handleAction( mGuiBox.mStoryActionArrayList[mArrayPos].Substring(8) );
				mArrayPos++;

			} else { // is a normal text phrase
				mGuiBox.showBox (true);
				print ("NORMAL TEXT MODE");
				mGuiBox.setTextInBox (mGuiBox.mStoryActionArrayList[mArrayPos] );
				SingletonData.Instance.globalStoryInDalogue = true;
				mArrayPos++;
			}
		} else { // not in bounds of the array
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
			

			case "moveCinemaBars":
				print ("case: globalStoryMoveCinemaBars");
				SingletonData.Instance.globalStoryMoveCinemaBars = true;
				SingletonData.Instance.globalClickWalkingIsDisabled = false; // changed
				mCheckIfPlayerArrivedLeft = true;

				break;

			case "activateWalking":
				SingletonData.Instance.globalClickWalkingIsDisabled = false;
				SingletonData.Instance.globalStoryInDalogue = false;

				break;

			case "changeToScene0":
				GameObject mSceneGO;
				SceneMgmt mSceneScript;
				//mSceneGO.GetComponent<SceneMgmt> ();
				print ("changescene");

				mSceneGO = GameObject.Find ("Main Camera");
				mSceneScript = mSceneGO.GetComponent<SceneMgmt> ();

				DontDestroyOnLoad (mSingleton);

				mSceneScript.changeLevelToLevel0 ();
				break;

			default:
				print("switch default action string");
				break;
		}
	}
}