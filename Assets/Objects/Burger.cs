using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Burger : MonoBehaviour 
{
	private bool start = true;
	private bool dialog = true;
	private bool startCor = false;
	public GameObject Ildar;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	public GameObject textConst;
	public GameObject next;
	private bool ifPlayer;

	void Start()
	{
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (Ildar.GetComponent<NoDia>().goFindNaggets && dialog) 
		{
			if (Input.GetKeyDown (KeyCode.F) && start && ifPlayer) 
			{
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
					next.GetComponent<DialogManager> ().DisplayNextSentence ();
				}
			}
			if (next.GetComponent<DialogManager> ().ifEnd == true && !start && !startCor && dialog) 
			{
				dia.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				start = true;
				if (GameObject.Find ("Choice").GetComponent<Choice> ().ch1) 
				{
					StartCoroutine(Wait ());
				} 
				else
					dialog = false;	
			}
		}
		if (Input.GetKeyDown (KeyCode.Return) && startCor) 
		{
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
			dia.SetActive (false);
			startCor = false;
			dialog = false;
			player.GetComponent<Animator> ().SetBool ("cho", false);
		}
		if (!dialog) 
		{
			if (Input.GetKeyDown (KeyCode.F) && start && ifPlayer) 
			{
				start = false;
				dia.SetActive (true);
				GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
				textConst.GetComponent<DialogTrigger> ().TriggerDialog ();
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
			}
			if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && !start) 
			{	
				dia.SetActive (false);
				dialog = false;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				start = true;
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
			GameObject.Find ("Text").GetComponent<Text> ().text = "Странно, я вроде ел бургер, но всё ещё тупой...точнее, со мной всё в порядке.";
		}
	}
}
