using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneWalking : MonoBehaviour {

	public float speed = 2.0f;
	private Vector2 targetPosition;

	private Rigidbody2D rg;
	private Animator animator;
	private Vector2 position;

	

	private GameObject mBlackUpperGO;
	private GameObject mBlackLowerGO;

	private GameObject mCamera;
	private CameraFollow mCameraFollowScript;

	private bool mPos2 = true;
	private bool mPlayerAutoWalk = true;
	private float mBannerSpeed = 0.8f;

	// Use this for initialization
	void Start () {

		StartCoroutine( FadeFromBlack() );

		animator = GetComponent<Animator> ();
		rg = GetComponent<Rigidbody2D>();

		mBlackUpperGO = GameObject.Find ("black_box_upper");
		mBlackLowerGO = GameObject.Find ("black_box_lower");


		transform.localScale = new Vector3 (-1, 1, 1); // looks to the right


		mCamera = GameObject.Find ("Main Camera");
		mCameraFollowScript = mCamera.GetComponent<CameraFollow> ();


		mCameraFollowScript.enabled = false;

		goToPosition (-1.73f, -0.6f);



		SingletonData.Instance.globalClickWalkingIsDisabled = false;

	}
		

	// Update is called once per frame
	void Update () {

		//print ("target pos: " + targetPosition);

		// !SingletonData.Instance.globalClickWalkingIsDisabled
		if( mPlayerAutoWalk ) {
			transform.position = Vector2.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);	
		}

		if (transform.position.x == -1.73f) {
			print ("angekommen !!!");
			if(mPos2) {
				mPos2 = false;
				goToPosition (5.0f, -0.6f);
			}
		} 


		// move cinema bars away and destroy gameobject
		if (SingletonData.Instance.globalStoryMoveCinemaBars && transform.position.x > 4.9f) {
			
			Vector2 upperVecGoal = new Vector2 (0.0f, 5.0f);
			mBlackUpperGO.transform.position = Vector2.MoveTowards (mBlackUpperGO.transform.position, upperVecGoal, mBannerSpeed * Time.deltaTime);

			Vector2 lowerVecGoal = new Vector2 (0.0f, -5.0f);
			mBlackLowerGO.transform.position = Vector2.MoveTowards(mBlackLowerGO.transform.position, lowerVecGoal, mBannerSpeed * Time.deltaTime);


			if(mBlackUpperGO.transform.position.y > 4.9f) {
				mPlayerAutoWalk = false;
				print ("DESTROYED cutscenewalking!!!");
				mCameraFollowScript.enabled = true;
				Destroy (this);
			}
		}
	}


	IEnumerator FadeFromBlack() {
		print ("fadeded!!!??");
		float mFadeTime = GameObject.Find("Main Camera").GetComponent<Fade> ().beginFade (-1);
		yield return new WaitForSeconds (3);
	}


	void goToPosition(float aPosX, float aPosY) {
		targetPosition = new Vector3 (aPosX, aPosY); // walks to position
	}
}