using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreText : MonoBehaviour {

	public float score;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		String txt = score.ToString("f");
		this.GetComponent<Text> ().text = txt;
		Debug.Log(txt);
	}
}
