using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DollyTrackToSpline : MonoBehaviour
{
    // 追跡用のパス
    [SerializeField]
    private CinemachineSmoothPath path = null;
    // スプライン
    private SplineMesh.Spline spline = null;

    // Waypointsの要素数
    private float waypointMax = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //this.path   = this.GetComponent<CinemachineSmoothPath>();   
        this.spline = this.GetComponent<SplineMesh.Spline>();

        // waypointsの要素数を取得
        waypointMax = this.path.m_Waypoints.Length;

        this.spline.nodes.Clear();

        for (int i = 0; i < waypointMax; i++)
        {
            Vector3 offset = path.gameObject.transform.position;

            CinemachineSmoothPath.Waypoint waypoint = this.path.m_Waypoints[i];
            Vector3 pos = waypoint.position;

            int nextIndex = i+1;
            if (i == waypointMax-1)
                nextIndex = i;
                

            Vector3 nextPos = this.path.m_Waypoints[nextIndex].position;
            Vector3 direction = nextPos - pos;

            SplineMesh.SplineNode node = new SplineMesh.SplineNode(pos + offset, direction);
            this.spline.nodes.Add(node);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
