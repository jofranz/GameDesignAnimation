using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonData : Singleton<SingletonData>
{


	public bool globalMouseHasBeenClicked = false;
	public bool globalClickWalkingIsDisabled = false;
	public bool globalStoryMoveCinemaBars = false;
	

	void Start () {
		
	}



	void Update() {
		if ( Input.GetMouseButtonUp (0) ) {
			SingletonData.Instance.globalMouseHasBeenClicked = true;
			//print ("singleton click!");
		}
	}





}