using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrain : MonoBehaviour {
	public float moveValue;
	// Use this for initialization
	void Start () {
		moveValue = -0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Translate (new Vector3 (moveValue, 0.0f, 0.0f));

		var animator = gameObject.GetComponent<Animator> ();

		RuntimeAnimatorController ac = animator.runtimeAnimatorController;

	}
}
