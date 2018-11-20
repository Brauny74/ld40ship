using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Looter : MonoBehaviour {

	public Text text;

	public int Gold = 0;

	public AudioClip CoinSound;

	protected GameObject[] loots;
	protected Loot tLoot;
	protected AudioSource audioS;
	// Use this for initialization
	void Start () {
		audioS = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {		
		if (Input.GetAxisRaw ("Gather") > 0) {
			bool LootExists = false;
			loots = GameObject.FindGameObjectsWithTag ("Loot");
			foreach (GameObject obj in loots) {
				tLoot = obj.GetComponent <Loot> (); 
				if (tLoot.GetMark ()) {
					LootExists = true;
					Gold += tLoot.Value;
					tLoot.Unmark ();
					tLoot.Remove ();
				}
			}
			if (LootExists) {
				if (audioS != null) {
					audioS.PlayOneShot (CoinSound);
				}
			}
		}
		text.text = "Gold: " + Gold.ToString ();
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Loot") {
			Loot t_loot = other.GetComponent <Loot> ();
			t_loot.Mark ();
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Loot") {
			Loot t_loot = other.GetComponent <Loot> ();
			t_loot.Unmark ();
		}
	}
}
