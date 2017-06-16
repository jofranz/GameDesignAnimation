using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour {

	private SpriteRenderer mSpRenderer;
	private GameObject mBeerFullGO;

	public bool mVisible;
	private float mNextActionTime = 0.0f;
	private float mTimePeriod = 1.0f;
	public float mPeriodMin = 1.0f;
	public float mPeriodMax = 3.0f;
	public float mDurationMin = 3.0f;
	public float mDuratoinMax = 15.0f;


	void Start () {
		mSpRenderer = gameObject.GetComponent<SpriteRenderer> (); // prepare sprite renderer
		mBeerFullGO = GameObject.Find ("BierflascheVoll");
		mBeerFullGO.GetComponent<SpriteRenderer> ().enabled = false;
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

		mSpRenderer.enabled = mVisible;
	}
}	