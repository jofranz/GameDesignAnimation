using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D target) {
		print ("enter box " + Time.fixedTime);
	}

	void OnTriggerExit2D(Collider2D target) {
		print ("exit box " + Time.fixedTime);
	}
}