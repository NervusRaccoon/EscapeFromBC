using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondDialog : MonoBehaviour 
{
	private bool start = true;
	private bool startCor = false;
	private bool loh = false;
	private bool end = false;
	private bool pos1 = false;
	public GameObject dia;
	private Animator anim;
	private GameObject player;
	public GameObject text;
	public GameObject next;
	public GameObject puddle;
	private bool ifPlayer;
	public bool createPuddle = false;
	public GameObject C;
	private float step1 = 0;
	private float step2 = 0;

	void Start()
	{
		anim = GameObject.Find("CoWorker").GetComponent<Animator> ();
		puddle.SetActive (false);
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("Uniform").GetComponent<YesFindUniform> ().KotReady == true && !createPuddle) 
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
				if (next.GetComponent<DialogManager> ().ifEnd == false && !loh) 
				{
					if (next.GetComponent<DialogManager> ().endOfPrinting) 
					{
						if (next.GetComponent<DialogManager> ().sentences.Count % 2 == 0) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count % 2 != 0) 
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count >= 5)
						{
							anim.SetBool("brov", false);
							anim.SetBool("angry", false);
						}
						if (next.GetComponent<DialogManager> ().sentences.Count <= 3)
						{
							anim.SetBool("angry", true);
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 4) 
						{
							GameObject.Find ("Meltdown").GetComponent<AudioSource> ().Pause ();
							GameObject.Find ("Joker").GetComponent<AudioSource> ().Play (0);
							anim.SetBool("brov", false);
							anim.SetBool("angry", false);
							loh = true;
							StartCoroutine (Loser ());
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
				end = true;
				//while (C.transform.position.x != 26.5f && C.transform.position.y != -12.8f)
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				StartCoroutine (Wait());
				//createPuddle = true;
			}
		}
		if (Input.GetKeyDown (KeyCode.Return) && startCor) 
		{
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			dia.SetActive (false);
			startCor = false;
			createPuddle = true;
			player.GetComponent<Animator> ().SetBool ("cho", false);
		}
		if (end) 
		{
			Animator animC = C.GetComponent<Animator> ();
			Vector3 startPos = C.transform.position;
			Vector3 pos = new Vector3 (C.transform.position.x, -12.8f, 0);
			Vector3 endPos = new Vector3 (25.5f, -12.8f, 0);
			if (C.transform.position == pos)
				pos1 = true;
			if (!pos1) 
			{
				animC.SetBool ("up", true);
				C.transform.position = Vector2.Lerp(startPos, pos, step1);
				step1 += 0.001f;
			}
			else 
			{
				animC.SetBool ("up", false);
				animC.SetBool ("left", true);
				C.transform.position = Vector2.Lerp(pos, endPos, step2);
				step2 += 0.0005f;
			}
			if (C.transform.position == endPos)
			{
				animC.SetBool ("left", false);
				end = false;
				GameObject.Find ("Joker").GetComponent<AudioSource> ().Pause ();
				GameObject.Find ("Meltdown").GetComponent<AudioSource> ().Play (0);
			}
		}
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds (1.4f);
		if (!startCor) 
		{
			Debug.Log ("СтартКоротину");
			player.GetComponent<Animator> ().SetBool ("up", false);
			player.GetComponent<Animator> ().SetBool ("down", false);
			player.GetComponent<Animator> ().SetBool ("right", false);
			player.GetComponent<Animator> ().SetBool ("left", false);
			player.GetComponent<Animator> ().SetBool ("cho", true);
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			dia.SetActive (true);
			GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
			GameObject.Find ("Text").GetComponent<Text> ().text = "Снова мне всё разгребать.";
			startCor = true;
			Debug.Log ("ЕндКоротину");
		}
	}
	IEnumerator Loser()
	{
		dia.SetActive (false);
		anim.SetBool ("loh", true);
		yield return new WaitForSeconds (3f);
		puddle.SetActive (true);
		anim.SetBool ("loh", false);
		anim.SetBool ("angry", true);
		dia.SetActive (true);
		loh = false;
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
