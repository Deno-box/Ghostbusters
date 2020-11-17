using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletState
{
    // 更新処理
    BossEnemyBullet.BulletState Update();
    // OnTrigger時の処理
    void OnTriggerEnter(Collider _other);
}