using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ItemTrigger : MonoBehaviour {

	GuiLabel GuiLabelScript;
	public GameObject GuiLabelGO;




	// Use this for initialization
	void Start () {

		//GuiLabelGO = GameObject.Find ("Main Camera");
		GuiLabelScript = GuiLabelGO.GetComponent<GuiLabel> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter2D(Collider2D target) {
		print ("enter box " + Time.fixedTime);


		GuiLabelScript.showBox (true);
	}

//	void OnTriggerExit2D(Collider2D target) {
//		print ("exit box " + Time.fixedTime);
//	}





}