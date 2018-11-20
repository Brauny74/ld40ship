using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsPrevButtons : MonoBehaviour {

	protected Button btn;
	public CurrentPageStorage pageStorage;
	public GameObject[] Pages;
	protected int i = 0;
	
	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		if (pageStorage.i - 1 >= 0) {
			pageStorage.i--;
			for (int j = 0; j < Pages.Length; j++) {
				if (j != i) {
					Pages [j].SetActive (false);
				}
			}
			Pages [pageStorage.i].SetActive (true);
		}
	}
}
