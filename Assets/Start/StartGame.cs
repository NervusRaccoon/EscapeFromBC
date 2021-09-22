using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour 
{
	private bool start = true;
	private bool startCor = true;
	private bool startWait = false;
	private bool startDark = true;
	public bool startG = false;
	public GameObject darkness;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	public GameObject next;
	public GameObject img;

	void Start()
	{
		GameObject.Find ("Start").GetComponent<AudioSource> ().Play(0);
		player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
	}

	void Update()
	{
		if (startDark)
		{
			startDark = false;
			darkness.GetComponent<Darkness> ().dark = false;
			StartCoroutine (Wait ());
		}
		if (!startG && startWait)
		{
			if (start) 
			{
				start = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Оля";
				text.GetComponent<DialogTrigger> ().TriggerDialog ();
			}

			if (Input.GetKeyDown (KeyCode.Return)) 
			{
				if (next.GetComponent<DialogManager> ().ifEnd == false) 
				{
					if (next.GetComponent<DialogManager> ().endOfPrinting)
					{
						if (next.GetComponent<DialogManager> ().sentences.Count == 5)
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Оля";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 4)
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Сергей";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 3)
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Магамет";
						}
						if (next.GetComponent<DialogManager> ().sentences.Count == 2 || next.GetComponent<DialogManager> ().sentences.Count == 1)
						{
							GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						}
					}	
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}

			if (next.GetComponent<DialogManager> ().ifEnd == true && !start && !startG) 
			{
				dia.SetActive (false);
				startG = true;
				StartCoroutine (Dark ());
			}
		}
	}
	IEnumerator Dark()
	{
		if (startCor)
		{
			GameObject.Find ("Start").GetComponent<AudioSource> ().Pause();
			GameObject.Find ("Meltdown").GetComponent<AudioSource> ().Play (0);
			startCor = false;
			darkness.GetComponent<Darkness> ().dark = true;
			yield return new WaitForSeconds (0.5f);
			img.SetActive (false);
			darkness.GetComponent<Darkness> ().dark = false;
			yield return new WaitForSeconds (5f);
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}
	IEnumerator Wait()
	{
		if (!startWait)
		{
			yield return new WaitForSeconds (4f);
			startWait = true;
		}
	}

}
