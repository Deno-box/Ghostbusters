using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    // トータルスコア
    private static int totalScore = 0;
    public static int TotalScore
    {
        get { return totalScore; }
        set { totalScore = value; }
    }

    // 良判定スコア
    [SerializeField]
    int greatScore;
    public int GreateScore
    {
        get { return greatScore; }
    }

    // 可判定スコア
    [SerializeField]
    int goodScore;
    public int GoodScore
    {
        get { return goodScore; }
    }

    // ミス判定スコア
    [SerializeField]
    int missScore;
    public int MissScore
    {
        get { return missScore; }
    }

    // 敵の総撃破数
    private static int killedEnemyNum;
    public static int KilledEnemyNum
    {
        get { return killedEnemyNum; }
        set { killedEnemyNum = value; }
    }

    // 良判定の数
    private static int greatDecisionNum;
    public static int GreatDecisionNum
    {
        get { return greatDecisionNum; }
        set { greatDecisionNum = value; }
    }

    // 可判定の数
    private static int goodDecisionNum;
    public static int GoodDecisionNum
    {
        get { return goodDecisionNum; }
        set { goodDecisionNum = value; }
    }

    // ミス判定の数
    private static int missDecisionNum;
    public static int MissDecisionNum
    {
        get { return missDecisionNum; }
        set { missDecisionNum = value; }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
