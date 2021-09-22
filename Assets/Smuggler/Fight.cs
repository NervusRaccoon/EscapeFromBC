using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fight : MonoBehaviour 
{
	private bool start = true;
	private bool startCor = true;
	public bool endOfFight = false;
	private bool endOfDark = false;
	public bool TheEnd1 = false;
	public GameObject darkness;
	public GameObject dia;
	private GameObject player;
	public GameObject text1;
	public GameObject text2;
	public GameObject next;
	public GameObject win;
	public GameObject lose;

	void Update()
	{
		if (GameObject.Find("Smuggler").GetComponent<SmFirst>().fight && !endOfFight)
		{
			if (!endOfDark) 
			{
				StartCoroutine (Dark ());
			}
			//win
			if (endOfDark && GameObject.Find("Fork").GetComponent<GetFork>().takeFork)
			{
				if (start) 
				{
					start = false;
					dia.SetActive (true);
					GameObject.Find ("Name").GetComponent<Text> ().text = "Конастантин";
					text1.GetComponent<DialogTrigger> ().TriggerDialog ();
				}

				if (Input.GetKeyDown (KeyCode.Return)) 
				{
					if (next.GetComponent<DialogManager> ().ifEnd == false) 
					{
						if (next.GetComponent<DialogManager> ().endOfPrinting)
						{
							if (next.GetComponent<DialogManager> ().sentences.Count == 3) 
							{
								GameObject.Find ("Name").GetComponent<Text> ().text = "Константин";
							}
							else
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
					endOfFight = true;
					GameObject.Find ("Fight").GetComponent<AudioSource> ().Pause();
					//darkness.GetComponent<Darkness> ().dark = false;
				}
			}
			//lose
			if (endOfDark && !GameObject.Find("Fork").GetComponent<GetFork>().takeFork)
			{
				if (start) 
				{
					start = false;
					dia.SetActive (true);
					GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
					text2.GetComponent<DialogTrigger> ().TriggerDialog ();
				}

				if (Input.GetKeyDown (KeyCode.Return)) 
				{
					if (next.GetComponent<DialogManager> ().ifEnd == false) 
					{
						if (next.GetComponent<DialogManager> ().endOfPrinting)
						{
							lose.SetActive (true);
						}		
						next.GetComponent<DialogManager> ().DisplayNextSentence ();
					}
				}

				if (next.GetComponent<DialogManager> ().ifEnd == true && !start) 
				{
					dia.SetActive (false);
					endOfFight = true;
					TheEnd1 = true;
					GameObject.Find ("Fight").GetComponent<AudioSource> ().Pause();
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
			if (GameObject.Find ("Fork").GetComponent<GetFork> ().takeFork) 
			{
				win.SetActive (true);
			} 
			else 
			{
				lose.SetActive (true);
			}
			darkness.GetComponent<Darkness> ().dark = false;
			yield return new WaitForSeconds (3f);
			endOfDark = true;
		}
	}

}
