using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownMarker : MonoBehaviour {

	public TurretBehavior TurretBehavior;
	public Sprite img;
		
	void Start () {
		img = gameObject.GetComponent <Sprite> ();
	}
}
