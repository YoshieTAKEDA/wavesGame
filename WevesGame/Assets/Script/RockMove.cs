using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMove : MonoBehaviour {

	public float speed = 0.3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.z -= speed;
		transform.position = pos;

		if (transform.position.z <= -14) {
			Destroy (gameObject);
		}
	}
}
