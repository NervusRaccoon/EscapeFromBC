using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheEnd1 : MonoBehaviour 
{
	private bool start = true;
	private bool endOfDark = false;
	private bool end = false;
	public GameObject darkness;
	public GameObject dia;
	private GameObject player;
	public GameObject text1;
	public GameObject next;
	public GameObject endImg;
	public GameObject lose;

	void Update()
	{
		if (GameObject.Find("FightPanel").GetComponent<Fight> ().TheEnd1 && !end)
		{
			if (!endOfDark) 
			{
				GameObject.Find ("NoEnd").GetComponent<AudioSource> ().Play(0);
				StartCoroutine (Dark ());
			}
			if (endOfDark)
			{
				if (start) 
				{
					start = false;
					dia.SetActive (true);
					GameObject.Find ("Name").GetComponent<Text> ().text = "Незнакомец";
					text1.GetComponent<DialogTrigger> ().TriggerDialog ();
				}

				if (Input.GetKeyDown (KeyCode.Return)) 
				{
					if (next.GetComponent<DialogManager> ().ifEnd == false) 
					{
						if (next.GetComponent<DialogManager> ().endOfPrinting)
						{
							if (next.GetComponent<DialogManager> ().sentences.Count == 1) 
							{
								GameObject.Find ("Name").GetComponent<Text> ().text = "System";
							}
						}	
						next.GetComponent<DialogManager> ().DisplayNextSentence ();
					}
				}

				if (next.GetComponent<DialogManager> ().ifEnd == true && !start) 
				{
					dia.SetActive (false);
					end = true;
					darkness.GetComponent<Darkness> ().dark = true;
				}
			}
		}
	}
	IEnumerator Dark()
	{
		darkness.GetComponent<Darkness> ().dark = true;
		yield return new WaitForSeconds (0.5f);
		lose.SetActive (false);
		endImg.SetActive (true);
		darkness.GetComponent<Darkness> ().dark = false;
		yield return new WaitForSeconds (0.5f);
		endOfDark = true;
	}
}
