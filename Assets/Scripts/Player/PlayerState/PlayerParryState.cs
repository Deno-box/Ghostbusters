using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParryState : PlayerState
{
    // プレイヤーのステータスデータ
    private PlayerStatusData playerStatus = null;

    // パリィ判定を行うオブジェクト
    private GameObject parryObj = null;
    private Vector3 parryObjOffset = new Vector3(0.0f,0.8f,1.0f);

    // パリィを発生させてから実際に敵が当たるまでの時間
    private float parryJudgeTime = 0.0f;
    // パリィを行ているか
    private bool isParryActive = false;
    // パリィ成功時のエフェクト
    private GameObject parrysuccessFx;


    // アニメーション用タイマー
    private float aniamtionTimer;
    private int rotDir = 1;

    private GameObject rotObj=null;

    private void Awake()
    {
        this.playerStatus = Resources.Load("PlayerStatus") as PlayerStatusData;
        this.parrysuccessFx = Resources.Load("FX/CFX_Poof") as GameObject;

        this.parryObj = Instantiate(Resources.Load("Prefabs/Player/PlayerParryJudgement") as GameObject, this.transform);
        parryObj.SetActive(false);

        this.parryObj.transform.localPosition = parryObjOffset;
    }

    // 初期化処理
    public override void Initialize()
    {
        parryObj.SetActive(false);

        isParryActive = false;
        parryJudgeTime = 0.0f;
        this.state = PlayerStateController.PlayerStateEnum.Parry;

        // TODO: 変えておく
        if (this.rotDir == 1)
            this.rotDir = -1;
        else
            this.rotDir = 1;

        aniamtionTimer = 0.0f;


        if (!rotObj)
            rotObj = this.transform.GetChild(3).gameObject;
    }

    // 実行処理
    public override void Execute()
    {
        //Debug.Log("Parry");

        // パリィを発生していなかったら発生させる
        if (isParryActive == false)
            StartCoroutine("ParryCoroutine");

        // パリィを行っていたら判定用タイマーを増加
        if (isParryActive)
            parryJudgeTime += Time.deltaTime;

        PlayerRotation();
    }
    // 終了処理
    public override void Exit()
    {
        // 一定時間経過後パリィ判定用オブジェクトを非アクティブにする
        parryObj.SetActive(false);

        GameObject obj = this.transform.GetChild(3).gameObject;
        obj.transform.localRotation = Quaternion.Euler(-90.0f, 0.0f, 0.0f);
    }

    // OnTrigger処理
    public override void StateOnTrigger(Collider _other)
    {
        this.state = PlayerStateController.PlayerStateEnum.Idle;
    }

    // パリィを発生させるコルーチン
    private IEnumerator ParryCoroutine()
    {
        // パリィ判定用オブジェクトをアクティブにする
        parryObj.SetActive(true);
        // 判定用のタイマーをリセット
        parryJudgeTime = 0.0f;
        // パリィアクティブ状態に移行
        isParryActive = true;

        // parryActimeTimeの間処理を停止する
        yield return new WaitForSeconds(this.playerStatus.parryActiveTime);

        // 生成してから一定時間経過していたらアイドル状態に遷移
        if (this.playerStatus.parryActiveTime <= parryJudgeTime)
            this.state = PlayerStateController.PlayerStateEnum.Idle;
    }

    // パリィ判定用オブジェクトに衝突したら
    public void ParryJudge()
    {
        // アイドル状態に遷移
        //this.state = PlayerStateController.PlayerStateEnum.Idle;

        //Instantiate(parrysuccessFx, this.transform);
        ParryJudgement();
    }

    // great,good判定を取る
    private void ParryJudgement()
    {
        if (parryJudgeTime <= this.playerStatus.goodJudgeDistance)
            GameDataManager.AddDecisionNum((int)GameDataManager.SCORE_TYPE.GOOD);
        else
        if (parryJudgeTime <= this.playerStatus.greatJudgeDistance)
            GameDataManager.AddDecisionNum((int)GameDataManager.SCORE_TYPE.GREAT);
    }

    // 回転させる
    void PlayerRotation()
    {
        float rate = 360.0f / this.playerStatus.parryActiveTime;
        aniamtionTimer += Time.deltaTime;
        rotObj.transform.localRotation = Quaternion.Euler(-90.0f, 0.0f, aniamtionTimer * rate * rotDir);
    }
}