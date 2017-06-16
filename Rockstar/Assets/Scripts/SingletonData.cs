using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonData : Singleton<SingletonData>
{


	public bool globalMouseHasBeenClicked = false;
	public bool globalClickWalkingIsDisabled = false;
	public bool globalStoryMoveCinemaBars = false;
	public bool globalStoryBeerClicked = false;
	public bool globalStoryInDalogue = true;
	public bool globalStoryPlayerArrivedMinusX8 = false;
	public bool globalClicksAllowed = true;

	void Start () {
		
	}



	void Update() {
		if ( globalClicksAllowed && Input.GetMouseButtonUp (0) ) {
			SingletonData.Instance.globalMouseHasBeenClicked = true;
			//print ("singleton click!");
		}
	}





}