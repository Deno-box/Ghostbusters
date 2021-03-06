﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


using UnityEngine.UI;

public class PlayerIdleState : PlayerState
{
    // プレイヤーのステータスデータ
    private PlayerStatusData playerStatus = null;

    private GameObject damageObj = null;
    private Vector3 parryObjOffset = new Vector3(0.0f, 1.0f, -3.0f);

    private CinemachineDollyCart myCart = null;
    private float pathLength = 0.0f;


    private Image alertImage;

    private void Awake()
    {
        this.playerStatus = Resources.Load("PlayerStatus") as PlayerStatusData;

        alertImage = GameObject.Find("Alert").GetComponent<Image>();
        alertImage.enabled = false;
    }

    // 初期化処理
    public override void Initialize()
    {
        // パリィ用オブジェクトを生成
        if (this.damageObj == null)
        {
            this.damageObj = Instantiate(Resources.Load("Prefabs/Player/PlayerDamageJudgement") as GameObject, this.transform);
            this.damageObj.transform.localPosition = parryObjOffset;
        }
        this.damageObj.SetActive(true);

        this.myCart = this.GetComponent<CinemachineDollyCart>();
        this.pathLength = this.myCart.m_Path.PathLength;

        this.state = PlayerStateController.PlayerStateEnum.Idle;
    }

    // 実行処理
    public override void Execute()
    {
        // TODO : 左右キー判定やマウスの左右判定はこのクラスで判定しているため、後で変更しておく
        //Alert
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

        // レーンの端まで到着すると落下状態に遷移
        if (this.pathLength * this.playerStatus.fallJudgeRate <= this.myCart.m_Position)
            this.state = PlayerStateController.PlayerStateEnum.Fall;
        // 警告ゾーンに入るとUIを有効化
        if (this.pathLength - this.playerStatus.alertDistance <= this.myCart.m_Position)
        {
            alertImage.enabled = true;
        }
        else
            alertImage.enabled = false;
    }
    // 終了処理
    public override void Exit()
    {
        this.damageObj.SetActive(false);
        alertImage.enabled = false;
    }

    // 被ダメージ状態に遷移
    public void ReceiveDamage()
    {
        // 被ダメージ状態に遷移
        this.state = PlayerStateController.PlayerStateEnum.ReceiveDamage;
    }
}
