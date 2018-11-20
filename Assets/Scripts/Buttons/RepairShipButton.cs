using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairShipButton : MonoBehaviour {

	public ShipHealth health;
	public Looter looter;
	public int Cost = 50;

	protected Button btn;
	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		if (looter.Gold >= Cost) {			
			health.Heal ();
			looter.Gold -= Cost;
		}
	}
}
