using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour {
    private Vector3 Hitpoint;
    private GameObject target;
    [SerializeField]
    GameObject seManager;

    float hitPointx;
    float hitPointy;
    float hitPointz;
    public float setWaveMin = 0.5f;
    public float setWaveMax = 3.5f;
    void Start()
    {
       
    }

    // Use this for initialization
    void Awake () {
        seManager = GameObject.Find("SEManager");

        target = GameObject.Find("Target");
        Vector3 Hitpoint = target.GetComponent<Transform>().position;

        Debug.Log(Hitpoint);
        Debug.Log(Hitpoint.x);

        //取得したhitpointの座標に2秒間かけて弾を移動
        gameObject.GetComponent<Transform>().DOMove(new Vector3 (Hitpoint.x, Hitpoint.y, Hitpoint.z), 1f);


    }

    // Update is called once per frame
    void Update () {

        //水面に着弾した瞬間(=Yが０になった瞬間)の判定。
        if (this.transform.position.y > setWaveMin && this.transform.position.y < setWaveMax) {
            //着弾する瞬間に弾を削除する。
            Invoke("DestroyBullet", 0.01f);

        } 
		
	}

    //着弾した瞬間にBulletを削除し波紋を生成する。
    void DestroyBullet() {
        seManager.SendMessage("PlayBulletHit");
        GameObject prefab = (GameObject)Resources.Load("Prefabs/Wave");
        Instantiate(prefab, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }
}
