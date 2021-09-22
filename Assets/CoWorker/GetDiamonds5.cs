using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDiamonds5 : MonoBehaviour {

	private bool start = true;
	public GameObject dia;
	private GameObject player;
	public GameObject Ildar;
	public GameObject text;
	public GameObject next;
	private Animator anim;
	private bool ifPlayer = false;
	public bool takeDia5 = false;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GameObject.Find ("CoWorker").GetComponent<Animator> ();
	}

	void Update()
	{
		if (Ildar.GetComponent<NoDia>().findLastDia == true && !takeDia5)
		{
			if (Input.GetKeyDown (KeyCode.F) && start && ifPlayer) 
			{
				start = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Катерина";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
			{
				if (next.GetComponent<DialogManager> ().ifEnd == false) 
				{
					if (next.GetComponent<DialogManager> ().endOfPrinting) 
					{
						if (next.GetComponent<DialogManager> ().sentences.Count % 2 == 0 && next.GetComponent<DialogManager> ().sentences.Count != 1) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count % 2 != 0 && next.GetComponent<DialogManager> ().sentences.Count != 1) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 1) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "System";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count != 1) 
						{
							anim.SetBool ("smart", true);
						} 
					}
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}

			if (next.GetComponent<DialogManager> ().ifEnd == true && !takeDia5 && !start)
			{
				anim.SetBool ("smart", false);
				dia.SetActive (false);
				GameObject.Find("Rabbish1").GetComponent<GetDiamonds1>().diamonds += 10;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				takeDia5 = true;
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
