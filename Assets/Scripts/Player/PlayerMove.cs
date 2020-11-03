using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    // 追従するオブジェクト
    [SerializeField]
    private CinemachineDollyCart myCaart = null;
    // 追従するパスのリスト
    [SerializeField]
    private CinemachineSmoothPath[] pathList = null;
    // 追従するパスの番号
    [SerializeField]
    private int index = 0;
    // 右の移動用当たり判定
    [SerializeField]
    private GameObject moveJudgeObj_R = null;
    // 左の移動用当たり判定
    [SerializeField]
    private GameObject moveJudgeObj_L = null;

    // 初期化処理
    private void Start()
    {
        // 左右の移動用当たり判定を非アクティブにする
        moveJudgeObj_R.SetActive(false);
        moveJudgeObj_L.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        // 追跡するパスを変更
        //myCaart.m_Path = pathList[index];

        // Aキーで左のパスに移動
        if (Input.GetKeyDown(KeyCode.A))
            this.moveJudgeObj_L.SetActive(true);
        // Dキーで左のパスに移動
        else
        if (Input.GetKeyDown(KeyCode.D))
            this.moveJudgeObj_R.SetActive(true);

        // TODO :: インデックスの範囲制限
        //index = Mathf.Clamp(index, 0, pathList.Length-1);
    }

    // 移動するパスを変更
    public void ChangeMovePath(CinemachinePath path,float position = 0.0f)
    {

    }
}
