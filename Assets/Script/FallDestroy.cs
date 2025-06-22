using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDestroy : MonoBehaviour
{
    private Transform respownPoint;
   
    // Start is called before the first frame update
    void Start()
    {
        // �v���C���[�擾�i"Player" �^�O���g�p�j
        GameObject player = GameObject.FindGameObjectWithTag("Player");
     

        // �v���C���[�̃��X�|�[���ʒu��ݒ�i�����ł͒P���ɐe����T���j
        respownPoint = GameObject.Find("RespownPoint").transform;
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ���X�|�[�������F�v���C���[�̈ʒu�����Z�b�g
            other.transform.position = respownPoint.position;
        }
    }
}
