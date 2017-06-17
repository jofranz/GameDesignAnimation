using UnityEngine;
using System.Collections;

public class PlayerLookingDirection : MonoBehaviour {

	private Rigidbody2D rg;
	private Animator mAnimator;
	private float prevPosX = 0;
	private Vector2 position;

	void Start(){
		mAnimator = GetComponent<Animator> ();
		rg = GetComponent<Rigidbody2D>();

	}



	// Update is called once per frame
	void Update () {

		//mAnimator.SetInteger ("AnimState", 40); // 40 = puke animation
		print ("puke");
		mAnimator.SetTrigger ("doPuke");

		if(false) {
		// checks and animates player if moving
		if (rg.position.x != prevPosX) {
			print("anim state change 1"); // walking animation
				mAnimator.SetInteger ("AnimState", 1);
		} else { // standing animation
				mAnimator.SetInteger("AnimState", 0);
			print("anim state change 0");
		}
		}
		prevPosX = rg.position.x;
		
	}
}