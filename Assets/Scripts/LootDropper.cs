using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootDropper : MonoBehaviour {

	public Loot lootToDrop;

	protected EnemyHealth health;
	protected bool AlreadyDropped = false;
	// Use this for initialization
	void Start () {
		health = gameObject.GetComponent <EnemyHealth> ();
	}

	public void ResetDrop(){
		AlreadyDropped = false;
	}

	public void Drop(){
		if (!AlreadyDropped) {
			Instantiate (lootToDrop, transform.position, Quaternion.identity);
			AlreadyDropped = true;
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
