using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoResultOfChoice : MonoBehaviour 
{
	private bool start = true;
	private GameObject player;
	private Animator anim;
	private bool ifPlayer;
	private GameObject panel;
	public bool goRes = false;
	public GameObject darkness;


	void Start()
	{
		panel = GameObject.Find ("Romantic");
		panel.SetActive (false);
		anim = GameObject.Find("CoWorker").GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if ((GameObject.Find("Choice").GetComponent<Choice>().ch1 == true || GameObject.Find("Choice").GetComponent<Choice>().ch2 == true) 
			&& (GameObject.Find("Choice").GetComponent<Choice2>().ch1 == true || GameObject.Find("Choice").GetComponent<Choice2>().ch2 == true))
		{
			if (Input.GetKeyDown (KeyCode.F) && start && ifPlayer) 
			{
				StartCoroutine (Dark());
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
	//ещё будет анимация с IEnumerator Wait()

	IEnumerator Dark()
	{
		start = false;
		player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
		anim.SetBool("change", true);
		yield return new WaitForSeconds (3f);
		anim.SetBool("right", false);
		anim.SetBool("zad", false);
		anim.SetBool("change", false);
		darkness.GetComponent<Darkness> ().dark = true;
		yield return new WaitForSeconds (0.5f);
		panel.SetActive (true);
		darkness.GetComponent<Darkness> ().dark = false;
		yield return new WaitForSeconds (0.5f);
		goRes = true;
	}


}
