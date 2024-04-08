using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBox : MonoBehaviour {

	public TextMeshProUGUI Text;
	public static TextBox Me;
	public TextMeshProUGUI ChoiceText;

	void Awake(){
		gameObject.SetActive (false);
		TextBox.Me = this;
	}

	public void Imprint(string txt){
		gameObject.SetActive (true);
		Text.text = txt;
	}

	public void ImprintChoices(string ctext){
		ChoiceText.text = ctext;
		
	}

}
