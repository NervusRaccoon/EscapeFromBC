using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour 
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
	private GameObject C;
	private float step1 = 0;
	private float step2 = 0;
	private float step3 = 0;
	private bool end = false;
	private bool posC1 = false;
	private bool posC2 = false;

	void Start()
	{
		C = GameObject.Find ("CoWorker");
		choucen1.SetActive (false);
		choucen2.SetActive (false);
		dia.SetActive (false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if (GameObject.Find ("CoWorker").GetComponent<FourthDialog> ().goChoice == true && start) 
		{
			dia.SetActive (true);
			GameObject.Find ("Name").GetComponent<Text> ().text = "Олександер";
			text.GetComponent<Text> ().text = "Сделать тебе бургер?";
			c1.GetComponent<Text>().text = "Да, сделай мне Цезарь Кинг, пожалуйста";
			c2.GetComponent<Text>().text = "Нет, спасибо";
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
				choucen1.SetActive (false);
				choucen2.SetActive (false);
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
				player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				end = true;
			}
		}
		if (end) 
		{
			Animator animC = C.GetComponent<Animator> ();
			Vector3 startPos = C.transform.position;
			Vector3 pos1 = new Vector3 (23.5f, -12.8f, 0);
			Vector3 pos2 = new Vector3 (23.5f, -5.9f, 0);
			Vector3 endPos = new Vector3 (25.5f, -5.9f, 0);
			if (C.transform.position == pos1)
				posC1 = true;
			if (C.transform.position == pos2)
				posC2 = true;
			if (!posC1 && !posC2) 
			{
				animC.SetBool ("left", true);
				C.transform.position = Vector3.Lerp(startPos, pos1, step1);
				step1 += 0.0005f;
			}
			if (posC1 && !posC2)
			{
				animC.SetBool ("left", false);
				animC.SetBool ("up", true);
				C.transform.position = Vector3.Lerp(pos1, pos2, step2);
				step2 += 0.005f;
			}
			if (posC1 && posC2)
			{
				animC.SetBool ("up", false);
				animC.SetBool ("right", true);
				C.transform.position = Vector3.Lerp(pos2, endPos, step3);
				step3 += 0.005f;
			}
			if (C.transform.position == endPos)
			{
				//animC.SetBool ("right", false);
				animC.SetBool ("zad", true);
				end = false;
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
