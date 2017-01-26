using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BulletMaker : MonoBehaviour {

    private Vector3 bulletPosition;
    [SerializeField]float speed;
    private bool isReady;
    [SerializeField]GameObject seManager;


    // Use this for initialization
    void Start () {
        isReady = true;
        //seManager = GameObject.Find("SEManager");

    }



    // Update is called once per frame
    void Update() {
        //マウスの左ボタンの判定を取得する。
        if (Input.GetMouseButton(0))
        {
            //左ボタンが離れるタイミングを取得
            if (Input.GetMouseButtonUp(1) && isReady == true)
            {
                isReady = false;

                //弾の生成位置を砲身に同期
                bulletPosition = this.transform.position;

                //離れたら弾のprefabを取得して生成
                GameObject prefab = (GameObject)Resources.Load("Prefabs/cannonball");
                Instantiate(prefab, bulletPosition, Quaternion.identity);
                
                
                seManager.SendMessage("PlayCannon");


                Debug.Log("cannontest");

                Invoke("StandBy" , 1.5f);
            }
        }

    }
        void StandBy () {
        isReady = true;
    }
}
