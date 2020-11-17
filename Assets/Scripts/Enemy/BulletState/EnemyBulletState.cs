using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletState :  IBulletState
{
    // パリィ用エフェクト
    [SerializeField]
    private GameObject parryFX;
    // ダメージ用エフェクト
    [SerializeField]
    private GameObject damageFX;

    // プロパティとして状態を返す

    // 次のステート
    private BossEnemyBullet.BulletState nextState = BossEnemyBullet.BulletState.EnemyBullet;


    // 更新処理
    public BossEnemyBullet.BulletState Update()
    {
        if (nextState != BossEnemyBullet.BulletState.EnemyBullet)
            return nextState;

        Debug.Log("EnemyBulletState");
        return BossEnemyBullet.BulletState.EnemyBullet;
    }
    
    // OnTrigger時の処理
    public void OnTriggerEnter(Collider _other)
    {
        // 敵の弾の状態でプレイヤーのパリィ範囲内に入ったらはじかれた後の状態に遷移
        if (_other.tag == "PlayerParry")
        {
            //Instantiate(damageFX, this.transform.position, Quaternion.identity);
            nextState = BossEnemyBullet.BulletState.Parry;
        }
        else if(_other.tag == "PlayerBody")
        {
            Instantiate(damageFX, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
