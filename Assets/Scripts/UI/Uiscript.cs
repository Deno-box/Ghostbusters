using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class  Uiscript: MonoBehaviour
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
    private int[] scorePoint = new int[(int)GameDataManager.SCORE_TYPE.ALL_TYPE];


    //トータルスコア
    private int totalScore = 0;

    //判定の数
    private int[] decisionNum = new int[(int)GameDataManager.SCORE_TYPE.ALL_TYPE];



    // Start is called before the first frame update
    void Start()
    {
        // スコア値,判定の数初期化
        for (int i = 0; i < (int)GameDataManager.SCORE_TYPE.ALL_TYPE; i++)
        {
           this. scorePoint[i] = 0;
            decisionNum[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {


        //GameDataMnagerからデータを持ってくる
        for(int i=0;i<(int)GameDataManager.SCORE_TYPE.ALL_TYPE;i++)
        {
            scorePoint[i] = GameDataManager.GetScore(i);
            decisionNum[i] = GameDataManager.GetDecisionNum(i);
        }


        
        //トータルスコアの計算
        for (int i = 0; i < (int)GameDataManager.SCORE_TYPE.ALL_TYPE; i++)
        {
            this.totalScore += scorePoint[i] * decisionNum[i];
                        
            if(totalScore < 0)
            {
                totalScore = 0;
            }

           
        }


           
     //各スコアの表示
     greatText.text = "Great x" + decisionNum[0].ToString();
     goodText.text  = "Good x"  + decisionNum[1].ToString();
     missText.text  = "Miss x"  + decisionNum[2].ToString();
     totalText.text = "TotalScore" + totalScore.ToString();     
        
    }
}
