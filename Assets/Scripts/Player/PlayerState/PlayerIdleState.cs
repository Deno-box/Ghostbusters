using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    // 初期化処理
    public override void Initialize()
    {
        state = PlayerStateController.PlayerStateEnum.Idle;
    }

    // 実行処理
    public override void Execute()
    {
        // マウスクリックでパリィ状態に遷移
        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
            this.state = PlayerStateController.PlayerStateEnum.Parry;
        // ADキーで左右移動状態に遷移
        else
        // Aキーで左のパスに移動
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 左入力キーを設定
            this.GetComponent<PlayerMoveLRState>().moveDir = PlayerMoveData.MoveDir.Left;
            this.state = PlayerStateController.PlayerStateEnum.MoveLR;
        }
        // Dキーで左のパスに移動
        else
        if (Input.GetKeyDown(KeyCode.D))
        {
            // 右入力キーを設定
            this.GetComponent<PlayerMoveLRState>().moveDir = PlayerMoveData.MoveDir.Right;
            this.state = PlayerStateController.PlayerStateEnum.MoveLR;
        }

    }
    // 終了処理
    public override void Exit()
    {

    }

    // OnTrigger処理
    public override void StateOnTrigger(Collider _other)
    {
        // 敵の衝突範囲内に入ったら非ダメージ状態に遷移
        if (_other.tag == "EnemyBullet")
            this.state = PlayerStateController.PlayerStateEnum.ReceiveDamage;
    }
}
