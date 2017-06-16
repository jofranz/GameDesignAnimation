using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgmt : MonoBehaviour {




	// Use this for initialization
	void Start () {
		print ("SceneMgmt.cs started");
	}


	// Update is called once per frame
	void Update () {
		
	}


	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0) ) {
			StartCoroutine (ChangeLevel () );
		}
	}


	public void changeLevel() {
		StartCoroutine (ChangeLevel () );
	}


	public void changeLevelToLevel0() {
		StartCoroutine (ChangeLevelToLevel0 () );
	}


	// fade to black
	IEnumerator ChangeLevelToLevel0() {
		float mFadeTime = GameObject.Find("Main Camera").GetComponent<Fade> ().beginFade (1);
		yield return new WaitForSeconds (mFadeTime);

		SceneManager.LoadScene ("Level0", LoadSceneMode.Single);
	}



	// fade to black
	IEnumerator ChangeLevel() {
		float mFadeTime = GameObject.Find("Main Camera").GetComponent<Fade> ().beginFade (1);
		yield return new WaitForSeconds (mFadeTime);
		SceneManager.LoadScene ("CutScene", LoadSceneMode.Single);
	}

}