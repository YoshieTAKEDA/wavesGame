using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class BulletGage : MonoBehaviour
{
    public float hp = 0;

    Slider _slider;
    void Start()
    {
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();
    }

    public void recast() {

        hp = 0.0f;

    }


    void Update()
    {
        if (hp < 1.0f)
        {
            // HP上昇
            hp += 0.012f;
        }
        // HPゲージに値を設定
        _slider.value = hp;
    }
}
