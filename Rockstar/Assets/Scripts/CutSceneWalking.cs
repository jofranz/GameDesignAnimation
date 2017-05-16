using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneWalking : MonoBehaviour {

	public float speed = 2.0f;
	private Vector2 targetPosition;

	private Rigidbody2D rg;
	private Animator animator;
	private float prevPosX = 0;
	private Vector2 position;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		rg = GetComponent<Rigidbody2D>();

		// targetPosition = new Vector3 (-3.3f, -1.17f, 0);

		transform.localScale = new Vector3 (-1, 1, 1); // looks to the right
		targetPosition = new Vector3 (3.5f, -0.36f, 0); // walks to postivion

		targetPosition = new Vector3 (-1.68f, -0.1f, 0); // walks to postivion

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);




	}
}
