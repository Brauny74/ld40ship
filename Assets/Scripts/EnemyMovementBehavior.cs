using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MonoBehaviour {

	public Vector3[] path;
	public float Speed;
	protected int i = 0;
	protected EnemyHealth health;
	// Use this for initialization
	void Start () {
		health = gameObject.GetComponent <EnemyHealth> ();
	}

	bool CompareVectors(Vector3 v1, Vector2 v2, float delta){
		if (Mathf.Abs (v1.x - v2.x) < delta && Mathf.Abs (v1.y - v2.y) < delta) {
			return true;
		} else {
			return false;
		}
	}

	Vector3 SubtractVector(Vector3 v1, Vector2 v2){
		Vector3 rV = new Vector3 (v1.x - v2.x, v1.y - v2.y, 0);
		return rV;
	}

	Vector3 SubtractVector(Vector2 v1, Vector3 v2){
		Vector3 rV = new Vector3 (v1.x - v2.x, v1.y - v2.y, 0);
		return rV;
	}

	void Update () {
		if (health.GetCurrentHealth () > 0)
		{
			if (path.Length > 0)
			{
				if (transform.position != path [i])
				{				
					transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), path [i], Speed * Time.deltaTime);
					transform.rotation = Quaternion.LookRotation (Vector3.forward, path [i] - transform.position);
				} else
				{
					i++;
					if (i == path.Length)
					{
						i = 0;
					}
				}
			}
		}
	}

}
