using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoMop: MonoBehaviour {

	private bool start = false;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	private bool ifPlayer = false;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("Uniform").GetComponent<GetMop> ().withMop == false && GameObject.Find ("CoWorker").GetComponent<SecondDialog> ().createPuddle == true) 
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer && !start) 
			{
				start = true;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && start) 
			{
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				start = false;
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
