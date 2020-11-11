using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataManager : MonoBehaviour
{
    // スコア用
    public enum SCORE_TYPE
    {
        GREAT = 0,  // 良
        GOOD = 1,   // 可
        MISS = 2,   // 不可

        ALL_TYPE,
    }

    // スコア用UI
    [SerializeField]
    Text scoreText = null;
    private Score scoreScript;

    // スコア値格納用
    [NamedArrayAttribute(new string[] { "Great Score", "Good Score", "Miss Score" })]
    [SerializeField]
    int[] scorePoint = new int[(int)SCORE_TYPE.ALL_TYPE];

    // スコア値保存用
    private static int[] score = new int[(int)SCORE_TYPE.ALL_TYPE];

    // 判定の数
    private static int[] decisionNum = new int[(int)SCORE_TYPE.ALL_TYPE];

    void Awake()
    {
        // スコア値の初期化
        for (int i = 0; i < (int)SCORE_TYPE.ALL_TYPE; i++)
        {
            score[i] = this.scorePoint[i];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // スコアスクリプトの取得
        this.scoreScript = this.scoreText.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // スコア値の取得
    static int GetScore(int _scoreType)
    {
        return score[_scoreType];
    }
    
    // 判定数の取得
}
