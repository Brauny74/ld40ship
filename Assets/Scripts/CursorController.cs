using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour {

	public AimBehavior cursor;

	protected bool toggled = false;
	void Update () {
		if (Cursor.visible && toggled) {			
			cursor.gameObject.SetActive (false);
			toggled = false;
		} else {
			cursor.gameObject.SetActive (true);
			toggled = true;
		}
	}
}
