using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoPuddle : MonoBehaviour 
{
	private bool start = true;
	private bool ifPlayer;
	public bool noPuddle = false;
	private GameObject player;
	private Animator anim;
	public GameObject img;

	void Start()
	{
		player = GameObject.Find ("Kotya");
		anim = player.GetComponent<Animator> ();
	}

	void Update()
	{
		if (GameObject.Find ("Uniform").GetComponent<GetMop> ().withMop == true && !noPuddle) 
		{
			if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start) 
			{
				start = false;
				noPuddle = true;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
				StartCoroutine(Wait ());
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
		anim.SetBool("up", false);
		anim.SetBool("down", false);
		anim.SetBool("right", false);
		anim.SetBool("left", false);
		anim.SetBool("wipe", true);
		yield return new WaitForSeconds (5f);
		anim.SetBool("wipe", false);
		img.SetActive(false);
		player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}

}
