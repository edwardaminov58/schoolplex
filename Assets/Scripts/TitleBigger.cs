using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBigger : MonoBehaviour {

    public float timer = 0;
    public float Grow = .01f;
    public float Stop;
    public float shrink = 100;

	public GameObject FrontPanel;
//    public float XValue;
//    public float YValue;
//    public float ZValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timer < shrink)
        {
            transform.localScale = new Vector2(Grow, Grow);
			Grow = Grow + .02f;

            timer++;
        }

		if (timer == shrink) 
		{
			Destroy (FrontPanel);
		}
	}
}
