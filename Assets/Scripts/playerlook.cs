using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlook : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D))
			RotateCamera ();
	}
	void RotateCamera()
	{

		//transform.localRotation
		//StartCoroutine (moveleft);
	
	}
//	IEnumerator moveleft
}
