using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipSlides : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	
		if ( Input.GetMouseButtonUp (0) ) {
			print ("skip slide");
			StartCoroutine (ChangeLevel () );
		}

	}



	// fade to black
	IEnumerator ChangeLevel() {
		float mFadeTime = GameObject.Find("Main Camera").GetComponent<Fade> ().beginFade (1);
		yield return new WaitForSeconds (mFadeTime);

		SceneManager.LoadScene ("CutScene", LoadSceneMode.Single);
	}
}