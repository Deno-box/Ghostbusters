using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    // 追跡するターゲット
    [SerializeField]
    private GameObject target = null;
    // 追跡する速度
    [SerializeField]
    private float followSpeed = 0.0f;

    // カメラとターゲットとのオフセット
    private Vector3 offset;
    // 移動先の座標
    private Vector3 moveNextPos;


    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - target.transform.position;
        moveNextPos = this.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vel = target.transform.position - moveNextPos;
        vel *= followSpeed * Time.deltaTime;
        // オフセットでオフセットできてるのは座標のみで回転を考慮していないため意図しない挙動を起こす
        moveNextPos += vel;
        this.transform.position = moveNextPos;// + offset;
        Vector3 rot = new Vector3(target.transform.eulerAngles.x, target.transform.eulerAngles.y, target.transform.eulerAngles.z);
        this.transform.rotation = Quaternion.Euler(this.transform.eulerAngles.x, rot.y, rot.z);
        //this.transform.RotateAround(target.transform.position, Vector3.up, 0.1f);// (rot);
        //this.transform.rotation = target.transform.rotation;
    }
}
