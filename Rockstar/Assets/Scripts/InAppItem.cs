using UnityEngine;
using System.Collections;

public class InAppItem : MonoBehaviour {

	public GameObject myObject;
	//	public SpriteRenderer spRenderer;
	private bool visible;
	private int myTime;

	void Start () {
		myObject = GameObject.Find ("coins");
	}

	void Update () {

		myTime = (int)( Time.fixedTime );	

		if(myTime > 4) {
			//toggleObject ();
		}
	}

	void toggleObject() {
		if(visible) {
			visible = false;
		} else {
			visible = true;
		}

		myObject.SetActive (visible);
	}
}