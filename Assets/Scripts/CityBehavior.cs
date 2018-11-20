using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CityBehavior : MonoBehaviour {

	public GameObject HintPanel;
	public Text HintText;

	public GameObject TownUI;

	public GameObject[] turrets;

	protected bool PlayerIsInTown = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw ("Gather") > 0 && PlayerIsInTown) {
			TownUI.SetActive (true);
			for (int i = 0; i < turrets.Length; i++) {
				turrets [i].SetActive (false);
			}
			Cursor.visible = true;
			Time.timeScale = 0.0f;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			HintText.text = "Press [Shift] to enter Town";
			HintPanel.SetActive (true);
			PlayerIsInTown = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "Player") {
			HintPanel.SetActive (false);
			PlayerIsInTown = false;
		}
	}
}
