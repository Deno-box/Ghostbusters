using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParryState : PlayerState
{
    // パリィの発生時間
    private float parryActiveTime = 0.4f;
    // fast判定
    private float fastJudgeTime   = 0.4f;
    // greatt判定
    private float greatJudgeTime  = 0.0f;
    // good判定
    private float goodJudgeTime   = 0.2f;

    // パリィ判定を行うオブジェクト
    private GameObject parryObj = null;
    private Vector3 parryObjOffset = new Vector3(0.0f,0.8f,1.0f);

    // パリィを発生させてから実際に敵が当たるまでの時間
    private float parryJudgeTime = 0.0f;
    // パリィを行ているか
    private bool isParryActive = false;


    // アニメーション用タイマー
    private float aniamtionTimer;
    private int rotDir = 1;


    // 初期化処理
    public override void Initialize()
    {
        // パリィ用オブジェクトを生成
        if (parryObj == null)
        {
            this.parryObj = Instantiate(Resources.Load("Prefabs/Player/PlayerParryJudgement") as GameObject,this.transform);
            this.parryObj.transform.localPosition = parryObjOffset;
        }
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
        yield return new WaitForSeconds(parryActiveTime);

        // 生成してから一定時間経過していたらアイドル状態に遷移
        if (parryActiveTime <= parryJudgeTime)
            this.state = PlayerStateController.PlayerStateEnum.Idle;
    }

    // パリィ判定用オブジェクトに衝突したら
    public void ParryJudge()
    {
        // アイドル状態に遷移
        //this.state = PlayerStateController.PlayerStateEnum.Idle;

        ParryJudgement();
    }

    // great,good判定を取る
    private void ParryJudgement()
    {
        if (parryJudgeTime <= goodJudgeTime)
            GameDataManager.AddDecisionNum((int)GameDataManager.SCORE_TYPE.GOOD);
        else
        if (parryJudgeTime <= greatJudgeTime)
            GameDataManager.AddDecisionNum((int)GameDataManager.SCORE_TYPE.GREAT);
        else
        if (parryJudgeTime <= fastJudgeTime)
            GameDataManager.AddDecisionNum((int)GameDataManager.SCORE_TYPE.GOOD);
    }

    // 回転させる
    void PlayerRotation()
    {
        float rate = 360.0f / parryActiveTime;
        aniamtionTimer += Time.deltaTime;
        GameObject obj = this.transform.GetChild(3).gameObject;
        obj.transform.localRotation = Quaternion.Euler(-90.0f, 0.0f, aniamtionTimer * rate * rotDir);
    }
}