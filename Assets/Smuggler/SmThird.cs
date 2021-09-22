using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmThird : MonoBehaviour 
{
	private bool start = true;
	private bool end = false;
	private bool startCor = false;
	public GameObject dia;
	private GameObject player;
	public GameObject text;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find("Choice").GetComponent<Choice3> ().ch2 && !end) 
		{
			if (start) 
			{
				start = false;
				StartCoroutine (Wait ());
			}
				
			if (Input.GetKeyDown (KeyCode.Return) && !start && startCor) 
			{
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				end = true;
			}
		}
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (1.2f);
		if (!startCor) 
		{
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			dia.SetActive (true);
			text.GetComponent<DialogTrigger> ().TriggerDialog ();
			GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
			startCor = true;
		}
	}
}
