using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMoveLRState : PlayerState
{
    // 追従するオブジェクト
    private CinemachineDollyCart myCart = null;
    // TODO : publicになってしまっている　要変更
    // 左右どちらのキーが押されたか
    public PlayerMoveData.MoveDir moveDir = PlayerMoveData.MoveDir.None;
    // 移動時間
    private float moveTimerMax = 0.1f;
    private float moveTimer    = 0.0f;

    // 移動可能範囲のリスト
    private PlayerMoveDataList playerMoveData;

    // 初期化処理
    public override void Initialize()
    {
        state = PlayerStateController.PlayerStateEnum.MoveLR;
        if (myCart == null)
            myCart = this.GetComponent<CinemachineDollyCart>();
        // TODO : このデータの読み込みを変更する(Stage1,Stage2のようなデータをどこかに保管しておく)
        if (playerMoveData == null)
            playerMoveData = Resources.Load("PlayerMoveData/TestScene/TestStagePlayerMoveData") as PlayerMoveDataList;
        //moveDir = PlayerMoveData.MoveDir.None;

        moveTimer = 0.0f;

        //moveDir = PlayerMoveData.MoveDir.Left;
        ChangeMove();
    }

    // 実行処理
    public override void Execute()
    {
        ////Debug.Log("MoveLR");

        moveTimer += Time.deltaTime;
        if(moveTimer>=moveTimerMax)
            state = PlayerStateController.PlayerStateEnum.Idle;
    }

    // 終了処理
    public override void Exit()
    {

    }

    // OnTrigger処理
    public override void StateOnTrigger(Collider _other)
    {

    }


    // 移動するパスを変更
    public void ChangeMovePath(CinemachinePathBase _path, float _position = 0.0f)
    {
        myCart.m_Path = _path;
        myCart.m_Position = _position;
    }

    // キャラクターを移動させる
    private void ChangeMove()
    {
        // 移動データを参照
        foreach (PlayerMoveData data in playerMoveData.moveDataList)
        {
            // 移動可能範囲内か
            if (CheckMovePossible(data))
            {
                // ポジションを修正
                float pos = myCart.m_Position - data.nowPosMin;
                float maxPos = data.nowPosMax - data.nowPosMin;

                // 現在のパスで割合を計算
                float nowPosPer = pos / maxPos;
                nowPosPer = Mathf.Clamp(nowPosPer, 0.0f, 1.0f);

                // 移動先のPositionを計算
                float changePosMax = data.changePosMax - data.changePosMin;
                float changePos = changePosMax * nowPosPer + data.changePosMin;

                // 移動を開始
                ChangeMovePath(data.changePath, changePos);


                break;
            }
        }

        // 移動キーをリセット
        moveDir = PlayerMoveData.MoveDir.None;
    }

    // 移動可能なのかを判定
    private bool CheckMovePossible(PlayerMoveData _data)
    {
        // 現在のPosition
        float position = myCart.m_Position;

        // パスの名前は一致しているか / 移動可能範囲内か / 入力されたキーは一致しているか
        if (myCart.m_Path.name == _data.nowPath.name
            && GhosterUtility.CalculationUtility.IsWithinRange(position, _data.nowPosMin, _data.nowPosMax)
            && moveDir == _data.moveDir)
            return true;

        return false;
    }
}