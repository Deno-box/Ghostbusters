using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    // 追跡するターゲット
    [SerializeField]
    private GameObject target = null;
    // 移動速度
    [SerializeField]
    private float moveSpeed = 0.0f;
    // 回転速度
    [SerializeField]
    private float rotSpeed = 0.0f;

    // カメラとターゲットとのオフセット
    private Vector3 offset;
    private Vector3 offsetRot;


    // Start is called before the first frame update
    void Start()
    {
        offset = this.transform.position - target.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // オフセットでオフセットできてるのは座標のみで回転を考慮していないため意図しない挙動を起こす
        this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + offset, moveSpeed * Time.deltaTime);
        // 回転
        var vectorToTarget = target.transform.position - this.transform.position;
        var targetRotate = Quaternion.LookRotation(vectorToTarget);
        var newRotate = Quaternion.Lerp(this.transform.rotation, targetRotate, rotSpeed * Time.deltaTime).eulerAngles;
        this.transform.rotation = Quaternion.Euler(newRotate);
    }
}
