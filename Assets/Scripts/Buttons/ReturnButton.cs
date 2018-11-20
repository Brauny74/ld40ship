using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnButton : MonoBehaviour {

	public GameObject townPanel;

	protected Button btn;

	public GameObject[] turrets;
	
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		for (int i = 0; i < turrets.Length; i++) {
			turrets [i].SetActive (true);
		}
		Time.timeScale = 1.0f;
		Cursor.visible = false;
		StartCoroutine (CloseTownPanel ());
	}

	IEnumerator CloseTownPanel(){
        //It takes a small pause to let the sound play
        yield return new WaitForSecondsRealtime (0.2f);
		townPanel.SetActive (false);
	}
}
