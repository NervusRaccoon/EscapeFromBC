using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourthDialog : MonoBehaviour 
{
	private bool start = true;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	private Animator anim;
	public GameObject no;
	public GameObject next;
	private bool ifPlayer;
	public bool goChoice = false;


	void Start()
	{
		anim = GameObject.Find("CoWorker").GetComponent<Animator> ();
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("TrashCan1").GetComponent<ThrowRabbish> ().count == 4) 
		{
			if (!GameObject.Find("CoWorker").GetComponent<GoResultOfChoice>().goRes)
			{
				if (Input.GetKeyDown (KeyCode.F) && start && ifPlayer) 
				{
					anim.SetBool ("flag", false);
					start = false;
					dia.SetActive (true);
					GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
					text.GetComponent<DialogTrigger> ().TriggerDialog ();
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				}

				if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
				{
					if (next.GetComponent<DialogManager> ().ifEnd == false) 
					{
						if (next.GetComponent<DialogManager> ().endOfPrinting)
						{
							if (next.GetComponent<DialogManager> ().sentences.Count == 5
							    || next.GetComponent<DialogManager> ().sentences.Count == 3) 
							{
								GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
							}
							if (next.GetComponent<DialogManager> ().sentences.Count == 4
							    || next.GetComponent<DialogManager> ().sentences.Count == 2
							    || next.GetComponent<DialogManager> ().sentences.Count == 1) 
							{
								GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
							}
						}	
						next.GetComponent<DialogManager> ().DisplayNextSentence ();
					}
				}

				if (next.GetComponent<DialogManager> ().ifEnd == true && !start) 
				{
					dia.SetActive (false);
					goChoice = true;
				}
			}
		}
		else
		{
			if (GameObject.Find ("CoWorker").GetComponent<ThirdDialog> (). goTakeRag == true)
			{
				if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start) 
				{
					anim.SetBool ("flag", false);
					anim.SetBool("brov", true);
					start = false;
					dia.SetActive (true);
					GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
					no.GetComponent<DialogTrigger> ().TriggerDialog ();
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				}

				if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && !start) 
				{
					anim.SetBool("brov", false);
					anim.SetBool("angry", false);
					anim.SetBool ("flag", true);
					dia.SetActive (false);
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
					start = true;
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
	//ещё будет анимация с IEnumerator Wait()

}
