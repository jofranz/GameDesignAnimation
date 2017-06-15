using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour {

	private SpriteRenderer spRenderer;

	public bool mVisible;
	private float mNextActionTime = 0.0f;
	private float mTimePeriod = 1.0f;
	public int mPeriodMin = 1;
	public int mPeriodMax = 3;
	public int mDurationMin = 0;
	public int mDuratoinMax = 15;


	void Start () {
		spRenderer = gameObject.GetComponent<SpriteRenderer> (); // prepare sprite renderer
	}


	void Update () {
		// set time period
		mTimePeriod = Random.Range (mPeriodMin, mPeriodMax);

		// timer
		if(Time.time > mNextActionTime) {
			mNextActionTime = mTimePeriod + mNextActionTime + Random.Range (mDuratoinMax, mDuratoinMax);

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