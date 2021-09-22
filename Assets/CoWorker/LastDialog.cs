using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastDialog : MonoBehaviour 
{
	private bool start = true;
	private bool end = false;
	private bool startCor = false;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	private Animator anim;
	private Animator plAnim;
	public GameObject next;
	private bool ifPlayer;
	public bool TheEnd = false;

	void Start()
	{
		anim = GameObject.Find("CoWorker").GetComponent<Animator> ();
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
		plAnim = player.GetComponent<Animator> ();
	}

	void Update()
	{
		if (GameObject.Find ("Choice").GetComponent<Choice3> ().ch2 && !TheEnd) 
		{
			if (Input.GetKeyDown (KeyCode.F) && start && ifPlayer) 
			{				
				GameObject.Find ("Smart").GetComponent<AudioSource> ().Pause();
				GameObject.Find ("OEnd").GetComponent<AudioSource> ().Play(0);
				anim.SetBool("smart", true);
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
					if (next.GetComponent<DialogManager> ().endOfPrinting)
					{
						if (next.GetComponent<DialogManager> ().sentences.Count == 3
						    || next.GetComponent<DialogManager> ().sentences.Count == 1) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 4
						    || next.GetComponent<DialogManager> ().sentences.Count == 2) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 3)
						{
							plAnim.SetBool("cute", true);
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 2)
						{
							anim.SetBool("smart", false);
							anim.SetBool("cute", true);
							anim.SetBool("smex", true);
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 1)
						{
							anim.SetBool("smex", false);
						}	
					}	
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}

			if (next.GetComponent<DialogManager> ().ifEnd == true && !start && !end) 
			{
				dia.SetActive (false);
				TheEnd = true;
				plAnim.SetBool("cute", false);
				end = true;
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
