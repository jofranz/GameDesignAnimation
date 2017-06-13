using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour {

	public GameObject myWindow;
	public SpriteRenderer spRenderer;
	private bool visible;
	private int myTime;

	void Start () {
		// spRenderer = gameObject.GetComponent<SpriteRenderer> ();
		//spRenderer.enabled = false;

		myWindow = GameObject.Find ("Licht");
	}

	void Update () {

		myTime = (int)( Time.fixedTime );	

		if(myTime > 10) {
			toggleLight ();
		}
	}

	void toggleLight() {
		if(visible) {
			visible = false;
		} else {
			visible = true;
		}

		myWindow.SetActive (visible);
	}

}	