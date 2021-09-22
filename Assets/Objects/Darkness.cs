using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Darkness : MonoBehaviour {

	public bool dark = false;
	public bool change = false;
	private GameObject p1;
	private GameObject p2;
	private GameObject p3;
	private GameObject p4;
	private GameObject p;

	void Start () 
	{
		p = GameObject.Find ("Panel");
		p1 = GameObject.Find ("Panel1");
		p2 = GameObject.Find ("Panel2");
		p3 = GameObject.Find ("Panel3");
		p4 = GameObject.Find ("Panel4");
		//p.SetActive (false);
		//p1.SetActive (false);
		//p2.SetActive (false);
		//p3.SetActive (false);
		//p4.SetActive (false);
	}

	void Update()
	{
		if (dark && change) 
		{
			StartCoroutine (createDark ());
		}
		if (!dark && !change)
		{
			StartCoroutine (delDark ());
		}	
	}
		
	IEnumerator createDark()
	{
		p.SetActive (true);
		yield return new WaitForSeconds (0.2f);
		p1.SetActive (true);
		yield return new WaitForSeconds (0.2f);
		p2.SetActive (true);
		yield return new WaitForSeconds (0.2f);
		p3.SetActive (true);
		yield return new WaitForSeconds (0.2f);
		p4.SetActive (true);
		change = false;
	}
	IEnumerator delDark()
	{
		p4.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		p3.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		p2.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		p1.SetActive (false);
		yield return new WaitForSeconds (0.2f);
		p.SetActive (false);
		change = true;
	}
}
