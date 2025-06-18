using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movejump : MonoBehaviour
{
    //���E�ړ������
    [SerializeField] float m_movePower = 1f;
    //�W�����v��
    [SerializeField] float m_jumpSpeed = 1f;
    //�J���[
    [SerializeField] Color[] m_color = default;
    Rigidbody2D m_rb = default;

    private int jumpCount = 0;
    public int maxJumpCount = 1; // 1�i�W�����v


    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        m_rb.velocity = new Vector2(moveX * m_movePower,m_rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("�����ɃW�����v���鏈���������B");


            if (jumpCount < maxJumpCount)
            {
                m_rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
                jumpCount++;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // "Ground"�^�O���t�����I�u�W�F�N�g�ɐڂ��Ă��邩�𔻒�
        if (collision.transform.CompareTag("Untagged"))
        {
            jumpCount = 0;

        }
    }
    }