using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonData : Singleton<SingletonData>
{


	public string myGlobalString = "whatever";
	public bool globalScreenIsVisable = false;

}