using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

	public float Speed = 20f;
	public float LifeTime = 2f;
	protected Rigidbody2D _rb;

	// Use this for initialization
	void Start () {
		_rb = gameObject.GetComponent <Rigidbody2D> ();
		StartCoroutine (EndLifeTime ());
	}
	
	// Update is called once per frame
	void Update () {
		_rb.AddForce (transform.up * Speed * Time.fixedDeltaTime);
	}

	IEnumerator EndLifeTime(){
		yield return new WaitForSeconds (LifeTime);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
