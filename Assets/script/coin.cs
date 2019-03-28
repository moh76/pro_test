using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin : MonoBehaviour {
	public int coinc =0;
	public Text score;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D col ){

		if(col.gameObject.CompareTag("char")){
			move.coin(coinc);
			score.text = "" + move.getscore();
			Destroy(gameObject);
		}

	}

}
