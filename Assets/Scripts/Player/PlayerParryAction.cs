using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerParryAction : MonoBehaviour
{
    // パリィの発生時間
    [SerializeField]
    private float parryActiveTime = 0.0f;
    // fast判定
    [SerializeField]
    private float fastJudgeTime = 0.0f;
    // perfect判定
    [SerializeField]
    private float greatJudgeTime = 0.0f;
    // good判定
    [SerializeField]
    private float goodJudgeTime = 0.0f;

    // パリィ判定を行うオブジェクト
    [SerializeField]
    private GameObject parryObj = null;

    // パリィを発生させてから実際に敵が当たるまでの時間
    private float parryJudgeTime = 0.0f;
    // パリィを行ているか
    private bool isParryActive = false;


    // Start is called before the first frame update
    void Start()
    {
        parryObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 左右クリックでパリィを行う
        if (isParryActive == false      &&
            Input.GetMouseButtonDown(1) || 
            Input.GetMouseButtonDown(0))
            Parry();

        // パリィを行っていたら判定用タイマーを増加
        if (isParryActive)
            parryJudgeTime += Time.deltaTime;
    }

    // マウスクリックでパリィを行う
    private void Parry()
    {
        StartCoroutine("ParryCoroutine");
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

        // 生成してから一定時間経過していたら非アクティブにする
        if (parryActiveTime <= parryJudgeTime)
        {
            // 一定時間経過後パリィ判定用オブジェクトを非アクティブにする
            parryObj.SetActive(false);
            // パリィアクティブ状態を解除
            isParryActive = false;
        }
    }

    // パリィ判定用オブジェクトに衝突したら
    public void ParryJudgeCollision()
    {
        // パリィ判定用オブジェクトを非アクティブにする
        parryObj.SetActive(false);
        // パリィアクティブ状態を解除
        isParryActive = false;

        ParryJudgement();
    }

    // great,good判定を取る
    private void ParryJudgement()
    {
        if (parryJudgeTime <= goodJudgeTime)
            GameDataManager.AddDecisionNum(GameDataManager.SCORE_TYPE.GOOD);
        else
        if (parryJudgeTime <= greatJudgeTime)
            GameDataManager.AddDecisionNum(GameDataManager.SCORE_TYPE.GREAT);
        else
        if (parryJudgeTime <= fastJudgeTime)
            GameDataManager.AddDecisionNum(GameDataManager.SCORE_TYPE.GOOD);
    }
}
