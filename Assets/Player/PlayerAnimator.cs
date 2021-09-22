using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			anim.SetBool("right", true);
		else
			anim.SetBool("right", false);
		
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			anim.SetBool("left", true);
		else
			anim.SetBool("left", false);	
		
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			anim.SetBool("up", true);
		else
			anim.SetBool("up", false);	

		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			anim.SetBool("down", true);
		else
			anim.SetBool("down", false);	
	}
}
