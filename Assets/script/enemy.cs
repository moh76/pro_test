using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	public float speed  ;
	Rigidbody2D enemyp ;
	public bool move  ; 
	public SpriteRenderer sp;

	// Use this for initialization
	void Start () {
		
		enemyp = GetComponent<Rigidbody2D> ();
		move = true; 
		sp = GetComponent<SpriteRenderer> ();


	}
	
	// Update is called once per frame
	void Update () {
		if (move) {
			enemyp.velocity = new Vector2 (speed, enemyp.velocity.y);
			sp.flipX = false;
		} else {
			enemyp.velocity = new Vector2 (-speed, enemyp.velocity.y);
			sp.flipX = true;
		}
	}
	void OnTriggerEnter2D(Collider2D col ){
		if (col.gameObject.CompareTag ("wallleft")) {
			move = true; 
		}if(col.gameObject.CompareTag ("wallright")) {
			move = false; 
		}

	}
}
