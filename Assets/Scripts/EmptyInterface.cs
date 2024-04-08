using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speak : MonoBehaviour {
	public TextMeshPro speech;
	private bool talked = false;
	private int lineNum = 0;
	public string[] words;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (talked) {
			StopCoroutine ("OneLetter");
			lineNum++;
			if (lineNum >= words.Length) {
				lineNum = 0;
			}
		}
		talked = false;
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			StartCoroutine ("OneLetter");

		}
	}

	//void OnTriggerExit2D(Collider2D other) {
	//if (other.CompareTag ("Player")) {
	//StopCoroutine ("OneLetter");
	//talked = true;
	//}
	//}

	IEnumerator OneLetter(){
		int i = 0;
		speech.text = "";
		while (speech.text.Length < words [lineNum].Length) {
			speech.text += words [lineNum] [i];
			i++;
			yield return new WaitForSeconds (.01f);
		}
		if (speech.text.Length == words [lineNum].Length) {
			//StopCoroutine ("OneLetter");
			talked = true;
		}
	}
}
