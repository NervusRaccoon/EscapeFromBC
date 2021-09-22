using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GDoor : MonoBehaviour {

	private bool start = false;
	public GameObject dia;
	private GameObject player;
	private Animator anim;
	public GameObject text;
	public Collider2D doorColl;
	private bool ifPlayer = false;

	void Start () 
	{
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.F) && ifPlayer && !start) 
		{
			start = true;
			Debug.Log ("Открывай мраз");
			dia.SetActive (true);
			GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
			text.GetComponent<DialogTrigger> ().TriggerDialog ();
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		}

		if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && start) 
		{
			Debug.Log ("Я открыл");
			dia.SetActive (false);
			anim.SetBool ("open", true);
			doorColl.enabled = false;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
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
}
