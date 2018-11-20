using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int MaxHealth = 50;
	protected int CurrentHealth;
	protected LootDropper lootD;

	public bool IsAlive = true;
	protected Animator _anim;
	// Use this for initialization
	void Start () {
		CurrentHealth = MaxHealth;
		_anim = gameObject.GetComponent<Animator> ();
		lootD = gameObject.GetComponent <LootDropper> ();
	}

	public void InvokeDamage(int damage){
		CurrentHealth -= damage;
	}

	// Update is called once per frame
	void Update () {
		if (CurrentHealth <= 0) {
			lootD.Drop ();
			IsAlive = false;
			_anim.SetBool ("IsDead", true);
			StartCoroutine (DeadAnimation ());
		}
	}

	public void Heal(){
		CurrentHealth = MaxHealth;
	}

	public int GetCurrentHealth(){
		return CurrentHealth;
	}

	IEnumerator DeadAnimation(){
		yield return new WaitForSecondsRealtime (2f);
		gameObject.SetActive (false);
	}
}
