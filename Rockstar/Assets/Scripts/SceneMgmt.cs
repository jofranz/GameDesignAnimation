using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgmt : MonoBehaviour {

	public string mTargetScene = "CutScene";
	public int mFadeDirection = 1;


	// Use this for initialization
	void Start () {
		print ("SceneMgmt.cs started");
	}


	// Update is called once per frame
	void Update () {
		
	}


	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0) ) {
			StartCoroutine (ChangeSceneToIEnum(mTargetScene, mFadeDirection) );
		}
	}


	public void ChangeSceneTo(string aTargetScene, int aFadeDirection) {
		StartCoroutine ( ChangeSceneToIEnum(aTargetScene, aFadeDirection) );
	}


	// fade to black
	IEnumerator ChangeSceneToIEnum(string aTargetScene, int aFadeDirection) {
		float mFadeTime = GameObject.Find("Main Camera").GetComponent<Fade> ().beginFade (aFadeDirection);
		yield return new WaitForSeconds (mFadeTime);
		SceneManager.LoadScene (aTargetScene, LoadSceneMode.Single);
	}
}