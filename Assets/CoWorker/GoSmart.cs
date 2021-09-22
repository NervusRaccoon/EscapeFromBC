using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoSmart : MonoBehaviour 
{
	private bool start = true;
	private bool end = false;
	public bool smart = false;
	private bool startCor = false;
	private bool endOfDark = false;
	private GameObject C;
	public GameObject Romantic;
	public GameObject dia;
	private GameObject player;
	private Animator anim;
	private bool ifPlayer;
	public GameObject panel;
	public GameObject darkness;
	public GameObject text;
	public GameObject next;
	private float step1 = 0;
	private float step2 = 0;
	private bool pos1 = false;
	private bool pos2 = false;

	void Start()
	{
		anim = GameObject.Find("CoWorker").GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
		C = GameObject.Find ("CoWorker");
	}

	void Update()
	{
		if (Romantic.GetComponent<result>().endOfRomantic == true && !smart)
		{
			if (!endOfDark)
			{
				GameObject.Find ("Eat").GetComponent<AudioSource> ().Pause();
				GameObject.Find ("Smart").GetComponent<AudioSource> ().Play (0);
				StartCoroutine (Dark ());
			}
			if (endOfDark && darkness.GetComponent<Darkness> ().change)
			{
				if (start)
				{
					start = false;
					dia.SetActive (true);
					GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
					text.GetComponent<DialogTrigger> ().TriggerDialog ();
				}

				if (Input.GetKeyDown (KeyCode.Return) && ifPlayer) 
				{
					if (next.GetComponent<DialogManager> ().ifEnd == false) 
					{
						if (next.GetComponent<DialogManager> ().sentences.Count % 2 == 0 && next.GetComponent<DialogManager> ().endOfPrinting) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count % 2 != 0 && next.GetComponent<DialogManager> ().endOfPrinting) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						}	
						if (next.GetComponent<DialogManager> ().sentences.Count == 24 || next.GetComponent<DialogManager> ().sentences.Count == 14 && next.GetComponent<DialogManager> ().endOfPrinting) 
						{
							anim.SetBool ("angry", false);
							anim.SetBool ("brov", false);
						}
						if ((next.GetComponent<DialogManager> ().sentences.Count <= 22 && next.GetComponent<DialogManager> ().sentences.Count >= 17) 
							|| (next.GetComponent<DialogManager> ().sentences.Count <= 12 && next.GetComponent<DialogManager> ().sentences.Count >= 5) && next.GetComponent<DialogManager> ().endOfPrinting) 
						{
							anim.SetBool ("angry", false);
							anim.SetBool ("smart", true);
						}	
						if (next.GetComponent<DialogManager> ().sentences.Count == 16 
							|| (next.GetComponent<DialogManager> ().sentences.Count <= 4 && next.GetComponent<DialogManager> ().sentences.Count >= 1) && next.GetComponent<DialogManager> ().endOfPrinting) 
						{
							anim.SetBool ("smart", false);
							anim.SetBool ("angry", true);
						}	
						next.GetComponent<DialogManager> ().DisplayNextSentence ();
					}
				}
				if (next.GetComponent<DialogManager> ().ifEnd == true && !start && !end) 
				{
					anim.SetBool ("angry", false);
					anim.SetBool ("brov", false);
					anim.SetBool ("smart", false);
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
				smart = true;
				startCor = false;
				player.GetComponent<Animator> ().SetBool ("cho", false);
			}
		}
		if (end && !pos2) 
		{
			Animator animC = C.GetComponent<Animator> ();
			Vector3 startPos = C.transform.position;
			Vector3 pos = new Vector3 (27.5f, C.transform.position.y, 0);
			Vector3 endPos = new Vector3 (27.5f, -7.57f, 0);
			if (C.transform.position == pos)
				pos1 = true;
			if (!pos1) 
			{
				animC.SetBool ("right", true);
				C.transform.position = Vector2.Lerp(startPos, pos, step1);
				step1 += 0.001f;
			}
			else 
			{
				animC.SetBool ("right", false);
				animC.SetBool ("down", true);
				C.transform.position = Vector2.Lerp(pos, endPos, step2);
				step2 += 0.0005f;
			}
			if (C.transform.position == endPos)
			{
				animC.SetBool ("down", false);
				pos2 = true;
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

	IEnumerator Dark()
	{
		darkness.GetComponent<Darkness> ().dark = true;
		yield return new WaitForSeconds (0.5f);
		darkness.GetComponent<Darkness> ().dark = false;
		Romantic.SetActive (false);
		yield return new WaitForSeconds (0.5f);
		//panel.SetActive (false);
		endOfDark = true;
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (1f);
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
			GameObject.Find ("Text").GetComponent<Text> ().text = "Звучит как рофл, но мне кажется или всё дело в бургере?";
		}
	}

}
