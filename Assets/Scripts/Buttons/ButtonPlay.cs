using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour {

	public GameObject panel;

	protected Button btn;

	public GameObject[] turrets;
	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		for (int i = 0; i < turrets.Length; i++) {
			turrets [i].SetActive (false);
		}
		Time.timeScale = 0.0f;
	}

	void TaskOnClick(){		
		Cursor.visible = false;
		for (int i = 0; i < turrets.Length; i++) {
			turrets [i].SetActive (true);
		}
		Time.timeScale = 1.0f;
		StartCoroutine (LetPlaySound ());
	}

	IEnumerator LetPlaySound(){
		yield return new WaitForSecondsRealtime (0.2f);
		panel.SetActive (false);
	}
}