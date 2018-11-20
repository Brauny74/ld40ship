using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsNextButtons : MonoBehaviour {

	protected Button btn;

	public CurrentPageStorage pageStorage;
	public GameObject[] Pages;
	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		if (pageStorage.i + 1 < Pages.Length) {
			pageStorage.i++;
			for (int j = 0; j < Pages.Length; j++) {
				if (j != pageStorage.i) {
					Pages [j].SetActive (false);
				}
			}
			Pages [pageStorage.i].SetActive (true);
		}
	}
}
