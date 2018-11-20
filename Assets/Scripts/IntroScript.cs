using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {

	public Text nameT;
	public Text phraseT;

	protected List<string> names = new List<string> ();
	protected List<string> phrases = new List<string> ();
	protected int i = 0;
	// Use this for initialization
	void Start () {
		names.Add ("Captain");
		phrases.Add ("Greetings. fellow salty dogs!");
		names.Add ("Trader");
		phrases.Add ("It's only me here. And I'm not salty yet, but I feel like I'll become soon.");
		names.Add ("Captain");
		phrases.Add ("That's allright, the sea welcomes everyone! ");
		names.Add ("Trader");
		phrases.Add ("Uh-oh.");
		names.Add ("Captain");
		phrases.Add ("So tell me, fella, can I sell my ship with a hole in it and buy a new one?");
		names.Add ("Trader");
		phrases.Add ("You can buy a new one. For 1000G.");
		names.Add ("Captain");
		phrases.Add ("No selling?");
		names.Add ("Trader");
		phrases.Add ("No selling.");
		names.Add ("Captain");
		phrases.Add ("But how I'll get it on a sinking ship?");
		names.Add ("Trader");
		phrases.Add ("Well, you can control the ship by WASD, shoot enemies with LMB and loot them with SHIFT.");
		names.Add ("Captain");
		phrases.Add ("I know that already! My ship sinks faster with gold in it! How I'm supposed to deal with that?");
		names.Add ("Trader");
		phrases.Add ("Not my problem. But you can always buy upgrades to ease the pain a little. *wink-wink* And I'm feeling generous. You can pump the water for free.");
		names.Add ("Captain");
		phrases.Add ("How generous. Maybe you'll fix my ship if you're so kind?");
		names.Add ("Trader");
		phrases.Add ("Can't do that. The hole is of the size of a seadog. Patch will last even less than I can bear this conversation. ");
		names.Add ("Captain");
		phrases.Add ("Any less salty traders in this area?");
		names.Add ("Trader");
		phrases.Add ("Nope.");
		names.Add ("Captain");
		phrases.Add ("I see. Then I have no choice. See you,");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if(i + 1 < names.Count){
				i++;
				nameT.text = names [i];
				phraseT.text = phrases [i];
			}
			if (i + 1 >= names.Count) {
				SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
			}
		}
	}
}
