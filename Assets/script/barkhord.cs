using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barkhord : MonoBehaviour {
	public GameObject player, particle,start;
	SpriteRenderer showplayer ;
	public Image helt;
	float playerhelt = 100 ; 

	// Use this for initialization
	void Start () {
		showplayer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {		
	}

	void OnTriggerEnter2D(Collider2D col ){
		if (col.gameObject.CompareTag ("enemy")) {

			helthplay ();
			showplayer.enabled = false;
			Instantiate (particle, player.transform.position, player.transform.rotation);

			StartCoroutine ("wait");
			Debug.Log ("tigh");
			//Destroy (gameObject);
		}

	}
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.CompareTag ("tigh")) {
		
			helthplay ();
			showplayer.enabled = false;
			Instantiate (particle, player.transform.position, player.transform.rotation);

		StartCoroutine ("wait");
			Debug.Log ("tigh");
			//Destroy (gameObject);
			}

	}
	IEnumerator wait(){
		yield return new WaitForSeconds(0.5f);
		showplayer.enabled = true;
		player.transform.position=start.transform.position;

	}
	void helthplay(){
		if (helt.fillAmount > 0) {
			playerhelt -= 10;
			helt.fillAmount = playerhelt / 100; 
		}

		if (helt.fillAmount <= 0) {
		}
	}
}
