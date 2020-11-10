using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataManager : MonoBehaviour
{
    // スコア用UI
    [SerializeField]
    Text scoreText = null;
    private Score scoreScript;

    // トータルスコア
    private static int totalScore = 0;
    public static int TotalScore
    {
        get { return totalScore; }
        set { totalScore = value; }
    }

    // 良判定スコア
    [SerializeField]
    int great = 0;
    private static int greatScore = 0;
    public static int GreatScore
    {
        get { return greatScore; }
    }

    // 可判定スコア
    [SerializeField]
    int good = 0;
    private static int goodScore = 0;
    public static int GoodScore
    {
        get { return goodScore; }
    }

    // ミス判定スコア
    [SerializeField]
    int miss = 0;
    private static int missScore = 0;
    public static int MissScore
    {
        get { return missScore; }
    }

    // 敵の総撃破数
    private static int killedEnemyNum = 0;
    public static int KilledEnemyNum
    {
        get { return killedEnemyNum; }
        set { killedEnemyNum = value; }
    }

    // 良判定の数
    private static int greatDecisionNum = 0;
    public static int GreatDecisionNum
    {
        get { return greatDecisionNum; }
        set { greatDecisionNum = value; }
    }

    // 可判定の数
    private static int goodDecisionNum = 0;
    public static int GoodDecisionNum
    {
        get { return goodDecisionNum; }
        set { goodDecisionNum = value; }
    }

    // ミス判定の数
    private static int missDecisionNum = 0;
    public static int MissDecisionNum
    {
        get { return missDecisionNum; }
        set { missDecisionNum = value; }
    }

    void Awake()
    {
        greatScore = this.great;
        goodScore = this.good;
        missScore = this.miss;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.scoreScript = this.scoreText.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        //this.scoreScript.AddScore();
    }
}
