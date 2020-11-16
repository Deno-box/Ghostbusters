using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// 弾の発射に必要なデータ
[System.Serializable]
public class shootPath
{
    public CinemachinePathBase path;
    public float minPos;
    public float maxPos;
}

// ボス用の弾を生成する
public class BossEnemyBulletGenerator : MonoBehaviour
{
    // 弾のプレハブ
    [SerializeField]
    private GameObject bulletPrefab = null;
    // 弾の発射間隔
    [SerializeField]
    private float shootIntervalMax = 0.0f;
    // 弾の現在のインターバル
    private float shootInterval = 0.0f;
    // 一度に生成する弾の数
    [SerializeField]
    private int instanceBulletNum = 0;
    
    // 生成するパスのリスト
    [SerializeField]
    private List<shootPath> pathList = new List<shootPath>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        shootInterval += Time.deltaTime;
        if (shootInterval >= shootIntervalMax)
        {
            // 指定の個数弾を生成
            for (int i = 0; i < instanceBulletNum; i++)
                ShootBullet();
            shootInterval = 0.0f;
        }
    }

    // 弾を生成
    private void ShootBullet()
    {
        // 生成するレーンの番号を設定
        int laneNum = Random.Range(0, pathList.Count);
        // 生成するポジション
        float pathMaxPos = pathList[laneNum].maxPos - pathList[laneNum].minPos;

        // ボス
        float bossPosPer = this.GetComponent<CinemachineDollyCart>().m_Position / this.GetComponent<CinemachineDollyCart>().m_Path.PathLength;
        float pathPos = pathMaxPos * bossPosPer + pathList[laneNum].minPos;

        Debug.Log("Shoot");

        // 弾を生成
        GameObject obj = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
        obj.GetComponent<CinemachineDollyCart>().m_Path = pathList[laneNum].path;
        obj.GetComponent<CinemachineDollyCart>().m_Position = pathPos;

        obj.transform.parent = this.transform;
    }
}
