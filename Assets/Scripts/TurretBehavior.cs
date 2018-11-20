using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretBehavior : MonoBehaviour {

	public GameObject Projectile;
	public float CoolDownTime = 1f;
	public bool OnCooldown = false;
	public Text ReloadText;

	public Rigidbody2D parentRB;

	public int Damage = 10;

	public AudioClip ShotSound;
	protected AudioSource audio;
	
	void Start () {
		parentRB = transform.parent.GetComponent <Rigidbody2D> ();
		audio = gameObject.GetComponent <AudioSource> ();
	}

	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		if (ReloadText != null) {
			if (OnCooldown) {
				ReloadText.text = "Cannon is reloading";
			} else {
				ReloadText.text = "Cannon is ready";
			}
		}
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
		if (Input.GetMouseButtonDown (0) && !OnCooldown) {
			audio.PlayOneShot (ShotSound);
			GameObject tmp_cb = Instantiate (Projectile, transform.position, transform.rotation);
			CannonballBehavior tmp_cb_c = tmp_cb.GetComponent <CannonballBehavior> ();
			tmp_cb_c.InitialVelocity = parentRB.velocity;
			tmp_cb_c.Damage = Damage;
			OnCooldown = true;
			StartCoroutine (Cooldown ());
		}
	}

	IEnumerator Cooldown(){
		yield return new WaitForSeconds (CoolDownTime);
		OnCooldown = false;
	}
}
