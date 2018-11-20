using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

	public int Value = 100;

	protected bool IsMarked = false;
	protected Animator _anim;
	// Use this for initialization
	void Start () {
		_anim = gameObject.GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		_anim.SetBool ("IsMarked", IsMarked);
	}

	public void Mark() {
		IsMarked = true;
	}

	public void Unmark(){
		IsMarked = false;
	}

	public bool GetMark(){
		return IsMarked;
	}

	public void Remove(){
		Destroy (gameObject);
	}
}
