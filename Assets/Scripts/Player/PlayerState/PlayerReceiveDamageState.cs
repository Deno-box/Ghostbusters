using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReceiveDamageState : PlayerState
{
    // 初期化処理
    public override void Initialize()
    {
        this.state = this.state = PlayerStateController.PlayerStateEnum.ReceiveDamage;
    }

    // 実行処理
    public override void Execute()
    {
        Debug.Log("Damage");
    }

    // 終了処理
    public override void Exit()
    {

    }
    // OnTrigger処理
    public override void StateOnTrigger(Collider _other)
    {

    }
}