using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemyBullet : MonoBehaviour
{
    public enum BulletState
    {
        EnemyBullet,    // 敵の弾の状態
        Parry,          // はじかれた後の状態
        None            // 初期化
    }

    // ボスのトランスフォーム
    private Transform bossTrs = null;
    public  Transform BossTrs { set { bossTrs = value; } }

    // 跳ね返るときの弾の速度
    [SerializeField]
    private float moveSpeed;
    // 自身のステート
    private BulletState state = BulletState.EnemyBullet;
    private IBulletState bulletActiveState;
    private IBulletState[] stateList = new IBulletState[2];


    private void Start()
    {
        stateList[0] = new EnemyBulletState();
        stateList[1] = new EnemyBulletParryState();

        bulletActiveState = stateList[0];
    }

    // Update is called once per frame
    void Update()
    {
        bulletActiveState = stateList[(int)this.bulletActiveState.Update()];
    }
    
    private void OnTriggerEnter(Collider _other)
    {
        this.bulletActiveState.OnTriggerEnter(_other);
    }
}
