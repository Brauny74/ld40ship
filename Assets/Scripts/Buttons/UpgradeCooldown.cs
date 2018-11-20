using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//button, which lowers turret's cooldown
public class UpgradeCooldown : MonoBehaviour {

	public Text text;

	protected Button btn;

	public int Cost = 200;
	public float UpgradeValue = 0.2f;

	protected Looter looter;
	public List<TurretBehavior> turrets;

	// Use this for initialization
	void Start () {
		btn = gameObject.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);

		GameObject tmp = GameObject.FindGameObjectWithTag ("Looter");
		looter = tmp.GetComponent<Looter> ();
	}

	// Update is called once per frame
	void Update () {
		text.text = Cost.ToString () + " G";
	}

	void TaskOnClick(){
		if (looter.Gold >= Cost) {
			looter.Gold -= Cost;
			for (int i = 0; i < turrets.Count; i++) {
				turrets [i].CoolDownTime -= UpgradeValue;
				turrets [i].OnCooldown = false;
			}
			Cost += 100;
			bool isDisabled = false;
			for (int i = 0; i < turrets.Count; i++) {
				if (turrets [i].CoolDownTime <= 0.2f) {
					isDisabled = true;
				}
			}
			if (isDisabled) {
				btn.interactable = false;
			}
		}
	}
}
