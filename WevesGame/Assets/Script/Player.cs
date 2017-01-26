using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	Rigidbody rigidBody;
	BoxCollider playerCollider;
	GameObject go;
	StateManeger sManeger;

	private bool damageflag = false;	// ダメージをくらったかどうか
	private float endTime = 0.8f;		// 点滅終了時間
	private int flashCount = 0;			// 点滅カウント
	private int inputMuki = 0;			// 0:Up 1:Down 2:Left 3:Right

	public float speed = 2;				// 移動スピード
	public float slope = 2;				// 傾き
	
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		playerCollider = GetComponent<BoxCollider> ();
		go = GameObject.Find("GameSystemBox");
		sManeger = (StateManeger)(go.GetComponent<StateManeger>());
	}
	// Update is called once per frame
	void Update () {
		// move
		Move();
		// damage
		if (damageflag) {
			Damage();
			sManeger.state = StateManeger.GAMESTATE.GAMEOVER;
		}
	}

	// 移動
	void Move () {
		// 前
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow) || 0 < Input.GetAxisRaw ("Vertical")) {
			inputMuki = 0;
			rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, speed);
		}
		// 後ろ
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow) || Input.GetAxisRaw("Vertical") < 0) {
			inputMuki = 1;
			rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, -speed);
		}
		// 左
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow) || Input.GetAxisRaw("Horizontal") < 0) {
			inputMuki = 2;
			rigidBody.velocity = new Vector3 (-speed, rigidBody.velocity.y, rigidBody.velocity.z);
			// 傾ける
			transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, slope);
		} else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) {
			// 傾きを戻す
			transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
		}
		// 右
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow) || 0 < Input.GetAxisRaw("Horizontal")) {
			inputMuki = 3;
			rigidBody.velocity = new Vector3 (speed, rigidBody.velocity.y, rigidBody.velocity.z);
			// 傾ける
			transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -slope);
		} else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) {
			// 傾きを戻す
			transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
		}

		if (Input.GetAxisRaw("Horizontal") == 0) {
			// 傾きを戻す
			transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);
		}
	}

	// 当たり判定
	void OnCollisionEnter(Collision collision) {
		// 船と岩
		if (collision.gameObject.tag == "Rock") {
			// 船を点滅させて一時当たり判定をなくす
			if (damageflag == false) {
				flashCount = 0;
				damageflag = true;
				// 反対側にはじく
				if (inputMuki == 0) rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, -speed);
				if (inputMuki == 1) rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, speed);
				if (inputMuki == 2) rigidBody.velocity = new Vector3 (speed, rigidBody.velocity.y, rigidBody.velocity.z);
				if (inputMuki == 3) rigidBody.velocity = new Vector3 (-speed, rigidBody.velocity.y, rigidBody.velocity.z);
				// プレイヤーのColliderを消す
				playerCollider.enabled = false;
				// 岩のColliderを消す
				// var rockCollider = GameObject.FindWithTag ("Rock").GetComponent<BoxCollider> ();
				// rockCollider.enabled = false;
				// 点滅終了
				Invoke ("FlashEnd", endTime);
			}
		}
	}
	void OnTriggerEnter(Collider collision) {
		// 船と波
		if (collision.gameObject.tag == "Wave") {
			collision.enabled = false;
			//var waveObject = GameObject.FindWithTag("Wave");
			// 船を点滅させて一時当たり判定をなくす
			if (damageflag == false) {
				flashCount = 0;
				damageflag = true;
				// 反対側にはじく
				if (inputMuki == 0) rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, -speed*3);
				if (inputMuki == 1) rigidBody.velocity = new Vector3 (rigidBody.velocity.x, rigidBody.velocity.y, speed*3);
				if (inputMuki == 2) rigidBody.velocity = new Vector3 (speed*3, rigidBody.velocity.y, rigidBody.velocity.z);
				if (inputMuki == 3) rigidBody.velocity = new Vector3 (-speed*3, rigidBody.velocity.y, rigidBody.velocity.z);
				// プレイヤーのColliderを消す
				playerCollider.enabled = false;
				// 点滅終了
				Invoke ("FlashEnd", endTime);
			}
		}
	}

	// ダメージ
	void Damage() {
		flashCount++;
		Renderer ren = GameObject.FindWithTag("Yacht").GetComponent<Renderer> ();
		if (flashCount % 2 == 0) {
			ren.enabled = !ren.enabled;
		}
	}

	// 点滅終了
	void FlashEnd() {
		damageflag = false;
		GameObject.FindWithTag("Yacht").GetComponent<Renderer> ().enabled = true;
		// プレイヤーのColliderを戻す
		playerCollider.enabled = true;
		// 岩のColliderを戻す
		// var rockCollider = GameObject.FindWithTag ("Rock").GetComponent<BoxCollider> ();
		// rockCollider.enabled = true;
	}
}
