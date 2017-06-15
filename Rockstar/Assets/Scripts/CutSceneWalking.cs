using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneWalking : MonoBehaviour {

	public float speed = 2.0f;
	private Vector2 targetPosition;

	private Rigidbody2D rg;
	private Animator animator;
	private Vector2 position;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rg = GetComponent<Rigidbody2D>();

		// targetPosition = new Vector3 (-3.3f, -1.17f, 0);

		transform.localScale = new Vector3 (-1, 1, 1); // looks to the right
		//targetPosition = new Vector3 (3.5f, -0.36f, 0); // walks to position

		if (goToPosition (3.5f, -0.36f)) {
			goToPosition (-3.3f, -1.17f);
		}

		//targetPosition = new Vector3 (-1.68f, -0.1f, 0); // walks to position


		StartCoroutine( FadeFromBlack() );


	}



	IEnumerator FadeFromBlack() {
		float mFadeTime = GameObject.Find("Main Camera").GetComponent<Fade> ().beginFade (-1);
		yield return new WaitForSeconds (mFadeTime);
	}

	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
	}


	bool goToPosition(float posX, float posY) {
		if (transform.position.x == posX) {
			return true;
		} 
		targetPosition = new Vector3 (posX, posY, 0); // walks to position
		return true;
	}
}