using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooked : MonoBehaviour 
{
	private bool start = true;
	public bool cooked = false;
	private bool end = false;
	public bool nuggetsReady = false;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	public GameObject text2;
	public GameObject text3;
	private Animator anim;
	private bool ifPlayer;

	void Start()
	{
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GameObject.Find ("Lyk").GetComponent<Animator> ();
	}

	void Update()
	{
		if (GameObject.Find("Nuggets").GetComponent<Nuggets>().takeNugg && !cooked) 
		{
			if (Input.GetKeyDown (KeyCode.F) && start && ifPlayer) 
			{
				start = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}
				
			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && !start && !cooked) 
			{
				dia.SetActive (false);
				StartCoroutine (Wait());
			}
		}
		if (!GameObject.Find("Boxes").GetComponent<Box>().takeBox)
		{
			if (cooked && !end) 
			{
				if (start)
				{
					dia.SetActive (true);
					GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
					text2.GetComponent<DialogTrigger> ().TriggerDialog ();
					start = false;
				}

				if (Input.GetKeyDown (KeyCode.Return) && !end) 
				{
					end = true;
					dia.SetActive (false);
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
					start = true;
				}
			}
		}
		if (cooked && GameObject.Find("Boxes").GetComponent<Box>().takeBox && !nuggetsReady) 
		{
			if (start) 
			{
				start = false;
				Debug.Log ("Кыс-кыс-кыс");
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				text3.GetComponent<DialogTrigger> ().TriggerDialog ();
			}

			if (Input.GetKeyDown (KeyCode.Return)) 
			{
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				nuggetsReady = true;
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

	IEnumerator Wait()
	{
		anim.SetBool ("nug", true);
		yield return new WaitForSeconds (4f);
		anim.SetBool ("nug", false);
		cooked = true;	
		start = true;
	}
	/*IEnumerator Box()
	{
		if (!end) 
		{
			end = true;
			dia.SetActive (false);
			yield return new WaitForSeconds (1f);
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}*/
}
