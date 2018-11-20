using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Button, which upgrades ship's volume
public class UpgradeVolume : MonoBehaviour {
	
	public Text text;

	protected Button btn;

	public int Cost = 200;
	public int UpgradeValue = 100;

	protected Looter looter;
	protected ShipSinker sinker;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		GameObject tmp = GameObject.FindGameObjectWithTag ("Looter");
		looter = tmp.GetComponent<Looter> ();
		tmp = GameObject.FindGameObjectWithTag ("Player");
		sinker = tmp.GetComponent <ShipSinker> ();
	}

	// Update is called once per frame
	void Update () {
		text.text = Cost.ToString () + " G";
	}

	void TaskOnClick(){
		if (looter.Gold >= Cost) {
			looter.Gold -= Cost;
			sinker.FullVolume += UpgradeValue;
			sinker.PumpOutWater ();
			Cost += 100;
		}
	}
}
