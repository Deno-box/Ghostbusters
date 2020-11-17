using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletParryState : IBulletState
{
    // 更新処理
    public BossEnemyBullet.BulletState Update()
    {
        Debug.Log("ParryState");
        return BossEnemyBullet.BulletState.Parry;
    }

    // OnTrigger時の処理
    public void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Enemy")
        {
            //Destroy(this.gameObject);
        }
    }
}
