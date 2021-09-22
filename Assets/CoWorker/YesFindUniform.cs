using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesFindUniform : MonoBehaviour 
{
	private bool start = true;
	public GameObject dia;
	private GameObject player;
	private Animator anim;
	private Animator playerAnim;
	public GameObject textClothes;
	public GameObject textHat;
	public GameObject next;
	private bool ifPlayer;
	public bool foundUniform = false;
	public bool KotReady = false;

	void Start()
	{
		dia.SetActive (false);
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
		playerAnim = player.GetComponent<Animator> ();
	}

	void Update()
	{
		if (GameObject.Find ("CoWorker").GetComponent<FindUniform> ().goFindUniform == true && !foundUniform) 
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start) 
			{
				start = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				textClothes.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && !start) 
			{
				if (next.GetComponent<DialogManager> ().ifEnd == false) 
				{
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}

			if (next.GetComponent<DialogManager> ().ifEnd == true && !start) 
			{
				anim.SetBool ("noClothes", true);
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				foundUniform = true;
				start = true;
			}
		}

		if (GameObject.Find ("WC").GetComponent<ChangeClothes> ().changedClothes == true && !KotReady)
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start) 
			{
				start = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				textHat.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && !start) 
			{
				anim.SetBool ("noHat", true);
				dia.SetActive (false);
				playerAnim.SetBool ("hat", true);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				KotReady = true;
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
