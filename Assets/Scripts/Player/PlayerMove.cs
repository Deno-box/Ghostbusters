using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerMove : MonoBehaviour
{
    // 追従するオブジェクト
    [SerializeField]
    private CinemachineDollyCart myCaart = null;
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
        // Aキーで左のパスに移動
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.moveJudgeObj_L.SetActive(true);
            StartCoroutine("MoveJudgrObjNotEnabled");
        }
        // Dキーで左のパスに移動
        else
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.moveJudgeObj_R.SetActive(true);
            StartCoroutine("MoveJudgrObjNotEnabled");
        }
    }

    // 移動するパスを変更

    public void ChangeMovePath(CinemachineSmoothPath path,float position = 0.0f)
    //public void ChangeMovePath(CinemachinePath path,float position = 0.0f)
    {
        myCaart.m_Path = path;
        //myCaart.m_Position = position;
    }

    // 0.1秒後に移動用オブジェクトを非アクティブにするコルーチン
    private IEnumerator MoveJudgrObjNotEnabled()
    {
        yield return new WaitForSeconds(0.1f);
        moveJudgeObj_R.SetActive(false);
        moveJudgeObj_L.SetActive(false);
    }
}
