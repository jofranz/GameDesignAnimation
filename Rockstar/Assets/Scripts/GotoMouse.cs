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

	public float speed = 2.0f;
	// public float playerUpperYPosition = 2.72f; // negative value down below
	// public float playerLowerYPosition = 0.7f; // negative value down below
	private Vector2 clickTarget;

	// Use this for initialization
	void Start () {
		clickTarget = transform.position;
		// print ("pos: " + playerUpperYPosition + " :: " + playerLowerYPosition);
	}

	// Update is called once per frame
	void Update () {
		walkToClickPosition ();
		setPlayerPerspective ();
	}


	void walkToClickPosition() {
		if ( Input.GetMouseButton (0) ) {
			clickTarget = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}


		if (clickTarget.y > 0.33f) { //negative
			clickTarget.y = 0.33f;
		}


		if (clickTarget.y < -1.97f) { //negative
			clickTarget.y = -1.97f;
		}

		transform.position = Vector2.MoveTowards (transform.position, clickTarget, speed * Time.deltaTime);

		//transform.position = Vector2.MoveTowards(
	}


	// vertical mirror axis for player looking direction
	void setPlayerPerspective() {
		// checks in which direction the player is looking
		if (transform.position.x < clickTarget.x) {
			transform.localScale = new Vector3 (-1, 1, 1); // looks to the right
		} else if (transform.position.x > clickTarget.x) {
			transform.localScale = new Vector3 (1,1,1); // looks to the left
		}
	}
}