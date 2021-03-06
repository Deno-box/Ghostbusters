﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMoveLRState : PlayerState
{
    // プレイヤーのステータスデータ
    private PlayerStatusData playerStatus = null;

    // 追従するオブジェクト
    private CinemachineDollyCart myCart = null;
    // TODO : publicになってしまっている　要変更
    // 左右どちらのキーが押されたか
    public PlayerMoveData.MoveDir moveDir = PlayerMoveData.MoveDir.None;
    // 移動時間
    private float moveTimer    = 0.0f;

    // 移動可能範囲のリスト
    private PlayerMoveDataList playerMoveData;

    private GameObject nextPosObj = null;
    private bool isMove = false;
    private GameObject playerModel = null;


    private void Awake()
    {
        this.playerStatus = Resources.Load("PlayerStatus") as PlayerStatusData;
        playerMoveData = Resources.Load("PlayerMoveData/TestScene/TestStagePlayerMoveData") as PlayerMoveDataList;

        playerModel = this.transform.GetChild(3).gameObject;

        myCart = this.GetComponent<CinemachineDollyCart>();

        this.nextPosObj = new GameObject();
        this.nextPosObj.AddComponent<CinemachineDollyCart>();
        this.nextPosObj.transform.parent = this.transform;
    }

    // 初期化処理
    public override void Initialize()
    {
        this.state = PlayerStateController.PlayerStateEnum.MoveLR;
        // TODO : このデータの読み込みを変更する(Stage1,Stage2のようなデータをどこかに保管しておく)
        if (!this.playerMoveData)

        isMove = false;
        this.moveTimer = 0.0f;

        isMove = ChangeMove();

    }

    // 実行処理
    public override void Execute()
    {
        ////Debug.Log("MoveLR");

        this.moveTimer += Time.deltaTime;
        if(moveTimer>= this.playerStatus.moveTime)
            state = PlayerStateController.PlayerStateEnum.Idle;

        //if (moveTimer >= moveTimerMax*0.8f && Input.GetKeyDown(KeyCode.Space))
        //    this.state = PlayerStateController.PlayerStateEnum.Parry;

        if(this.isMove)
        {
            // TODO : 仮の状態 移動方向に応じて回転方向を変更する
            float dir = 1.0f;
            if (moveDir == PlayerMoveData.MoveDir.Right)
                dir = -1.0f;

            this.transform.position = Vector3.Lerp(this.transform.position, nextPosObj.transform.position, moveTimer *(1- this.playerStatus.moveTime));
            float rate = 360.0f / this.playerStatus.moveTime;
            playerModel.transform.rotation = Quaternion.Euler(new Vector3(moveTimer * rate * dir - 90.0f, -90.0f,90.0f));
        }
        else
            state = PlayerStateController.PlayerStateEnum.Idle;

    }

    // 終了処理
    public override void Exit()
    {
        // 移動していたら
        if (this.isMove)
        {
            myCart.m_Path = nextPosObj.GetComponent<CinemachineDollyCart>().m_Path;
            myCart.m_Position = nextPosObj.GetComponent<CinemachineDollyCart>().m_Position;
            myCart.enabled = true;
            playerModel.transform.rotation = Quaternion.Euler(new Vector3(-90.0f, 0.0f, 0.0f));
        }
    }


    // 移動するパスを変更
    public void ChangeMovePath(CinemachinePathBase _path, float _position = 0.0f)
    {
        // 移動先用の座標を取得
        nextPosObj.GetComponent<CinemachineDollyCart>().m_Path     = _path;
        nextPosObj.GetComponent<CinemachineDollyCart>().m_Position = _position;


        this.isMove    = true;
        myCart.enabled = false;
    }

    // キャラクターを移動させる
    private bool ChangeMove()
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

                float speed = this.GetComponent<CinemachineDollyCart>().m_Speed;
                // TODO : 誤差をマジックナンバーで修正している
                changePos += this.playerStatus.moveTime * speed + 0.9f;


                // 移動を開始
                ChangeMovePath(data.changePath, changePos);
                Debug.Log(data.changePath.name);
                return true;

                //break;
            }
        }

        // 移動キーをリセット
        //moveDir = PlayerMoveData.MoveDir.None;

        return false;
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