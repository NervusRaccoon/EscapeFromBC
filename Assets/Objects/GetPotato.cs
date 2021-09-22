using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPotato : MonoBehaviour {

	private bool start = false;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	private bool ifPlayer = false;
	public bool takePotato = false;
	public GameObject img;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if ((GameObject.Find("Choice").GetComponent<Choice>().ch1 || GameObject.Find("Choice").GetComponent<Choice>().ch2) 
			&& !GameObject.Find("CoWorker").GetComponent<GoResultOfChoice>().goRes)
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
				takePotato = true;
				img.SetActive(true);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
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
