using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box: MonoBehaviour {

	private bool start = false;
	public GameObject dia;
	private Animator anim;
	private GameObject player;
	public GameObject text;
	public GameObject next;
	private bool ifPlayer = false;
	public bool takeBox = false;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GameObject.Find ("Boxes").GetComponent<Animator> ();
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.F) && ifPlayer && !start) 
		{
			start = true;
			dia.SetActive (true);
			GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
			text.GetComponent<DialogTrigger> ().TriggerDialog ();
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		}

		if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
		{
			if (next.GetComponent<DialogManager> ().ifEnd == false) 
			{					
				next.GetComponent<DialogManager> ().DisplayNextSentence ();
			}
		}

		if (next.GetComponent<DialogManager> ().ifEnd == true && !takeBox && start)
		{
			anim.SetBool ("box", true);
			dia.SetActive (false);
			takeBox = true;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Player") 
			ifPlayer = true;
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.tag == "Player") 
			ifPlayer = false;
	}
}
