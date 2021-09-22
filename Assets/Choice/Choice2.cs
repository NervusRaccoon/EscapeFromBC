using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice2 : MonoBehaviour 
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
	private bool ifPlayer;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("Potato").GetComponent<GetPotato> ().takePotato == true && start) 
		{
			dia.SetActive (true);
			GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
			text.GetComponent<Text> ().text = "Поделюсь ли я с Олександером?";
			c1.GetComponent<Text>().text = "Да, думаю он неплохой парень";
			c2.GetComponent<Text>().text = "Нет, он не заслужил";
			player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;

			if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) 
			{
					choucen2.SetActive(false);
					choucen1.SetActive(true);
					ch1 = true;
					ch2 = false;
			}

			if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) 
			{
				choucen1.SetActive(false);
				choucen2.SetActive(true);
				ch2 = true;
				ch1 = false;
			}

			if (Input.GetKeyDown (KeyCode.Return) && (ch1 || ch2)) 
			{
				start = false;
				dia.SetActive (false);
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
