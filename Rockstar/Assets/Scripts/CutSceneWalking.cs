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

	private bool mPos2 = true;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rg = GetComponent<Rigidbody2D>();

		mBlackUpperGO = GameObject.Find ("black_box_upper");
		mBlackLowerGO = GameObject.Find ("black_box_lower");

		transform.localScale = new Vector3 (-1, 1, 1); // looks to the right


		goToPosition (-1.73f, -0.6f);


		StartCoroutine( FadeFromBlack() );

		SingletonData.Instance.globalClickWalkingIsDisabled = false;

	}
		

	// Update is called once per frame
	void Update () {

		// !SingletonData.Instance.globalClickWalkingIsDisabled
		if( true ) {
			transform.position = Vector2.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);	
		}





		if (transform.position.x == -1.73f) {
			print ("angekommen !!!");
			if(mPos2) {
				mPos2 = false;
				goToPosition (5.0f, -0.6f);
			}
		} else if (transform.position.x == 5.0f) {

			for(float pxPos = 0; pxPos < 200; pxPos = pxPos + 0.0001f) {
				mBlackUpperGO.transform.position = new Vector3 ( mBlackUpperGO.transform.position.y, mBlackUpperGO.transform.position.x + 5.0f, (float)pxPos );
				mBlackLowerGO.transform.position = new Vector3 ( mBlackLowerGO.transform.position.y, mBlackLowerGO.transform.position.y + 5.0f, (float)pxPos );
			}

			Destroy (this);		
		}

	}



	IEnumerator FadeFromBlack() {
		float mFadeTime = GameObject.Find("Main Camera").GetComponent<Fade> ().beginFade (1);
		yield return new WaitForSeconds (mFadeTime);
	}

	bool goToPosition(float aPosX, float aPosY) {
		targetPosition = new Vector3 (aPosX, aPosY); // walks to position
		return true;
	}
}