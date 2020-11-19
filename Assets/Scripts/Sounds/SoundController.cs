using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    // ボス戦のBGM
    [SerializeField]
    private AudioClip bossBattleBGM;
    // 通常時のBGM
    [SerializeField]
    private AudioClip normalBGM;
    // ダメージを受ける
    [SerializeField]
    private AudioClip takeDamageSE;
    // レーンの移動
    [SerializeField]
    private AudioClip dodgeSE;
    // グッド判定   
    [SerializeField]
    private AudioClip goodSE;
    // パーフェクト判定
    [SerializeField]
    private AudioClip perfectSE;

    // オーディオソース
    AudioSource audioSource;
    // フェードインを行うフラグ
    private bool isFadeIn;
    private float fadeInTime; 
    // フェードアウトを行うフラグ
    bool isFadeOut;
    private float fadeOutTime;
    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントを取得
        audioSource = GetComponent<AudioSource>();

        isFadeIn = isFadeOut = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            FadeIn();
            isFadeOut = false;
        }
        else
        if (isFadeOut)
        {
            FadeOut();
            isFadeIn = false;
        }

    }
    // ボスのBGM再生
    public void BossBattleBGM()
    {
        // プレイ中でなかったら
        if(!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(bossBattleBGM);
        }
    }

    // プレイシーンのBGM
    public void NormalBGM()
    {
        // プレイ中でなかったら
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(bossBattleBGM);
        }
    }

    // サウンドを止める
    public void StopSound()
    {
        audioSource.Stop();
    }

    // ダメージを受ける
    public void TakeDamage()
    {
        audioSource.PlayOneShot(takeDamageSE);
    }

    // 回避した時
    public void DodgeSE()
    {
        audioSource.PlayOneShot(dodgeSE);
    }

    // "good"判定
    public void GoodSE()
    {
        audioSource.PlayOneShot(goodSE);
    }

    // "perfect"判定
    public void PerfectSE()
    {
        audioSource.PlayOneShot(perfectSE);
    }

    // フェードインを開始させる
    public void StartFadeIn()
    {
        isFadeIn = true;
        //fadeInTime = time;
    }

    // フェードアウトを開始させる
    public void StartFadeOut()
    {
        isFadeOut = true;
        //fadeOutTime = time;
    }

    // フェードインの内部処理
    void FadeIn()
    {
        audioSource.volume += Time.deltaTime;
    }

    // フェードアウトの内部処理
    void FadeOut()
    {
        audioSource.volume -= Time.deltaTime;
        if(audioSource.volume <= 0.0f)
        {
            audioSource.Stop();
        }
    }
}
