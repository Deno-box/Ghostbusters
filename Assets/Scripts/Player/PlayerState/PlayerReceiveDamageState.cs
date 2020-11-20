using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReceiveDamageState : PlayerState
{
    // プレイヤーのステータスデータ
    private PlayerStatusData playerStatus = null;

    // 被ダメージ状態での経過時間
    private float damageTimer;
    // 点滅時間
    private float brinkInterval = 0.15f;


    private GameObject playerModel;

    private void Awake()
    {
        this.playerStatus = Resources.Load("PlayerStatus") as PlayerStatusData;
        playerModel = this.transform.GetChild(3).gameObject;
    }

    // 初期化処理
    public override void Initialize()
    {
        this.state = PlayerStateController.PlayerStateEnum.ReceiveDamage;
        damageTimer = 0.0f;

        StartCoroutine("BlinkRenderer");
    }

    // 実行処理
    public override void Execute()
    {
        this.damageTimer += Time.deltaTime;
        //if (this.damageTimer >= playerStatus.damageInvincibleTime)
        //    this.state = PlayerStateController.PlayerStateEnum.Idle;
    }

    // 終了処理
    public override void Exit()
    {
        playerModel.SetActive(true);
    }
    // OnTrigger処理
    public override void StateOnTrigger(Collider _other)
    {

    }

    // TODO :: 演出用の処理で状態変更を行っているので変更する
    IEnumerator BlinkRenderer()
    {
        while (true)
        {
            playerModel.active = !playerModel.active;
            if (this.damageTimer >= playerStatus.damageInvincibleTime)
            {
                this.state = PlayerStateController.PlayerStateEnum.Idle;
                break;
            }
            yield return new WaitForSeconds(this.brinkInterval);
        }
    }
}