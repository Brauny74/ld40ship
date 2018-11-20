using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour {

	public AudioClip clickSound;

	protected Button btn;
	protected AudioSource audioS;
	// Use this for initialization
	void Start () {
		audioS = gameObject.GetComponent<AudioSource>();
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		if (audioS != null) {
			audioS.PlayOneShot (clickSound);
		}
	}
}
