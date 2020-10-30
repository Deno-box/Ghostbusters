﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[ExecuteAlways]
// オブジェクトに一つしか追加できないようにする
[DisallowMultipleComponent]

public class DollyTrackToSpline : MonoBehaviour
{
    // 追跡用のパス
    [SerializeField]
    private CinemachineSmoothPath path = null;
    // スプライン
    private SplineMesh.Spline spline = null;

    // Waypointsの要素数
    private float waypointMax = 0.0f;

    // テッセレーションの値(どれだけ細かく刻むか)
    [SerializeField]
    private int tessellation = 0;

    // Start is called before the first frame update
    void Awake()
    {
        // 自身のスプラインを取得
        this.spline = this.GetComponent<SplineMesh.Spline>();

        // waypointsの要素数を取得
        this.waypointMax = this.path.m_Waypoints.Length;
        // SplineNodeの座標を設定
        CreateSplineWayPoint();

    }

    // スプラインにWayPointを追加
    void CreateSplineWayPoint()
    {
        // ノードを初期化
        this.spline.nodes.Clear();
        // テッセレーションを設定
        this.tessellation = Mathf.Max(this.tessellation, 1);
        // pathの座標を計算するときに使用する
        float step = 1.0f / this.tessellation;
        // 追加するノードの最大値を計算
        int positionCount = ((int)(this.path.MaxPos - this.path.MinPos) * this.tessellation) + 1;
        // WayPointを生成
        for (var i = 0; i < positionCount; i++)
        {
            // 追加する座標を取得
            Vector3 pos = this.path.EvaluatePosition(i * step);
            // ノードを作成、追加
            SplineMesh.SplineNode node = new SplineMesh.SplineNode(pos, Vector3.up);
            this.spline.nodes.Add(node);
        }
    }
}
