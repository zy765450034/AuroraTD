﻿using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	// Use this for initialization
	public string url = "http://localhost:5000/scores/ASS?limit=10";
	IEnumerator SendRequest() {
		WWW www = new WWW(url);
		yield return www;
		Debug.Log (www.text);
		var N = SimpleJSON.JSON.Parse (www.text);
		string playerString = N ["player_name"];
		int rank = N ["rank"].AsInt;
		int score = N ["score"].AsInt;
		//Debug.Log(N["competitors"][0]["rank"].AsInt);
		Debug.Log (N ["competitors"].Count);
		for(int x=0; x< N["competitors"].Count; x++) {
			Debug.Log (N["competitors"][x]["rank"].AsInt);
			Debug.Log (N["competitors"][x]["score"].AsInt);
			Debug.Log (N["competitors"][x]["player_name"].Value);
		}
	}

	void Start(){
		StartCoroutine (SendRequest ());

	}

	// Update is called once per frame
	void Update () {
	
	}
}