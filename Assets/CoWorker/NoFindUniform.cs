using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoFindUniform : MonoBehaviour 
{
	public GameObject dia;
	private GameObject player;
	private Animator anim;
	public GameObject text;
	private bool ifPlayer;

	void Start()
	{
		anim = GameObject.Find("CoWorker").GetComponent<Animator> ();
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("CoWorker").GetComponent<FindUniform> ().goFindUniform == true 
			&& GameObject.Find ("Uniform").GetComponent<YesFindUniform> ().KotReady == false)
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer) 
			{
				anim.SetBool ("flag", false);
				anim.SetBool ("brov", true);
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
			{
				anim.SetBool ("angry", false);
				anim.SetBool ("brov", false);
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
