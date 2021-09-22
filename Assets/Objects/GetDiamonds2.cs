using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDiamonds2 : MonoBehaviour {

	private bool start = false;
	private bool startY = true;
	public GameObject dia;
	private GameObject player;
	public GameObject yes;
	public GameObject no;
	public GameObject next;
	private Animator anim;
	private bool ifPlayer = false;
	public bool takeDia2 = false;
	public bool dialog = false;

	void Start () 
	{
		anim = GameObject.Find ("TrashCan1").GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("Gloves").GetComponent<GetGloves> ().takeGloves == true)
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer && startY) 
			{
				startY = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				yes.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
			{
				if (next.GetComponent<DialogManager> ().ifEnd == false) 
				{					
					if (next.GetComponent<DialogManager> ().endOfPrinting) 
					{
						GameObject.Find ("Name").GetComponent<Text> ().text = "System";
					}
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}

			if (next.GetComponent<DialogManager> ().ifEnd == true && !takeDia2 && !startY)
			{
				dia.SetActive (false);
				takeDia2 = true;
				anim.SetBool ("dia", true);
				GameObject.Find("Rabbish1").GetComponent<GetDiamonds1>().diamonds += 10;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				dialog = true;
			}
		}
		else
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer && !start) 
			{
				start = true;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				no.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && start) 
			{
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				//start = false;
				dialog = true;
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
