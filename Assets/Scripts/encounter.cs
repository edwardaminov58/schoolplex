using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class encounter : MonoBehaviour {
	GameObject Dot;
	GameObject Dot2;
	GameObject Dot3;
	//public GameObject Dots;
	public bool textbox = false;
	public DialogueLine[] Text;
	Dictionary<Lines,DialogueLine> DialDict = new Dictionary<Lines, DialogueLine>();
	//bool dots = false;
	Coroutine Dotties = null;


	void Awake(){
		foreach (DialogueLine d in Text)
			DialDict.Add (d.Type, d);
		Dot = GameObject.Find ("Dot");
		Dot2 = GameObject.Find ("Dot2");
		Dot3 = GameObject.Find ("Dot3");
		//Dots = GameObject.FindGameObjectWithTag ("Dots");

	}
	void Start(){


	}

	void OnTriggerEnter (Collider other)
	{
		Dot.SetActive (true);
		Dot2.SetActive (true);
		Dot3.SetActive (true);
		textbox = true;
		StartCoroutine (converse());
		Debug.Log ("ACTIVATE!");
		other.GetComponent<move> ().enabled = false;
		Dotties = StartCoroutine (blinkDots (Dot, Dot2, Dot3));
	}

//	public string Words(){
//		return Text[];
//	}

	IEnumerator blinkDots (GameObject Dot, GameObject Dot2, GameObject Dot3)
	{
		while (true) {
				yield return new WaitForSecondsRealtime (.5f);
				//yield return null;
				Dot.SetActive (false);
				yield return new WaitForSecondsRealtime (.5f);
			//yield return null;
				Dot.SetActive (true);
				Dot2.SetActive (false);
				yield return new WaitForSecondsRealtime(.5f);
			//yield return null;
				Dot2.SetActive (true);
				Dot3.SetActive (false);
				yield return new WaitForSecondsRealtime (.5f);

				Dot3.SetActive (true);
			}
		//yield return null;
	}
//
//	void Update() {
//		if (dots == true)
//			StartCoroutine (blinkDots (Dot, Dot2, Dot3));
//		if (dots == false) {
//			Dot.SetActive (false);
//			Dot2.SetActive (false);
//			Dot3.SetActive (false);
//			StopCoroutine (blinkDots (Dot, Dot2, Dot3));
//		}
//	}
//
	IEnumerator converse () {
		//int n = 0;
		DialogueLine current = Text[0];
		while (current != null) {

			TextBox.Me.Imprint (current.Text);
			//n++;

			if (current.Options.Length > 1) {
				foreach (DialogueOption d in current.Options) {
					Debug.Log (d.Text);
					TextBox.Me.ImprintChoices (d.Text);
				}
				if (current.Options.Length == 2) {
					if (Input.GetKeyDown (KeyCode.Alpha1)) {
						current = DialDict [current.Options [0].Response];

					} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
						current = DialDict [current.Options [1].Response];
					}
				}
				if (current.Options.Length == 3) {
					if (Input.GetKeyDown (KeyCode.Alpha1)) {
						current = DialDict [current.Options [0].Response];

					} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
						current = DialDict [current.Options [1].Response];
					} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
						current = DialDict [current.Options [2].Response];
					}
				}
				if (current.Options.Length == 4) {
					if (Input.GetKeyDown (KeyCode.Alpha1)) {
						current = DialDict [current.Options [0].Response];

					} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
						current = DialDict [current.Options [1].Response];
					} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
						current = DialDict [current.Options [2].Response];
					} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
						current = DialDict [current.Options [3].Response];
					}
				}
			}
			else if (current.Options.Length == 1){
				//dots = false;
				TextBox.Me.ImprintChoices ("");
				Debug.Log ("NULLED");
				if (Input.GetKeyDown (KeyCode.Space)) {
					current = DialDict [current.Options [0].Response];
				}
			} else {
				TextBox.Me.ImprintChoices ("");
				//Dots.SetActive (false);
				StopCoroutine(Dotties);
				Dot.SetActive (false);
				Dot2.SetActive (false);
				Dot3.SetActive (false);
				Debug.Log ("stopped");
				//if (Input.GetKeyDown (KeyCode.Space) && n + 2 > Text.Length)
				if (Input.GetKeyDown (KeyCode.Space)) {
					//n++;
					current = null;


				}
			}
			yield return null;
		}

		TextBox.Me.gameObject.SetActive (false);
		GameObject.FindGameObjectWithTag("player").GetComponent<move> ().enabled = true;
	}

//	IEnumerator converse () {
//
//		for (int i = 0; i < Text.Length; i++) {
//			TextBox.Me.Imprint (Text [i].Text);
//
//			while (!Input.GetKeyDown (KeyCode.Space)) {
//				yield return null;	
//			}
//
//			yield return null;
//		}
//		TextBox.Me.gameObject.SetActive (false);
//		GameObject.FindGameObjectWithTag("player").GetComponent<move> ().enabled = true;
//	}

}

[System.Serializable]
public class DialogueLine{
	public Lines Type;
	public string Text;
	public DialogueOption[] Options;
}

[System.Serializable]
public class DialogueOption{
	public string Text;
	public Lines Response;
}

public enum Lines{
	None,
	Monster1,
	Monster2,
	Monster3,
	Monster4,
	Monster5,
	Monster6,
	Monster7,
	Monster8,
	Monster9,
	Monster10,
	NPC1,
	NPC2,
	NPC3,
	NPC4,
	NPC5,
	NPC6,
	NPC7,
	NPC8,
	NPC9,
	NPC10
}