using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSounds : MonoBehaviour {

	protected Rigidbody2D _rb;
	protected AudioSource _audio;
	
	void Start () {
		_rb = gameObject.GetComponent <Rigidbody2D> ();
		_audio = gameObject.GetComponent<AudioSource> ();
	}
	
	void Update () {
		if (_rb.velocity.magnitude != 0) {
			_audio.pitch = 1f;
		} else {
			_audio.pitch = 0.8f;
		}
	}
}
