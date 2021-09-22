using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice3 : MonoBehaviour 
{
	private bool start = true;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	public GameObject c1;
	public GameObject c2;
	public GameObject choucen1;
	public GameObject choucen2;
	public bool ch1 = false;
	public bool ch2 = false;
	private bool chouse1 = false;
	private bool chouse2 = false;
	private bool ifPlayer;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("Smuggler").GetComponent<SmSecond> ().choice3 && start) 
		{
			dia.SetActive (true);
			GameObject.Find ("Name").GetComponent<Text> ().text = "Константин";
			text.GetComponent<Text> ().text = "Давай дадим эту возможность миру вместе?";
			c1.GetComponent<Text>().text = "Согласиться";
			c2.GetComponent<Text>().text = "Отказаться";
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;

			if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) 
			{
				choucen2.SetActive(false);
				choucen1.SetActive(true);
				chouse1 = true;
				chouse2 = false;
			}

			if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) 
			{
				choucen1.SetActive(false);
				choucen2.SetActive(true);
				chouse2 = true;
				chouse1 = false;
			}

			if (Input.GetKeyDown (KeyCode.Return) && (chouse1 || chouse2)) 
			{
				start = false;
				dia.SetActive (false);
				if (chouse1)
				{
					GameObject.Find ("KEnd").GetComponent<AudioSource> ().Play(0);
					ch1 = true;
				}
				if (chouse2) 
				{
					GameObject.Find ("Smart").GetComponent<AudioSource> ().Play(0);
					ch2 = true;
				}
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
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

}
