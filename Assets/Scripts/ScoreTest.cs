using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Xキー押下
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameDataManager.GreatDecisionNum++;
        }
        // Yキー押下
        if (Input.GetKeyDown(KeyCode.Y))
        {
            GameDataManager.GoodDecisionNum++;
        }
        // Zキー押下
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameDataManager.MissDecisionNum++;
        }

    }
}
