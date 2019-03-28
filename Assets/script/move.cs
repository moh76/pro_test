// Code auto-converted by Control Freak 2 on Monday, September 17, 2018!
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
	public float movespeed =0; 
	public float jumpspeed = 0 ;
	static int score =0;
	SpriteRenderer flip;
	// Use this for initialization
	void Start () {
		flip = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = ControlFreak2.CF2Input.GetAxis ("Horizontal") * movespeed * Time.deltaTime;
		if (h > 0) {
			flip.flipX = false;
		}
		if (h < 0) {
			flip.flipX = true;
		}

		float j = ControlFreak2.CF2Input.GetAxis ("Jump") * jumpspeed * Time.deltaTime;
		transform.Translate (h, j, 0);
	}
	public static void coin (int coin){
		score += coin;
		Debug.Log ("score = "+ score);
	}
	public static int getscore (){
		return score;
	}
}
