﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManeger : MonoBehaviour {

// ステートの定義
	public enum GAMESTATE{
		NONE = -1,
		START,
		PLAY,
		CLEAR,
		GAMEOVER,
		RESTART,
		QUIT,
	}
	public GAMESTATE state;
	private float time;
	private float goalTime;

	void Start () {
		time = 0.0f;
		goalTime = 10.0f;
	}

	// Update is called once per frame
	void Update () {
		if(state == GAMESTATE.NONE){
			if(Input.GetKeyDown(KeyCode.Space)){
				SceneManager.LoadScene("ship test");
				Debug.Log("MainScene loaded.");
				state = GAMESTATE.START;
			}
		}
		switch(state){
			case GAMESTATE.START:
			{
				state = GAMESTATE.PLAY;
			}
			break;
			case GAMESTATE.PLAY:
			{
				time += Time.deltaTime;
				if(time > goalTime){
				// ゴールします
				state = GAMESTATE.CLEAR;
			}
				Debug.Log("Plaing.");
				Debug.Log(time);
			}
			break;
			case GAMESTATE.CLEAR:
			{
				Debug.Log("Clear!");
				SceneManager.LoadScene("GameoverScene");
				Debug.Log("GameoverScene loaded.");
			}
			break;
			case GAMESTATE.GAMEOVER:
			{
				SceneManager.LoadScene("GameoverScene");
				Debug.Log("GameoverScene loaded.");
			}
			break;
			case GAMESTATE.RESTART:
			{
				// リスタート
			}
			break;
			case GAMESTATE.QUIT:
			{
				Debug.Log("quit.");
			}
			break;
		}
	}
}