using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMop : MonoBehaviour 
{
	private bool start = true;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	private Animator anim;
	private bool ifPlayer;
	public bool withMop = false;

	void Start()
	{
		dia.SetActive (false);
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("CoWorker").GetComponent<SecondDialog> ().createPuddle == true && !withMop) 
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start) 
			{
				start = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && !start) 
			{
				anim.SetBool ("NoWvabra", true);
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				withMop = true;
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
