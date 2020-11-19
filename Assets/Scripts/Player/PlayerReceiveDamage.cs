using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReceiveDamage : MonoBehaviour
{
    // TODO : 仮で作っている
    [SerializeField]
    //private PlayerParryAction playerParryAction = null;

    // 敵に衝突したらスコアを減らす
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            GameDataManager.AddDecisionNum((int)GameDataManager.SCORE_TYPE.MISS);
        }
    }
}
