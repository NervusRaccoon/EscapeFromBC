using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindUniform : MonoBehaviour 
{
	private bool start = true;
	private bool end = false;
	private bool startCor = false;
	public GameObject dia;
	private GameObject player;
	private Animator anim;
	public GameObject text;
	public GameObject next;
	private bool ifPlayer;
	public bool goFindUniform = false;

	void Start()
	{
		dia.SetActive (false);
		anim = GameObject.Find("CoWorker").GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
		anim.SetBool ("flag", true);
	}

	void Update()
	{
		if (GameObject.Find("StartPanel").GetComponent<StartGame>().startG && !goFindUniform) 
		{
			if (Input.GetKeyDown (KeyCode.F) && start && ifPlayer) 
			{
				anim.SetBool ("flag", false);
				start = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}

			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
			{
				if (next.GetComponent<DialogManager> ().ifEnd == false) 
				{
					if (next.GetComponent<DialogManager> ().sentences.Count % 2 != 0 && next.GetComponent<DialogManager> ().endOfPrinting) 
					{
						GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
					}
					if (next.GetComponent<DialogManager> ().sentences.Count % 2 == 0 && next.GetComponent<DialogManager> ().endOfPrinting) 
					{
						GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
					}	
					if (next.GetComponent<DialogManager> ().sentences.Count >= 4 && next.GetComponent<DialogManager> ().endOfPrinting) 
					{
						anim.SetBool ("angry", false);
						anim.SetBool ("brov", false);
					}
					if (next.GetComponent<DialogManager> ().sentences.Count < 4 && next.GetComponent<DialogManager> ().endOfPrinting) 
					{
						anim.SetBool ("brov", true);
					}	
					if (next.GetComponent<DialogManager> ().sentences.Count == 3 && next.GetComponent<DialogManager> ().endOfPrinting) 
					{
						GameObject.Find ("Meltdown").GetComponent<AudioSource> ().Pause ();
						GameObject.Find ("Joker").GetComponent<AudioSource> ().Play (0);
					}
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}
			if (next.GetComponent<DialogManager> ().ifEnd == true && !start && !end) 
			{
				anim.SetBool ("angry", false);
				anim.SetBool ("brov", false);
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				StartCoroutine (Wait ());
				end = true;
				anim.SetBool ("flag", true);
			}
		}
		if (Input.GetKeyDown (KeyCode.Return) && startCor) 
		{
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			dia.SetActive (false);
			goFindUniform = true;
			startCor = false;
			player.GetComponent<Animator> ().SetBool ("cho", false);
			GameObject.Find ("Joker").GetComponent<AudioSource> ().Pause ();
			GameObject.Find ("Meltdown").GetComponent<AudioSource> ().Play (0);
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
		yield return new WaitForSeconds (1.4f);
		if (!startCor) 
		{
			player.GetComponent<Animator> ().SetBool ("up", false);
			player.GetComponent<Animator> ().SetBool ("down", false);
			player.GetComponent<Animator> ().SetBool ("right", false);
			player.GetComponent<Animator> ().SetBool ("left", false);
			player.GetComponent<Animator> ().SetBool ("cho", true);
			startCor = true;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			dia.SetActive (true);
			GameObject.Find ("Name").GetComponent<Text> ().text = "Котерина";
			GameObject.Find ("Text").GetComponent<Text> ().text = "Бля, и тут всё через жопу.";
		}
	}
}
