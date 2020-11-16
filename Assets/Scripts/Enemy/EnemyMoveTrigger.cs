using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// 範囲内にPlayerが入ったらEnemyの移動を開始させるトリガー
public class EnemyMoveTrigger : MonoBehaviour
{
    // 移動をさせたいオブジェクト
    [SerializeField]
    private GameObject moveObject = null;

    private void Start()
    {
        // 開始時に非アクティブにする
        moveObject.SetActive(false);
    }

    // 通過するとアクティブにする
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.name == "Player")
            moveObject.SetActive(true);
    }
}
