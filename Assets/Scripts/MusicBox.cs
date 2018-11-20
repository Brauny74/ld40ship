using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour {

	public ShipSinker sinker;

	public AudioClip marineTheme;
	public AudioClip greedyTheme;//this theme plays, when ship is almost sunk

	protected AudioSource audioS;
	protected bool greedThemePlaying = false;
	// Use this for initialization
	void Start () {
		audioS = gameObject.GetComponent<AudioSource> ();
		audioS.PlayOneShot (marineTheme);
		greedThemePlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (sinker.IsVolumeLow () && !greedThemePlaying) {
			audioS.Stop ();
			audioS.PlayOneShot (greedyTheme);
			greedThemePlaying = true;
		}
		if(!sinker.IsVolumeLow() && greedThemePlaying){
			audioS.Stop ();
			audioS.PlayOneShot (marineTheme);
			greedThemePlaying = false;
		}
		if (!audioS.isPlaying) {
			if (sinker.IsVolumeLow ()) {
				audioS.PlayOneShot (greedyTheme);
			} else {
				audioS.PlayOneShot (marineTheme);
			}
		}
	}
}
