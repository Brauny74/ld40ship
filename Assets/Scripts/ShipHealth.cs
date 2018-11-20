using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipHealth : MonoBehaviour {

	public int MaxHealth = 100;
	public Text text;

	protected int CurrentHealth;
	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
	}

	public void Heal(){
		CurrentHealth = MaxHealth;
	}

    public void InvokeDamage(int damage) {
        CurrentHealth -= damage;
    }
	
	// Update is called once per frame
	void Update () {
		text.text = "Health: " + CurrentHealth.ToString () + "/" + MaxHealth.ToString();
		if (CurrentHealth <= 0) {
			Cursor.visible = true;
			SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
		}
	}
}
