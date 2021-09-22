using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetRabbishFor1 : MonoBehaviour {

	public bool startDia = true;
	public bool start = true;
	public GameObject dia;
	private GameObject player;
	public GameObject text;
	public GameObject cantTake;
	public GameObject noRag;
	private bool ifPlayer = false;
	private Animator anim;
	public bool takeRubbish = false;
	public GameObject img;
	private GameObject trash1;
	private GameObject trash2;
	private GameObject trash3;
	private GameObject trash4;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		anim = player.GetComponent<Animator> ();
		takeRubbish = false;
		trash1 = GameObject.Find ("Rabbish1");
		trash2 = GameObject.Find ("Rabbish2");
		trash3 = GameObject.Find ("Rabbish3");
		trash4 = GameObject.Find ("Rabbish4");
	}

	void Update()
	{
		if (trash1.GetComponent<GetDiamonds1> ().takeDia1)
		{
			if (GameObject.Find ("Rag").GetComponent<ThirdQuest> ().takeRag) 
			{
				if (trash1.GetComponent<GetRabbishFor1> ().startDia
				    && trash2.GetComponent<GetRabbish2> ().startDia
				    && trash3.GetComponent<GetRabbish3> ().startDia
				    && trash4.GetComponent<GetRabbish> ().startDia) 
				{
					if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start) 
					{
						start = false;
						dia.SetActive (true);
						GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						text.GetComponent<DialogTrigger> ().TriggerDialog ();
						player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
					}

					if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && !start) 
					{
						startDia = false;
						/*takeRubbish = true;
						anim.SetBool("tray", true);
						Debug.Log ("Где анимация ало");
						anim.SetBool ("ragleft", true);*/
						dia.SetActive (false);
						img.SetActive (false);
						/*player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
						player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;*/
						StartCoroutine (Wait ());
						start = true;
					}
				} 
				else 
				{
					if (!trash1.GetComponent<GetRabbishFor1> ().takeRubbish
					    && !trash2.GetComponent<GetRabbish2> ().takeRubbish
					    && !trash3.GetComponent<GetRabbish3> ().takeRubbish
					    && !trash4.GetComponent<GetRabbish> ().takeRubbish)
						if (Input.GetKeyDown (KeyCode.F) && ifPlayer) 
						{
							player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
							img.SetActive (false);
							/*Debug.Log ("Где анимация ало");
							anim.SetBool ("ragleft", true);
							anim.SetBool("tray", true);
							takeRubbish = true;*/
							//anim.SetBool ("ragleft", true);
							StartCoroutine (Wait ());
						}
					if (trash1.GetComponent<GetRabbishFor1> ().takeRubbish
						|| trash2.GetComponent<GetRabbish2> ().takeRubbish
						|| trash3.GetComponent<GetRabbish3> ().takeRubbish
						|| trash4.GetComponent<GetRabbish> ().takeRubbish) 
					{
						if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start) 
						{
							start = false;
							dia.SetActive (true);
							GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
							cantTake.GetComponent<DialogTrigger> ().TriggerDialog ();
							player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
						}

						if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && !start) 
						{
							dia.SetActive (false);
							player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
							player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
							start = true;
						}
					}
				}
			} 
			else 
			{
				if (GameObject.Find ("Puddle").GetComponent<NoPuddle> ().noPuddle) 
				{
					if (Input.GetKeyDown (KeyCode.F) && ifPlayer && start) 
					{
						start = false;
						dia.SetActive (true);
						GameObject.Find ("Name").GetComponent<Text> ().text = "Котярина";
						noRag.GetComponent<DialogTrigger> ().TriggerDialog ();
						player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeAll;
					}

					if (Input.GetKeyDown (KeyCode.Return) && ifPlayer && !start) 
					{
						start = true;
						dia.SetActive (false);
						player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
						player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
					} 
				}
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
		anim.SetBool ("ragleft", true);
		//if (this == trash1)
		yield return new WaitForSeconds (4f);
		//if (this == trash1)
		anim.SetBool ("ragleft", false);
		anim.SetBool("tray", true);
		takeRubbish = true;
		player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.None;
		player.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}
}
