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
    private Animator anim;

    [SerializeField] AudioClip jumpSE;          // �� Inspector �Őݒ�
    private AudioSource audioSource;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        m_rb.velocity = new Vector2(moveX * m_movePower,m_rb.velocity.y); //���E�ړ�
        anim.SetBool("Run", moveX != 0f);�@//�A�j���[�V����

        if(moveX > 0)//��������
        {
            transform.localScale = new Vector2(1, 1); // �E����
        }
        else�@if(moveX < 0) 
        {
            transform.localScale = new Vector2(-1, 1); // ������
        }


        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("�����ɃW�����v���鏈���������B");


            if (jumpCount < maxJumpCount)
            {
                m_rb.AddForce(Vector2.up * m_jumpSpeed, ForceMode2D.Impulse);
                jumpCount++;
                anim.SetBool("Jump", true); // �W�����v�A�j���J�n

                // �W�����vSE�Đ�
                if (jumpSE != null && audioSource != null)
                {
                    audioSource.PlayOneShot(jumpSE);
                    Debug.Log("�W�����vSE���Đ����܂�");
                }
               
            }
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // "Ground"�^�O���t�����I�u�W�F�N�g�ɐڂ��Ă��邩�𔻒�
        if (collision.transform.CompareTag("Untagged"))
        {
            jumpCount = 0;
            anim.SetBool("Jump", false); // ���n�A�j���֖߂�

        }
    }
    }