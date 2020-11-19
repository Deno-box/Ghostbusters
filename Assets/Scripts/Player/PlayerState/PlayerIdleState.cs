﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    // 初期化処理
    public override void Initialize()
    {
        this.state = PlayerStateController.PlayerStateEnum.Idle;
    }

    // 実行処理
    public override void Execute()
    {
        // TODO : 左右キー判定やマウスの左右判定はこのクラスで判定しているため、後で変更しておく
        
        // スペースキーでパリィ状態に遷移
        if (Input.GetKeyDown(KeyCode.Space))
            this.state = PlayerStateController.PlayerStateEnum.Parry;
        // Aキーで左のパスに移動
        else
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // 左入力キーを設定
            this.GetComponent<PlayerMoveLRState>().moveDir = PlayerMoveData.MoveDir.Left;
            this.state = PlayerStateController.PlayerStateEnum.MoveLR;
        }
        // Dキーで左のパスに移動
        else
        if (Input.GetKeyDown(KeyCode.RightArrow))
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
