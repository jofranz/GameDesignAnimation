using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoMouse : MonoBehaviour {

	public float speed = 2.0f;
	public float playerDefaultYPosition = 2.12f; // negative value down below
	private Vector2 clickTarget;
	private Vector2 target;

	// Use this for initialization
	void Start () {
		clickTarget = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		walkToClickPosition ();

		setPlayerPerspective ();
	}


	void walkToClickPosition() {
		if ( Input.GetMouseButton (0) ) {
			clickTarget = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			// print (clickTarget);
			target.y = transform.position.y;
		}
		clickTarget.y = - playerDefaultYPosition;
		transform.position = Vector2.MoveTowards (transform.position, clickTarget, speed * Time.deltaTime);
	}


	void setPlayerPerspective() {
		// checks in which direction the player is looking
		if (transform.position.x < clickTarget.x) {
			transform.localScale = new Vector3 (-1, 1, 1); // looks to the right
		} else if (transform.position.x > clickTarget.x) {
			transform.localScale = new Vector3 (1,1,1); // looks to the left
		}
	}
}