using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Uiscript : MonoBehaviour
{
    //良判定のテキスト
    [SerializeField]
    Text greatText;

    //可判定のテキスト
    [SerializeField]
    Text goodText;

    //ミス判定のテキスト
    [SerializeField]
    Text missText;

    //トータルスコアのテキスト
    [SerializeField]
    Text totalText;

    //スコア
    int great = 0;
    int good  = 0;
    int miss  = 0;

    //トータルスコア
    int greatScore = 0;
    int goodScore  = 0;
    int missScore  = 0;
    int totalScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameDataMnagerからデータを持ってくる
        this.great = GameDataManager.GetDecisionNum((int)GameDataManager.SCORE_TYPE.GREAT);
        this.good = GameDataManager.GetDecisionNum((int)GameDataManager.SCORE_TYPE.GOOD);
        this.miss = GameDataManager.GetDecisionNum((int)GameDataManager.SCORE_TYPE.MISS);

        //それぞれの数値を取得する
        this.greatScore = GameDataManager.GetScore((int)GameDataManager.SCORE_TYPE.GREAT);
        this.goodScore = GameDataManager.GetScore((int)GameDataManager.SCORE_TYPE.GOOD);
        this.missScore = GameDataManager.GetScore((int)GameDataManager.SCORE_TYPE.MISS);

        //トータルスコアの計算
        totalScore = (great * greatScore) + (good * goodScore) + (miss * missScore);

     //各スコアの表示
     greatText.text = "Great x" + great.ToString();
     goodText.text  = "Good x"  + great.ToString();
     missText.text  = "Miss x"  + miss .ToString();
     totalText.text = "TotalScore" + totalScore.ToString();     
        
    }
}
