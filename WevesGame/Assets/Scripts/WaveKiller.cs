using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveKiller : MonoBehaviour {

	
    void Awake()
    {
        Invoke("DestroyWave", 3f);
    }

    void DestroyWave()
    {
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
