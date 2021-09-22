using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoDia : MonoBehaviour 
{
	private bool start = true;
	private bool end = false;
	private bool s = true;
	public bool goFindNaggets = false;
	public bool findLastDia = false;
	public GameObject dia;
	private GameObject player;
	public GameObject Ildar;
	public GameObject diamonds;
	public GameObject findFood;
	public GameObject text;
	public GameObject next;
	private bool ifPlayer;

	void Start()
	{
		Ildar.SetActive (false);
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("CoWorker").GetComponent<GoSmart> ().smart == true && !goFindNaggets) 
		{
			Ildar.SetActive (true);
			//диалог
			if (GameObject.Find ("Rabbish1").GetComponent<GetDiamonds1> ().diamonds == 50) 
			{
				if (Input.GetKeyDown (KeyCode.F) && start && ifPlayer) 
				{
					GameObject.Find ("Smart").GetComponent<AudioSource> ().Pause();
					GameObject.Find ("IldarSound").GetComponent<AudioSource> ().Play (0);
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
							if (next.GetComponent<DialogManager> ().sentences.Count % 2 == 0 || next.GetComponent<DialogManager> ().sentences.Count <= 2) 
							{
								GameObject.Find ("Name").GetComponent<Text> ().text = "Ильдар";
							}
							if (next.GetComponent<DialogManager> ().sentences.Count % 2 != 0 && next.GetComponent<DialogManager> ().sentences.Count > 2) 
							{
								GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
							}
							if (next.GetComponent<DialogManager> ().sentences.Count <= 4) 
							{
								Ildar.GetComponent<Animator> ().SetBool ("40", true);
							}
						}
						next.GetComponent<DialogManager> ().DisplayNextSentence ();
					}
				}

				if (next.GetComponent<DialogManager> ().ifEnd == true && next.GetComponent<DialogManager> ().endOfPrinting && !start) 
				{
					dia.SetActive (false);
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
					goFindNaggets = true;
					end = true;
					Ildar.GetComponent<Animator> ().SetBool ("tlf", true);
					GameObject.Find ("IldarSound").GetComponent<AudioSource> ().Pause();
					GameObject.Find ("Smart").GetComponent<AudioSource> ().Play(0);
				}
			}
			//отказ в диалоге
			if (GameObject.Find ("Rabbish1").GetComponent<GetDiamonds1> ().diamonds < 50) 
			{
				if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start) 
				{
					start = false;
					dia.SetActive (true);
					GameObject.Find ("Name").GetComponent<Text> ().text = "System";
					diamonds.GetComponent<DialogTrigger> ().TriggerDialog ();
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				}

				if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && !start) 
				{
					dia.SetActive (false);
					findLastDia = true;
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
					player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
					start = true;
				}
			}
		}
		//диалог после диалога
		if (!GameObject.Find("Lyk").GetComponent<Cooked>().nuggetsReady)
		{
			if (Input.GetKeyDown (KeyCode.F) && end && ifPlayer && s) 
			{
				s = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Ильдар";
				findFood.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			} 

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && end && !s) 
			{
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				s = true;
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
