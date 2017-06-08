using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour {

	public GameObject myWindow;
	public SpriteRenderer spRenderer;
	public bool visible;
	private int myTime;

	void Start () {
		// spRenderer = gameObject.GetComponent<SpriteRenderer> ();
		//spRenderer.enabled = false;

		myWindow = GameObject.Find ("Licht");
	}

	void Update () {

		myTime = (int)( Time.fixedTime );	

		if(myTime > 7) {
			toggleLight ();
		}
	}

	public void setFromOutside() {
		visible = false;
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