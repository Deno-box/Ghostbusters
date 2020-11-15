using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    // 追従するオブジェクト
    private CinemachineDollyCart myCaart = null;

    // 左右どちらのキーが押されたか
    private PlayerMoveData.MoveDir moveDir = PlayerMoveData.MoveDir.None;
    // 移動可能範囲のリスト
    [SerializeField]
    private List<PlayerMoveData> playerMoveDatas = new List<PlayerMoveData>();

    // 初期化処理
    private void Awake()
    {
        // 操作するDollyCartを設定
        myCaart = this.GetComponent<CinemachineDollyCart>();
    }

    // Update is called once per frame
    void Update()
    {
        // Aキーで左のパスに移動
        if (Input.GetKeyDown(KeyCode.A))
        {
            // 左入力キーを設定
            moveDir = PlayerMoveData.MoveDir.Left;
            ChangeMove();
        }
        // Dキーで左のパスに移動
        else
        if (Input.GetKeyDown(KeyCode.D))
        {
            // 右入力キーを設定
            moveDir = PlayerMoveData.MoveDir.Right;
            ChangeMove();
        }
    }

    // 移動するパスを変更
    public void ChangeMovePath(CinemachinePathBase _path,float _position = 0.0f)
    {
        myCaart.m_Path     = _path;
        myCaart.m_Position = _position;
    }

    // キャラクターを移動させる
    private void ChangeMove()
    {
        // 移動データを参照
        foreach (PlayerMoveData data in playerMoveDatas)
        {
            // 移動可能範囲内か
            if (CheckMovePossible(data))
            {
                // ポジションを修正
                float pos = myCaart.m_Position - data.nowPosMin;
                float maxPos = data.nowPosMax - data.nowPosMin;

                // 現在のパスで割合を計算
                float nowPosPer = pos / maxPos;
                nowPosPer = Mathf.Clamp(nowPosPer, 0.0f, 1.0f);

                // 移動先のPositionを計算
                float changePosMax = data.changePosMax - data.changePosMin;
                float changePos = changePosMax * nowPosPer + data.changePosMin;

                // 移動を開始
                ChangeMovePath(data.changePath,changePos);

                break;
            }
        }

        // 移動キーをリセット
        moveDir = PlayerMoveData.MoveDir.None;
    }

    // 移動可能なのかを判定
    private bool CheckMovePossible(PlayerMoveData _data)
    {
        // 現在のPosition
        float position = myCaart.m_Position;

        // パスの名前は一致しているか / 移動可能範囲内か / 入力されたキーは一致しているか
        if (myCaart.m_Path.name == _data.nowPath.name
            && GhosterUtility.CalculationUtility.IsWithinRange(position, _data.nowPosMin, _data.nowPosMax)
            && moveDir == _data.moveDir)
            return true;

        return false;
    }
}
