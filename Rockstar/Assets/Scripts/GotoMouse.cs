using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoMouse : MonoBehaviour {

	/*
	 * 
	 * Player walks wherever you click on the screen.
	 * Be careful. Unity converts a negative float to a positive one. Negative values are added down below 
	 * 
	*/

	public float mSpeed = 2.0f;
	// public float playerUpperYPosition = 2.72f; // negative value down below
	// public float playerLowerYPosition = 0.7f; // negative value down below
	private Vector2 mClickTarget;

	// Use this for initialization
	void Start () {
		mClickTarget = transform.position;
		// print ("pos: " + playerUpperYPosition + " :: " + playerLowerYPosition);
	}

	// Update is called once per frame
	void Update () {

		if( !SingletonData.Instance.globalClickWalkingIsDisabled ) {
			walkToClickPosition ();
			setPlayerPerspective ();
		}
	}


	void walkToClickPosition() {
		if ( Input.GetMouseButton (0) ) {
			mClickTarget = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}


		if (mClickTarget.y > 0.33f) { 
			mClickTarget.y = 0.33f;
		}


		if (mClickTarget.y < -1.97f) { //negative
			mClickTarget.y = -1.97f;
		}

		/*
		if(clickTarget.x < -17.3f) {//negative
			clickTarget.x = -17.3f;
		}

		if(clickTarget.x > 17.3f) {
			clickTarget.x = 17.3f;
		}

*/
		transform.position = Vector2.MoveTowards (transform.position, mClickTarget, mSpeed * Time.deltaTime);
	}


	// vertical mirror axis for player looking direction
	void setPlayerPerspective() {
		// checks in which direction the player is looking
		if (transform.position.x < mClickTarget.x) {
			transform.localScale = new Vector3 (-1, 1, 1); // looks to the right
		} else if (transform.position.x > mClickTarget.x) {
			transform.localScale = new Vector3 (1,1,1); // looks to the left
		}
	}
}