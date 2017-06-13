using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgmt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		print ("SceneMgmt start");

	}


	// Update is called once per frame
	void Update () {
		
	}


	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene ("CutScene", LoadSceneMode.Single);
		}
	}
}