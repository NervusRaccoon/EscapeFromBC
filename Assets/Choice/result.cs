using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class result : MonoBehaviour 
{
	private bool start = true;
	public bool endOfRomantic = false;
	private bool startSound = false;
	private bool startCor = false;
	public GameObject dia;
	private GameObject player;
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject next;
	public GameObject im1;
	public GameObject im2;
	public GameObject im3;
	public GameObject darkness;

	void Update()
	{
		if (GameObject.Find("CoWorker").GetComponent<GoResultOfChoice>().goRes && !endOfRomantic)
		{
			if (!startSound)
			{
				startSound = true;
				im1.SetActive (true);
				GameObject.Find ("Meltdown").GetComponent<AudioSource> ().Pause();
				GameObject.Find ("Eat").GetComponent<AudioSource> ().Play (0);
				StartCoroutine (Wait ());
			}
			//love
			if (startCor)
			{
				if (GameObject.Find("Choice").GetComponent<Choice2>().ch1 == true)
				{
					if (start) 
					{
						im1.SetActive (true);
						start = false;
						dia.SetActive (true);
						GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						text1.GetComponent<DialogTrigger> ().TriggerDialog ();
					}

					if (Input.GetKeyDown (KeyCode.Return)) 
					{
						if (next.GetComponent<DialogManager> ().ifEnd == false) 
						{
							if (next.GetComponent<DialogManager> ().endOfPrinting)
							{
								if (next.GetComponent<DialogManager> ().sentences.Count == 9
									|| next.GetComponent<DialogManager> ().sentences.Count == 1) 
								{
									GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
								}
								else
								{
									GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
								}
								if (next.GetComponent<DialogManager> ().sentences.Count == 9) 
								{
									im1.SetActive (true);
								}
								if (next.GetComponent<DialogManager> ().sentences.Count <= 8 && next.GetComponent<DialogManager> ().sentences.Count >= 6) 
								{
									im1.SetActive (false);
									im2.SetActive (true);
								}
								if (next.GetComponent<DialogManager> ().sentences.Count <= 5) 
								{
									im2.SetActive (false);
									im3.SetActive (true);
								}
							}	
							next.GetComponent<DialogManager> ().DisplayNextSentence ();
						}
					}

					if (next.GetComponent<DialogManager> ().ifEnd == true && !start) 
					{
						dia.SetActive (false);
						endOfRomantic = true;
						//darkness.GetComponent<Darkness> ().dark = false;
					}
				}
				//friends
				if (GameObject.Find("Choice").GetComponent<Choice2>().ch2 == true 
					&& GameObject.Find("Choice").GetComponent<Choice>().ch1 == true)
				{
					if (start) 
					{
						start = false;
						dia.SetActive (true);
						GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
						text2.GetComponent<DialogTrigger> ().TriggerDialog ();
						im1.SetActive (true);
					}

					if (Input.GetKeyDown (KeyCode.Return)) 
					{
						if (next.GetComponent<DialogManager> ().ifEnd == false) 
						{
							if (next.GetComponent<DialogManager> ().endOfPrinting)
							{
								if (next.GetComponent<DialogManager> ().sentences.Count == 1) 
								{
									GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
								}
								else
								{
									GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
								}
								if (next.GetComponent<DialogManager> ().sentences.Count == 3) 
								{
									im1.SetActive (true);
								}
								if (next.GetComponent<DialogManager> ().sentences.Count < 3) 
								{
									im1.SetActive (false);
									im2.SetActive (true);
								}
							}		
							next.GetComponent<DialogManager> ().DisplayNextSentence ();
						}
					}

					if (next.GetComponent<DialogManager> ().ifEnd == true && !start) 
					{
						dia.SetActive (false);
						endOfRomantic = true;
						//darkness.GetComponent<Darkness> ().dark = false;
					}
				}
				//nothing
				if (GameObject.Find("Choice").GetComponent<Choice2>().ch2 == true 
					&& GameObject.Find("Choice").GetComponent<Choice>().ch2 == true)
				{
					if (start) 
					{
						start = false;
						dia.SetActive (true);
						GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
						text3.GetComponent<DialogTrigger> ().TriggerDialog ();
						im1.SetActive (true);
					}

					if (Input.GetKeyDown (KeyCode.Return)) 
					{
						if (next.GetComponent<DialogManager> ().ifEnd == false) 
						{
							if (next.GetComponent<DialogManager> ().endOfPrinting)
							{
								if (next.GetComponent<DialogManager> ().sentences.Count == 1)
								{
									GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
								}
								if (next.GetComponent<DialogManager> ().sentences.Count == 2) 
								{
									GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
								}
							}
								next.GetComponent<DialogManager> ().DisplayNextSentence ();
						}
					}

					if (next.GetComponent<DialogManager> ().ifEnd == true && !start) 
					{
						dia.SetActive (false);
						endOfRomantic = true;
						//darkness.GetComponent<Darkness> ().dark = false;
					}
				}
			}
		}
	}
	IEnumerator Wait()
	{
		if (!startCor)
		{
			yield return new WaitForSeconds (3f);
			startCor = true;
		}
	}
}
