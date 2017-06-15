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

		transform.localScale = new Vector3 (-1, 1, 1); // looks to the right

		SingletonData.Instance.globalClickWalkingIsDisabled = true;





		StartCoroutine( FadeFromBlack() );

		SingletonData.Instance.globalClickWalkingIsDisabled = false;

	}
		

	// Update is called once per frame
	void Update () {

		// !SingletonData.Instance.globalClickWalkingIsDisabled
		if( true ) {
			transform.position = Vector2.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);	
		}



		goToPosition (-1.73f, -0.6f);

		if (transform.position.x != -1.73f) {
			print ("angekommen");
			//goToPosition (-3.73f, -0.6f);
		}

	}

	IEnumerator FadeFromBlack() {
		float mFadeTime = GameObject.Find("Main Camera").GetComponent<Fade> ().beginFade (-1);
		yield return new WaitForSeconds (mFadeTime);
	}

	bool goToPosition(float aPosX, float aPosY) {
		targetPosition = new Vector3 (aPosX, aPosY); // walks to position
		return true;
	}
}