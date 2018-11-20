using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//button, which upgrades health
public class UpgradeHealth : MonoBehaviour {
	
	public Text text;

	protected Button btn;

	public int Cost = 200;
	public int UpgradeValue = 10;

	protected Looter looter;
	protected ShipHealth health;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		GameObject tmp = GameObject.FindGameObjectWithTag ("Looter");
		looter = tmp.GetComponent<Looter> ();
		tmp = GameObject.FindGameObjectWithTag ("Player");
		health = tmp.GetComponent <ShipHealth> ();
	}

	// Update is called once per frame
	void Update () {
		text.text = Cost.ToString () + " G";
	}

	void TaskOnClick(){
		if (looter.Gold >= Cost) {
			looter.Gold -= Cost;
			health.MaxHealth += UpgradeValue;
			health.Heal ();
			Cost += 100;
		}
	}
}
