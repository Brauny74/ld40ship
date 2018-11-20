using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipSinker : MonoBehaviour {

	public int SinkingSpeed = 1;
	public int FullVolume = 200;
	public Text LeakingSpeedText;
	public Text VolumeText;
	public RectTransform WaterImage;
	public int StepForSink = 200;

	protected int CurrentVolume;
	protected bool PeriodSecond = true;
	public Looter looter;
	// Use this for initialization
	void Start () {
		//looter = gameObject.GetComponent <Looter> ();
		CurrentVolume = FullVolume;
	}

	public bool IsVolumeLow(){
		return CurrentVolume < 75;
	}

	public void PumpOutWater(){
		CurrentVolume = FullVolume;
	}

	// Update is called once per frame
	void Update () {		
		if (LeakingSpeedText != null) {
			LeakingSpeedText.text = SinkingSpeed.ToString () + " l/s";
		}
		if (VolumeText != null) {
			VolumeText.text = CurrentVolume.ToString () + "/" + FullVolume.ToString ();
		}
		if (WaterImage != null) {
			float floatVolume = FullVolume;
			float floatCurrent = CurrentVolume;
			float stepForWater = Mathf.Abs(60 - 14) / floatVolume;
			float currentUIWaterLevel = -60 + stepForWater * (floatVolume - floatCurrent);
			WaterImage.localPosition = new Vector3 (0, currentUIWaterLevel, 0);
		}
		if (PeriodSecond) {
			StartCoroutine (Leak ());
			PeriodSecond = false;
		}
		if (looter.Gold < StepForSink) {
			SinkingSpeed = 0;
		} else {
			SinkingSpeed = looter.Gold / StepForSink;
		}
		if (CurrentVolume < 0) {
			Cursor.visible = true;
			SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
		}
	}

	IEnumerator Leak(){		
		yield return new WaitForSecondsRealtime (1f);
		CurrentVolume -= SinkingSpeed;
		PeriodSecond = true;
	}
}
