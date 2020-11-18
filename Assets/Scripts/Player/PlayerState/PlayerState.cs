using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : MonoBehaviour
{
    // 実行しているステート
    protected PlayerStateController.PlayerStateEnum state;
    public PlayerStateController.PlayerStateEnum State { get { return state; } }

    // 初期化処理
    public abstract void Initialize();

    // 実行処理
    public abstract void Execute();

    // 終了処理
    public abstract void Exit();

    // OnTrigger処理
    public abstract void StateOnTrigger(Collider _other);
}
