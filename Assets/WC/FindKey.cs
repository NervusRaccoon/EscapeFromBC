using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindKey: MonoBehaviour {

	private bool start = true;
	public GameObject dia;
	private GameObject player;
	private Animator anim;
	public GameObject text;
	private bool ifPlayer = false;
	public bool getKey = false;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		anim = GameObject.Find("FindK").GetComponent<Animator> ();
	}

	void Update()
	{
		if (ifPlayer && start && GameObject.Find ("RestroomDoor2").GetComponent<OpenedDoor> ().opened)
		{				
			Debug.Log ("Я туть");
			anim.SetBool ("noKey", true);
			dia.SetActive (true);
			GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
			text.GetComponent<DialogTrigger> ().TriggerDialog ();
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		
			if (Input.GetKeyDown (KeyCode.Return)) 
			{
				dia.SetActive (false);
				getKey = true;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				start = false;
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
}
