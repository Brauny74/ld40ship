using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BuyWin : MonoBehaviour {

	public Looter looter;

	public int Cost = 1000;

	protected Button btn;
	// Use this for initialization
	void Start () {	
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		if (looter.Gold >= Cost) {
			Time.timeScale = 1.0f;
			SceneManager.LoadScene ("Victory");
		}
	}
}
