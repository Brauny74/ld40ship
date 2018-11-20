using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is compass, always pointing to the city, so player won't be lost.
public class CityCompass : MonoBehaviour {

	public GameObject City;
	
	void Update () {
		transform.rotation = Quaternion.LookRotation(Vector3.forward, City.transform.position - transform.position);
	}
}
