using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map1 : MonoBehaviour {

	public GameObject mapObject1;
	public GameObject mapObject2;

	// 岩シングル
	public GameObject s_rockObject1;
	public GameObject s_rockObject2;
	public GameObject s_rockObject3;
	public GameObject s_rockObject4;
	public GameObject s_rockObject5;
	public GameObject s_rockObject6;
	public GameObject s_rockObject7;
	public GameObject s_rockObject8;
	public GameObject s_rockObject9;

	// 岩の間隔
	private float rockSpace = 30;
	// 岩を表示する間隔
	private float createTime = 5.0f;
	private float time = 0;

	// Use this for initialization
	void Start () {
		Instantiate(mapObject1, new Vector3(0, 0, 0), mapObject1.transform.rotation);
		Instantiate(mapObject2, new Vector3(0, 0, 100), mapObject2.transform.rotation);

		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		// 一定の間隔で岩を生成
		time += Time.deltaTime;
//		print (time);
		if(time>createTime){
			time = 0;

			int rand = Random.Range(0, 9);
			int randX = Random.Range (-19, 22);
			int i = 1;
			if (rand == 0) {
				Instantiate (s_rockObject1, new Vector3 (randX, 0, i*rockSpace + rockSpace), s_rockObject1.transform.rotation);
			} else if (rand == 1) {
				Instantiate (s_rockObject2, new Vector3 (randX, 0, i*rockSpace + rockSpace), s_rockObject2.transform.rotation);
			} else if (rand == 2) {
				Instantiate (s_rockObject3, new Vector3 (randX, 0, i*rockSpace + rockSpace), s_rockObject3.transform.rotation);
			} else if (rand == 3) {
				Instantiate (s_rockObject4, new Vector3 (randX, 0, i*rockSpace + rockSpace), s_rockObject4.transform.rotation);
			} else if (rand == 4) {
				Instantiate (s_rockObject5, new Vector3 (randX, 0, i*rockSpace + rockSpace), s_rockObject5.transform.rotation);
			} else if (rand == 5) {
				Instantiate (s_rockObject6, new Vector3 (randX, 0, i*rockSpace + rockSpace), s_rockObject6.transform.rotation);
			} else if (rand == 6) {
				Instantiate (s_rockObject7, new Vector3 (randX, 0, i*rockSpace + rockSpace), s_rockObject7.transform.rotation);
			} else if (rand == 7) {
				Instantiate (s_rockObject8, new Vector3 (randX, 0, i*rockSpace + rockSpace), s_rockObject8.transform.rotation);
			} else if (rand == 8) {
				Instantiate (s_rockObject9, new Vector3 (randX, 0, i*rockSpace + rockSpace), s_rockObject9.transform.rotation);
			}
		}
	}
}
