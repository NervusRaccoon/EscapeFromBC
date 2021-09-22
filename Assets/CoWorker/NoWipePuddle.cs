using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoWipePuddle : MonoBehaviour 
{
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	private Animator anim;
	private bool ifPlayer;

	void Start()
	{
		anim = GameObject.Find("CoWorker").GetComponent<Animator> ();
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("CoWorker").GetComponent<SecondDialog> ().createPuddle == true 
			&& GameObject.Find ("Puddle").GetComponent<NoPuddle> ().noPuddle == false)
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer) 
			{
				anim.SetBool ("flag", false);
				anim.SetBool("angry", true);
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
			{
				anim.SetBool("brov", false);
				anim.SetBool("angry", false);
				anim.SetBool ("flag", true);
				dia.SetActive (false);
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
