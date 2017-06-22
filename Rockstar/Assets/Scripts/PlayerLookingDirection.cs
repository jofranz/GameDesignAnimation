using UnityEngine;
using System.Collections;

public class PlayerLookingDirection : MonoBehaviour {

	private Rigidbody2D rg;
	private Animator mAnimator;
	private float mPrevPosX = 0;
	private Vector2 mPositionVec;

	public bool mDoOnce = false;

	void Start(){
		mAnimator = GetComponent<Animator> ();
		rg = GetComponent<Rigidbody2D>();

		//mAnimator.SetTrigger ("doPuke");
	}



	// Update is called once per frame
	void Update () {


		if(mDoOnce){
			mDoOnce = false;


			mAnimator.SetInteger ("AnimState", 40); // 40 = puke animation
			//mAnimator.SetTrigger ("doPuke");
			print ("puke");
		}

		//mAnimator.SetInteger ("AnimState", 40); // 40 = puke animation

		if(true) {
		// checks and animates player if moving
			if (rg.position.x != mPrevPosX) {
			//print("anim state change 1"); // walking animation
				mAnimator.SetInteger ("AnimState", 1);
		} else { // standing animation
				mAnimator.SetInteger("AnimState", 0);
			//print("anim state change 0");
		}
		}
		mPrevPosX = rg.position.x;
		
	}
}