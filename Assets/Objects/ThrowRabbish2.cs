using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowRabbish2 : MonoBehaviour {

	private GameObject player;
	private bool ifPlayer = false;
	private Animator anim;
	private Animator animTrash;
	private GameObject trash1;
	private GameObject trash2;
	private GameObject trash3;
	private GameObject trash4;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		anim = player.GetComponent<Animator>();
		animTrash = GameObject.Find ("TrashCan2").GetComponent<Animator>();
		trash1 = GameObject.Find ("Rabbish1");
		trash2 = GameObject.Find ("Rabbish2");
		trash3 = GameObject.Find ("Rabbish3");
		trash4 = GameObject.Find ("Rabbish4");
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.F) && ifPlayer && trash1.GetComponent<GetRabbishFor1> ().takeRubbish) 
		{
			animTrash.SetBool ("trash", true);
			trash1.GetComponent<GetRabbishFor1> ().takeRubbish = false;
			GameObject.Find("TrashCan1").GetComponent<ThrowRabbish>().count += 1;
			anim.SetBool("tray", false);
			Debug.Log ("Выбросил мусор со столика 1");
		}
		if (Input.GetKeyDown (KeyCode.F) && ifPlayer && trash2.GetComponent<GetRabbish2> ().takeRubbish) 
		{
			animTrash.SetBool ("trash", true);
			GameObject.Find("TrashCan1").GetComponent<ThrowRabbish>().count += 1;
			trash2.GetComponent<GetRabbish2> ().takeRubbish = false;
			anim.SetBool("tray", false);
			Debug.Log ("Выбросил мусор со столика 2");
		}
		if (Input.GetKeyDown (KeyCode.F) && ifPlayer && trash3.GetComponent<GetRabbish3> ().takeRubbish) 
		{
			animTrash.SetBool ("trash", true);
			GameObject.Find("TrashCan1").GetComponent<ThrowRabbish>().count += 1;
			trash3.GetComponent<GetRabbish3> ().takeRubbish = false;
			anim.SetBool("tray", false);
			Debug.Log ("Выбросил мусор со столика 3");
		}
		if (Input.GetKeyDown (KeyCode.F) && ifPlayer && trash4.GetComponent<GetRabbish> ().takeRubbish) 
		{
			animTrash.SetBool ("trash", true);
			GameObject.Find("TrashCan1").GetComponent<ThrowRabbish>().count += 1;
			trash4.GetComponent<GetRabbish> ().takeRubbish = false;
			anim.SetBool("tray", false);
			Debug.Log ("Выбросил мусор со столика 4");
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
