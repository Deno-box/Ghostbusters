using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryJudgeObj : MonoBehaviour
{
    // 自身の親オブジェクト
    [SerializeField]
    private PlayerParryAction player = null;

    // 敵に衝突したらプレイヤーのパリィアクションに報告を行う
    void OnTriggerEnter(Collider other)
    {
        // プレイヤーに衝突の報告を行う
        if (other.tag == "EnemyBullet")
        {
            player.ParryJudgeCollision();
        }
    }
}
