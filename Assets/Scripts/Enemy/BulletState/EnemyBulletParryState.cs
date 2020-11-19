using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnemyBulletParryState : BulletState
{
    // ボスのトランスフォーム
    private Transform bossTrs = null;
    // 跳ね返るときの弾の速度
    private float moveSpeed = 250.0f;

    // ボスにダメージを与えたときのFX
    //private GameObject damageFX;

    // 初期化処理
    public override void StateInitialize()
    {
        // レーン移動を削除
        Destroy(this.GetComponent<CinemachineDollyCart>());
        // ターゲットであるボスを検索

        // ボスが消えると参照できない
        bossTrs = GameObject.FindWithTag("BossEnemy").transform;
    }

    // 更新処理
    public override void StateUpdate()
    {
        // 移動先を計算
        Vector3 movePos = Vector3.MoveTowards(this.transform.position, this.bossTrs.position, this.moveSpeed * Time.deltaTime);
        this.transform.position = movePos;
    }

    // OnTrigger時の処理
    public override void StateOnTriggerEnter(Collider _other)
    {
        if (_other.tag == "BossEnemy")
        {
            //Instantiate(damageFX, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
