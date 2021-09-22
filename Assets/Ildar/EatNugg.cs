using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatNugg : MonoBehaviour 
{
	private bool start = true;
	private bool end = false;
	private bool startCor = false;
	public bool whatNow = false;
	public GameObject dia;
	public GameObject anim;
	private GameObject player;
	public GameObject text;
	public GameObject next;
	private bool ifPlayer;

	void Start()
	{
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("Lyk").GetComponent<Cooked> ().nuggetsReady && !end) 
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
						if (next.GetComponent<DialogManager> ().sentences.Count % 2 == 0) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Ильдар";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count % 2 != 0) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						}
					}
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}

			if (next.GetComponent<DialogManager> ().ifEnd == true && !start) 
			{
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				end = true;
				anim.GetComponent<Animator> ().SetBool ("eat", true);
				StartCoroutine (Wait ());
			}
		}
		if (Input.GetKeyDown (KeyCode.Return) && startCor) 
		{
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			dia.SetActive (false);
			startCor = false;
			whatNow = true;
			player.GetComponent<Animator> ().SetBool ("cho", false);
			GameObject.Find ("IldarSound").GetComponent<AudioSource> ().Pause();
			GameObject.Find ("Smart").GetComponent<AudioSource> ().Play(0);
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
		yield return new WaitForSeconds (1.2f);
		if (!startCor) 
		{
			player.GetComponent<Animator> ().SetBool ("up", false);
			player.GetComponent<Animator> ().SetBool ("down", false);
			player.GetComponent<Animator> ().SetBool ("right", false);
			player.GetComponent<Animator> ().SetBool ("left", false);
			player.GetComponent<Animator> ().SetBool ("cho", true);
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			dia.SetActive (true);
			GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
			GameObject.Find ("Text").GetComponent<Text> ().text = "Кажется я слышала какие-то звуки на складе.";
			startCor = true;
		}
	}
}
