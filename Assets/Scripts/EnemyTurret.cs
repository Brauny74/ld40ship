using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour {

	public EnemyProjectile Projectile;
	public float CoolDownTime = 1.2f;

	protected Transform player;
	protected bool OnCooldown = false;
	protected EnemyHealth parentHealth;
	// Use this for initialization
	void Start () {
		Transform parent_t = transform.parent;
		parentHealth = parent_t.GetComponent <EnemyHealth> ();
		GameObject obj = GameObject.FindGameObjectWithTag ("Player");
		player = obj.GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(Vector3.forward, player.position - transform.position);
		if (!OnCooldown) {
			if (parentHealth.GetCurrentHealth () > 0) {
				StartCoroutine (Cooldown ());
				OnCooldown = true;
				Instantiate (Projectile, transform.position, transform.rotation);
			}
		}
	}

	IEnumerator Cooldown(){
		yield return new WaitForSeconds (CoolDownTime);
		OnCooldown = false;
	}
}
