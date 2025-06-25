using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera: MonoBehaviour
{
    private Vector3 diff; //カメラとプレイヤーの距離
    private GameObject target; //追従するターゲットオブジェクト
    public float followSpeed; //追従するスピード

    void Start()
    {
        target = GameObject.Find("Player"); //名前がPlayerのオブジェクトを取得してターゲットに指定
        diff = target.transform.position - this.transform.position; //カメラとプレイヤーの初期の距離を指定
    }

    void LateUpdate()
    {
        Vector3 targetPos = target.transform.position - diff;
        targetPos.z = transform.position.z; // Z軸固定
        targetPos.x = Mathf.Round(targetPos.x * 100f) / 100f;
        targetPos.y = Mathf.Round(targetPos.y * 100f) / 100f;

        transform.position = targetPos;
    }
    
}
