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


    // Update is called once per frame
    void Update()
    {
        // 追跡するパスを変更
        myCaart.m_Path = pathList[index];

        // Aキーで左のパスに移動
        if (Input.GetKeyDown(KeyCode.A))
            index--;
        // Dキーで左のパスに移動
        else
        if (Input.GetKeyDown(KeyCode.D))
            index++;

        // TODO :: インデックスの範囲制限
        index = Mathf.Clamp(index, 0, pathList.Length-1);
    }
}
