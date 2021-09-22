using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosedStorage : MonoBehaviour {

	private bool start = false;
	public bool storageClosed = false;
	public GameObject Ildar;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	public GameObject next;
	private bool ifPlayer = false;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (Ildar.GetComponent<NoDia> ().goFindNaggets && !storageClosed) 
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer && !start) 
			{
				start = true;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				player.GetComponent<Animator> ().SetBool ("up", false);
				player.GetComponent<Animator> ().SetBool ("down", false);
				player.GetComponent<Animator> ().SetBool ("right", false);
				player.GetComponent<Animator> ().SetBool ("left", false);
				player.GetComponent<Animator> ().SetBool ("cho", true);
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
			{
				if (next.GetComponent<DialogManager> ().ifEnd == false) 
				{
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}

			if (next.GetComponent<DialogManager> ().ifEnd == true && start && !storageClosed) 
			{
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				player.GetComponent<Animator> ().SetBool ("cho", false);
				storageClosed = true;
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
