using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheEnd2 : MonoBehaviour 
{
	private bool start = true;
	private bool startCor = true;
	private bool endOfDark = false;
	private bool end = false;
	public GameObject darkness;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	public GameObject next;
	public GameObject endImg;

	void Update()
	{
		if (GameObject.Find("Choice").GetComponent<Choice3> ().ch1 && !end)
		{
			if (!endOfDark)
				StartCoroutine (Dark ());
			if (endOfDark)
			{
				if (start) 
				{
					start = false;
					dia.SetActive (true);
					GameObject.Find ("Name").GetComponent<Text> ().text = "Новости";
					text.GetComponent<DialogTrigger> ().TriggerDialog ();
				}

				if (Input.GetKeyDown (KeyCode.Return)) 
				{
					if (next.GetComponent<DialogManager> ().ifEnd == false) 
					{
						if (next.GetComponent<DialogManager> ().endOfPrinting)
						{
							if (next.GetComponent<DialogManager> ().sentences.Count < 3) 
							{
								GameObject.Find ("Name").GetComponent<Text> ().text = "Константин";
							}
						}	
						next.GetComponent<DialogManager> ().DisplayNextSentence ();
					}
				}

				if (next.GetComponent<DialogManager> ().ifEnd == true && !start) 
				{
					dia.SetActive (false);
					end = true;
					//darkness.GetComponent<Darkness> ().dark = true;
				}
			}
		}
	}
	IEnumerator Dark()
	{
		if (startCor) 
		{
			startCor = false;
			darkness.GetComponent<Darkness> ().dark = true;
			yield return new WaitForSeconds (0.5f);
			endImg.SetActive (true);
			darkness.GetComponent<Darkness> ().dark = false;
			yield return new WaitForSeconds (3f);
			endOfDark = true;
		}
	}
}
