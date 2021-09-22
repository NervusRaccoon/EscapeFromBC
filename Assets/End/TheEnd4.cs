using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TheEnd4 : MonoBehaviour 
{
	private bool startCor = true;
	private bool endOfDark = false;
	public GameObject darkness;
	public GameObject endImg;

	void Update()
	{
		if (GameObject.Find("Ildar").GetComponent<LastDialogIldar> ().TheEnd)
		{
			if (!endOfDark)
				StartCoroutine (Dark ());
		}
	}
	IEnumerator Dark()
	{
		if (startCor) 
		{
			startCor = false;
			darkness.GetComponent<Darkness> ().dark = true;
			yield return new WaitForSeconds (0.5f);
			endImg.SetActive (true);
			darkness.GetComponent<Darkness> ().dark = false;
			yield return new WaitForSeconds (3f);
			endOfDark = true;
		}
	}
}
