using UnityEngine;
using System.Collections;

public class SEManager : MonoBehaviour {

    //仕込むスクリプト
    //SEManagerの取得
    //GameObject seManager;

    //Start関数
    //seManager = GameObject.Find("SEManager");

    //seManager.SendMessage("TheGroundJumpSE");

    //SE全体の処理
    [SerializeField]
    private AudioClip Cannon;//砲台攻撃時の音
    [SerializeField]
    private AudioClip BulletHit;//砲弾着弾時の音
    [SerializeField]
    private AudioClip Accelaration;//自機加速時の音
    [SerializeField]
    private AudioClip Player1Win;//Player1勝利時の音
    [SerializeField]
    private AudioClip Player2Win;//Player2勝利時の音
    [SerializeField]
    private AudioClip Enter;//選択肢決定の音
    AudioSource audiosource;

    // Use this for initialization
    void Start () {
        audiosource = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayCannon()
    {
        audiosource.PlayOneShot(Cannon);
    }
    public void PlayBulletHit()
    {
        audiosource.PlayOneShot(BulletHit);
    }
    public void PlayPlayer2Win()
    {
        audiosource.PlayOneShot(Player2Win);
    }
    public void PlayPlayer1Win()
    {
        audiosource.PlayOneShot(Player1Win);
    }
    public void PlayAccelaration()
    {
        audiosource.PlayOneShot(Accelaration);
    }
    public void PlayEnter()
    {
        audiosource.PlayOneShot(Enter);
    }
}
