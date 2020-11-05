using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System.Text.RegularExpressions;

public class PlayerMoveJudge : MonoBehaviour
{
    // プレイヤーの移動を管理
    private PlayerMove playerMove;
    // オブジェクトを判別する時に使用する
    private string keyword = "segment";


    private void Start()
    {
        playerMove = this.transform.parent.GetComponent<PlayerMove>();
    }

    // オブジェクトが通過したら
    private void OnTriggerEnter(Collider other)
    {
        // TODO :: 自分が今いるレーンにも移動してしまう
        if(other.name.Contains(keyword))
        {
            // オブジェクト名から数値を取得
            int num = int.Parse(Regex.Replace(other.name, @"[^0-9]", ""));
            num++;

            // 移動先のパスを取得
            Cinemachine.CinemachineSmoothPath path = other.GetComponentInParent<DollyTrackToSpline>().Path;
            //Cinemachine.CinemachinePath path = other.GetComponentInParent<DollyTrackToSpline>().Path;
            // 移動先のスプラインを取得
            SplineMesh.Spline spline = other.GetComponentInParent<SplineMesh.Spline>();

            // 移動先のパスのPosition
            float pos = 0.0f;
            // 移動先のPositionを計算
            //pos = num * (path.PathLength / spline.nodes.Count);
            pos = path.FindClosestPoint(other.transform.position,0,-1,10);
            Debug.Log(num + " : " + this.transform.parent.GetComponent<Cinemachine.CinemachineDollyCart>().m_Position + " : " + pos);
            //Debug.Log(path.PathLength / (spline.nodes.Count*2));
            // トータルのPositionからWaypointで分割し1セグメント当たりの長さを算出
            // それを元に計算して移動先のPositionを計算

            // 1セグメント当たりの長さがそれぞれ異なっているから意図しない場所に飛ぶ

            // プレイヤーを移動させる
            playerMove.ChangeMovePath(path, pos);

            this.gameObject.SetActive(false);
        }
    }
}
