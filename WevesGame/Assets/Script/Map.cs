using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

	public GameObject mapObject1;
	public GameObject mapObject2;

	// Use this for initialization
	void Start () {
		Instantiate(mapObject1, new Vector3(0, 0, 0), mapObject1.transform.rotation);
		Instantiate(mapObject2, new Vector3(0, 0, 100), mapObject2.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
