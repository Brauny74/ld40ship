using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballBehavior : MonoBehaviour {

	public float Speed = 3000f;
	public int Damage = 30;
	public float LifeTime = 2f;
	public Vector3 InitialVelocity;

	protected Rigidbody2D _rb;
	protected Vector3 target;
	protected bool IsGivenInitialVelocity = false;

	public AudioClip damageSound;

	protected AudioSource audioS;
	// Use this for initialization
	void Start () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		target = mousePos;
		_rb = gameObject.GetComponent <Rigidbody2D> ();	
		StartCoroutine (EndLifeTime ());
		_rb.velocity = InitialVelocity;
		audioS = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {				
		if (IsGivenInitialVelocity) {
			_rb.AddForce (transform.up * Speed * Time.fixedDeltaTime);
		} else {
			_rb.velocity = InitialVelocity;
			IsGivenInitialVelocity = true;
		}
	}

	IEnumerator EndLifeTime(){
		yield return new WaitForSeconds (LifeTime);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Enemy") {
			if (audioS != null) {
				audioS.PlayOneShot (damageSound);
			}
			EnemyHealth enemy = other.GetComponent <EnemyHealth> ();
			enemy.InvokeDamage (Damage);
			Destroy (gameObject);
		}
	}
}
