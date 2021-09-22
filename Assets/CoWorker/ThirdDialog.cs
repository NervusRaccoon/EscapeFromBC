using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdDialog : MonoBehaviour 
{
	private bool start = true;
	private bool end = false;
	private bool startCor = false;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	private Animator anim;
	public GameObject next;
	private bool ifPlayer;
	public bool goTakeRag = false;

	void Start()
	{
		anim = GameObject.Find("CoWorker").GetComponent<Animator> ();
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("Puddle").GetComponent<NoPuddle> ().noPuddle == true && !goTakeRag) 
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
						if (next.GetComponent<DialogManager> ().sentences.Count == 6
						    || next.GetComponent<DialogManager> ().sentences.Count == 4
						    || next.GetComponent<DialogManager> ().sentences.Count == 1) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 5
						    || next.GetComponent<DialogManager> ().sentences.Count == 3
						    || next.GetComponent<DialogManager> ().sentences.Count == 2) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count >= 4)
						{
							anim.SetBool("brov", false);
							anim.SetBool("angry", false);
						}
						else
						{
							if (next.GetComponent<DialogManager> ().sentences.Count == 3)
							{
								GameObject.Find ("Meltdown").GetComponent<AudioSource> ().Pause ();
								GameObject.Find ("Joker").GetComponent<AudioSource> ().Play (0);
								anim.SetBool("brov", true);
							}
							else
							{
								anim.SetBool("brov", false);
								anim.SetBool("angry", false);
							}
						}	
					}	
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}

			if (next.GetComponent<DialogManager> ().ifEnd == true && !start && !end) 
			{
				anim.SetBool("brov", false);
				anim.SetBool("angry", false);
				anim.SetBool ("flag", true);
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				StartCoroutine (Wait ());
				end = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.Return) && startCor) 
		{
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			dia.SetActive (false);
			goTakeRag = true;
			startCor = false;
			player.GetComponent<Animator> ().SetBool ("cho", false);
			GameObject.Find ("Joker").GetComponent<AudioSource> ().Pause ();
			GameObject.Find ("Meltdown").GetComponent<AudioSource> ().Play (0);
		}
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
			GameObject.Find ("Text").GetComponent<Text> ().text = "Он либо еблан, либо украинец, другого не дано.";
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
