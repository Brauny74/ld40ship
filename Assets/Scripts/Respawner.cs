using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour {

	public EnemyHealth enemy;

	protected bool RespawnActivated = false;
	protected LootDropper dropper;
	// Use this for initialization
	void Start () {
		dropper = enemy.gameObject.GetComponent<LootDropper> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (enemy.GetCurrentHealth () <= 0 && !RespawnActivated) {
			StartCoroutine (Respawn());
			RespawnActivated = true;
		}
	}

	IEnumerator Respawn(){
		yield return new WaitForSecondsRealtime (30f);
		enemy.gameObject.SetActive (true);
		enemy.IsAlive = true;
		enemy.Heal ();
		dropper.ResetDrop ();
		RespawnActivated = false;
	}
}
