using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int damage;

	public AudioClip damageSound;

	protected AudioSource audioS;
	// Use this for initialization
	void Start () {
		audioS = gameObject.GetComponent<AudioSource> ();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
			if (audioS != null) {
				audioS.PlayOneShot (damageSound);
			}
            ShipHealth health = other.GetComponent<ShipHealth>();
            health.InvokeDamage(damage);
        }
    }
}
