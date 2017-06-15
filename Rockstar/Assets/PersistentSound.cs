using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentSound : MonoBehaviour {

	private static PersistentSound instance = null;
	public static PersistentSound Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}
}