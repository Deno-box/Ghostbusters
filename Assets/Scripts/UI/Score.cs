using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // スコア用テキスト
    [SerializeField]
    Text scoreText;

    // スコア
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // テキスト更新(7桁で表示)
        this.scoreText.text = this.score.ToString("D7");
    }

    // スコアを追加する
    public void AddScore(int[] _score,int _greatNum, int _goodNum, int _missNum)
    {
      
    }
}
