using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDiamonds3 : MonoBehaviour {

	private bool start = true;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	public GameObject next;
	private bool ifPlayer = false;
	public bool takeDia3 = false;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start) 
		{
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
					GameObject.Find ("Name").GetComponent<Text> ().text = "System";
				}
				next.GetComponent<DialogManager> ().DisplayNextSentence ();
			}
		}

		if (next.GetComponent<DialogManager> ().ifEnd == true && !takeDia3 && !start)
		{
			dia.SetActive (false);
			takeDia3 = true;
			GameObject.Find("Rabbish1").GetComponent<GetDiamonds1>().diamonds += 10;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
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
