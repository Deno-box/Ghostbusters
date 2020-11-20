using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerReceiveDamage : MonoBehaviour
{
    // TODO : 仮で作っている
    //[SerializeField]
    //private PlayerParryAction playerParryAction = null;

    private void Start()
    {
    }

    // 敵に衝突したらスコアを減らす
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            GameDataManager.AddDecisionNum((int)GameDataManager.SCORE_TYPE.MISS);
            this.GetComponentInParent<PlayerIdleState>().StateOnTrigger(other);
        }
    }
}
