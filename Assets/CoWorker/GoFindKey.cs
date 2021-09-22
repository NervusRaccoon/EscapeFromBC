using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoFindKey : MonoBehaviour 
{
	private bool start = true;
	private bool end = false;
	private Animator anim;
	public bool openDoors = false;
	public GameObject dia;
	private GameObject player;
	private bool ifPlayer;
	public GameObject text;
	public GameObject next;

	void Start()
	{
		anim = GameObject.Find ("CoWorker").GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find("StorageDoor").GetComponent<ClosedStorage>().storageClosed && !openDoors)
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start)
			{
				start = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
			{
				if (next.GetComponent<DialogManager> ().ifEnd == false) 
				{
					if (next.GetComponent<DialogManager> ().endOfPrinting)
					{
						if (next.GetComponent<DialogManager> ().sentences.Count % 2 != 0 && next.GetComponent<DialogManager> ().sentences.Count != 1 
							|| next.GetComponent<DialogManager> ().sentences.Count == 2) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count % 2 == 0 && next.GetComponent<DialogManager> ().sentences.Count != 2 
							|| next.GetComponent<DialogManager> ().sentences.Count == 1) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						}	
						if (next.GetComponent<DialogManager> ().sentences.Count == 5 || next.GetComponent<DialogManager> ().sentences.Count == 4) 
						{
							anim.SetBool ("smart", true);
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 3 || next.GetComponent<DialogManager> ().sentences.Count == 2) 
						{
							anim.SetBool ("smart", false);
							anim.SetBool ("brov", true);
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 1) 
						{
							anim.SetBool ("brov", false);
						}
					}
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}

			if (next.GetComponent<DialogManager> ().ifEnd == true && !start && !openDoors) 
			{
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				openDoors = true;
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
