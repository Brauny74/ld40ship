using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimBehavior : MonoBehaviour {
	public List<TurretBehavior> turrets;

	public Sprite AimWhite;
	public Sprite AimRed;

	protected Image img;
	// Use this for initialization
	void Start () {
		img = gameObject.GetComponent <Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Input.mousePosition;
		bool reloading = false;
		for (int i = 0; i < turrets.Count; i++) {
			if (turrets [i].OnCooldown) {
				reloading = true;
			}
		}
		if (reloading) {			
			img.sprite = AimRed;
		} else {
			img.sprite = AimWhite;
		}
	}
}
