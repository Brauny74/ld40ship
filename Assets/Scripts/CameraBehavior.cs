using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour {

	public GameObject ObjectToFollow;

		
	void Update () {
		Vector2 followedPos = ObjectToFollow.GetComponent <Transform> ().position;
		Vector3 newCameraPos = new Vector3 (followedPos.x, followedPos.y, -1);
		transform.position = newCameraPos;
	}
}
