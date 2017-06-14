using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour {

	private SpriteRenderer spRenderer;

	public bool mVisible;
	private float mNextActionTime = 0.0f;
	private float mTimePeriod = 1.0f;

	void Start () {
		spRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}


	void Update () {
		// set time period
		mTimePeriod = Random.Range (1, 3);

		// timer
		if(Time.time > mNextActionTime) {
			mNextActionTime = mTimePeriod + mNextActionTime + Random.Range (0, 4);

			toggleLight ();
		}
	}


	public void setFromOutside() {
		mVisible = false;
	}


	void toggleLight() {
		if(mVisible) {
			mVisible = false;
		} else {
			mVisible = true;
		}

		spRenderer.enabled = mVisible;
	}
}	