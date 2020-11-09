using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    // Managerゲームオブジェクト
    [SerializeField]
    GameObject manager;

    // Managerスクリプト格納用
    GameDataManager gameDataManager; 


    // Start is called before the first frame update
    void Start()
    {
        // Managerスクリプト取得
        gameDataManager = manager.GetComponent<GameDataManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Xキー押下
        if (Input.GetKeyDown(KeyCode.X))
        {

        }
        // Yキー押下
        if (Input.GetKeyDown(KeyCode.Y))
        {

        }
        // Zキー押下
        if (Input.GetKeyDown(KeyCode.Z))
        {

        }

    }
}
