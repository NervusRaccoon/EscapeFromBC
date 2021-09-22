using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public Text dialog;
	public Queue<string> sentences;
	public bool ifEnd = false;
	public bool endOfPrinting = true;
	private string lastSentence;
	private string saveName;

	void Start () 
	{
		sentences = new Queue<string> ();
	}

	public void StartDialog(Dialog dialog)
	{
		ifEnd = false;
		//name.text = dialog.name;

		sentences.Clear ();

		foreach (string sentence in dialog.sentences) 
		{
			sentences.Enqueue (sentence);
		}

		endOfPrinting = true;
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0) 
		{
			EndDialog ();
			return;
		}
		if (endOfPrinting) 
		{
			string sentence = sentences.Dequeue ();
			lastSentence = sentence;
			StartCoroutine (TypeSentence (sentence));
		} 
		else 
		{
			StopAllCoroutines();
			dialog.text = lastSentence;
			//StartCoroutine(Wait ());
			endOfPrinting = true;
		}
	}
		
	IEnumerator TypeSentence(string sentence)
	{
		endOfPrinting = false;
		dialog.text = "";
		int count = 1;
		while (count <= sentence.Length) 
		{
			dialog.text = sentence.Substring (0, count);
			yield return new WaitForSeconds (0.01f);
			count++;
		}
		endOfPrinting = true;
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (0.5f);
		endOfPrinting = true;
	}

	public void EndDialog()
	{
		//Debug.Log("End");
		ifEnd = true;
	}
}
