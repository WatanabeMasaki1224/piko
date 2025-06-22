using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDestroy : MonoBehaviour
{
    private Transform respownPoint;
   
    // Start is called before the first frame update
    void Start()
    {
        // プレイヤー取得（"Player" タグを使用）
        GameObject player = GameObject.FindGameObjectWithTag("Player");
     

        // プレイヤーのリスポーン位置を設定（ここでは単純に親から探す）
        respownPoint = GameObject.Find("RespownPoint").transform;
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // リスポーン処理：プレイヤーの位置をリセット
            other.transform.position = respownPoint.position;
        }
    }
}
