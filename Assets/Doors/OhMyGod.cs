using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OhMyGod : MonoBehaviour {

	private bool start = false;
	private bool end = false;
	public GameObject dia;
	private GameObject player;
	private Animator anim;
	public GameObject text;
	public GameObject next;
	private bool ifPlayer = false;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		anim = player.GetComponent<Animator> ();
	}

	void Update()
	{
		if (GameObject.Find ("RestroomDoor3").GetComponent<OpenedDoor> ().opened && !end && ifPlayer) 
		{
			if (!start) 
			{
				GameObject.Find ("Smart").GetComponent<AudioSource> ().Pause();
				start = true;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				anim.SetBool ("scary", true);
			}

			if (Input.GetKeyDown (KeyCode.Return) && start) 
			{
				if (next.GetComponent<DialogManager> ().ifEnd == false) 
				{	
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}
			if (next.GetComponent<DialogManager> ().ifEnd == true && start && !end) 
			{
				anim.SetBool ("scary", false);
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				end = true;
				GameObject.Find ("Smart").GetComponent<AudioSource> ().Play(0);
			}
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
