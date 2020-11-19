using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// 範囲内にPlayerが入ったらEnemyの移動を開始させるトリガー
public class EnemyMoveTrigger : MonoBehaviour
{
    // アクティブにさせたいオブジェクト
    [SerializeField]
    private GameObject moveObject = null;
    // BGMを鳴らす時間までの時間
    [SerializeField]
    private float soundTime = 2.0f;
    // サウンドマネージャー
    [SerializeField]
    private GameObject soundManager = null;
    // サウンドコントローラー
    private SoundController soundController = null;
    private void Start()
    {
        // 開始時に非アクティブにする
        moveObject.SetActive(false);
        // サウンドマネージャーからサウンドコントローラーを取得
        soundController = soundManager.GetComponent<SoundController>();
    }

    private void Update()
    {

    }

    // 通過するとアクティブにする
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Player")
        {
            moveObject.SetActive(true);
            Destroy(this.gameObject);
            // サウンドを止める
            soundController.StopSound();
            // ボス戦のBGM
            soundController.BossBattleBGM();
        }
    }
}
