using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmSecond : MonoBehaviour 
{
	private bool start = true;
	private bool end = false;
	public bool choice3 = false;
	private bool endOfDark = false;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	public GameObject anim;
	public GameObject next;
	private bool ifPlayer;
	public GameObject win;
	public GameObject lose;
	public GameObject darkness;

	void Start()
	{
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find("FightPanel").GetComponent<Fight> ().endOfFight && !GameObject.Find("FightPanel").GetComponent<Fight> ().TheEnd1 && !choice3) 
		{
			if (!endOfDark)
				StartCoroutine (Dark ());
			if (endOfDark)
			{
				if (start) 
				{
					start = false;
					dia.SetActive (true);
					GameObject.Find ("Name").GetComponent<Text> ().text = "Константин";
					text.GetComponent<DialogTrigger> ().TriggerDialog ();
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				}
					
				if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
				{
					if (next.GetComponent<DialogManager> ().ifEnd == false) 
					{
						if (next.GetComponent<DialogManager> ().endOfPrinting) 
						{
							if (next.GetComponent<DialogManager> ().sentences.Count == 13 || next.GetComponent<DialogManager> ().sentences.Count == 6
								|| next.GetComponent<DialogManager> ().sentences.Count == 3) 
							{
								GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
							}
							else
							{
								GameObject.Find ("Name").GetComponent<Text> ().text = "Константин";
							}
						}
						next.GetComponent<DialogManager> ().DisplayNextSentence ();
					}
				}

				if (next.GetComponent<DialogManager> ().ifEnd == true && !start && !choice3) 
				{
					dia.SetActive (false);
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
					end = true;
					choice3 = true;
				}
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
	IEnumerator Dark()
	{
		anim.GetComponent<Animator>().SetBool ("angry", false);
		anim.GetComponent<Animator>().SetBool ("lose", true);
		darkness.GetComponent<Darkness> ().dark = true;
		yield return new WaitForSeconds (0.5f);
		win.SetActive (false);
		lose.SetActive (false);
		darkness.GetComponent<Darkness> ().dark = false;
		yield return new WaitForSeconds (0.5f);
		endOfDark = true;
	}
}
