using UnityEngine;
using System.Collections;

public class PlayerLookingDirection : MonoBehaviour {


	private Rigidbody2D rg;
	private Animator animator;
	private float prevPosX = 0;
	private Vector2 position;

	void Start(){
		animator = GetComponent<Animator> ();
		rg = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {




		// checks and animates player if moving
		if (rg.position.x != prevPosX) {
			// print("anim state change 1");
			animator.SetInteger ("AnimState", 1);
		} else {
			animator.SetInteger("AnimState", 0);
			// print("anim state change 0");
		}
			
		prevPosX = rg.position.x;
	}
}
	