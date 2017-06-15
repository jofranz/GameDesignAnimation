using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

	public Texture2D mFadeOutTexture;
	public float mFadeSpeed = 5.0f;

	private int mDrawDepth = -1000; // draw order of texture
	private float mAlpha = 1.0f; //alpha value beteen 0 and 1
	private int mFadeDirection = -1;

	void OnGUI() {
		mAlpha += mFadeDirection * mFadeSpeed * Time.deltaTime;
		mAlpha = Mathf.Clamp01 (mAlpha); //

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, mAlpha);
		GUI.depth = mDrawDepth;

		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), mFadeOutTexture);
	}

	public float beginFade(int aDirection) {
		mFadeDirection = aDirection;
		return (mFadeSpeed);
	}

	void onLevelWasLoaded() {
		beginFade (-1);
	}

}