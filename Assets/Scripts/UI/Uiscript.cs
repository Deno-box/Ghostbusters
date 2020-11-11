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
     //great = GameDataManager.GreatDecisionNum;
     //good = GameDataManager.GoodDecisionNum;
     //miss = GameDataManager.MissDecisionNum;

     //それぞれの数値を取得する
     //greatScore = GameDataManager.GreatScore;
     //goodScore = GameDataManager. GoodScore;
     //missScore = GameDataManager. MissScore;

   　//トータルスコアの計算
    totalScore = (great * greatScore) + (good * goodScore) + (miss * missScore);

     //各スコアの表示
     greatText.text = "Great x" + great.ToString();
     goodText.text  = "Good x"  + great.ToString();
     missText.text  = "Miss x"  + miss .ToString();
     totalText.text = "TotalScore" + totalScore.ToString();     
        
    }
}
