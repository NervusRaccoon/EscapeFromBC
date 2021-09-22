using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmFirst : MonoBehaviour 
{
	private bool start = true;
	private bool end = false;
	private bool startCor = false;
	public bool fight = false;
	public GameObject Ildar;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	public GameObject textCor;
	public GameObject img;
	private Animator anim;
	public GameObject next;
	private bool ifPlayer;

	void Start()
	{
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
		anim = img.GetComponent<Animator> ();
		img.SetActive (false);
	}

	void Update()
	{
		if (Ildar.GetComponent<EatNugg> ().whatNow && !end) 
		{
			img.SetActive (true);
			if (Input.GetKeyDown (KeyCode.F) && start && ifPlayer) 
			{
				start = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				GameObject.Find ("Smart").GetComponent<AudioSource> ().Pause();
				GameObject.Find ("SmugglerSound").GetComponent<AudioSource> ().Play(0);
			}
				
			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
			{
				if (next.GetComponent<DialogManager> ().ifEnd == false) 
				{
					if (next.GetComponent<DialogManager> ().endOfPrinting) 
					{
						if (next.GetComponent<DialogManager> ().sentences.Count == 4 || next.GetComponent<DialogManager> ().sentences.Count == 2
							|| next.GetComponent<DialogManager> ().sentences.Count == 1) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Константин";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 5 || next.GetComponent<DialogManager> ().sentences.Count == 3) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 1) 
						{
							anim.SetBool ("angry", true);
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
				StartCoroutine (Wait ());
			}
		}

		if (startCor && !fight) 
		{
			if (Input.GetKeyDown (KeyCode.Return)) 
			{
				if (next.GetComponent<DialogManager> ().ifEnd == false) 
				{
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}

			if (next.GetComponent<DialogManager> ().ifEnd == true && !fight) 
			{
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				fight = true;
				startCor = false;
				player.GetComponent<Animator> ().SetBool ("cho", false);
				GameObject.Find ("SmugglerSound").GetComponent<AudioSource> ().Pause();
				GameObject.Find ("Fight").GetComponent<AudioSource> ().Play(0);
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
			textCor.GetComponent<DialogTrigger> ().TriggerDialog ();
			startCor = true;
		}
	}
}
