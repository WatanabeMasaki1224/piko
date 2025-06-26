using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movejump : MonoBehaviour
{
    //左右移動する力
    [SerializeField] float m_movePower = 1f;
    //ジャンプ力
    [SerializeField] float m_jumpSpeed = 1f;
    //カラー
    [SerializeField] Color[] m_color = default;
    Rigidbody2D m_rb = default;

    private int jumpCount = 0;
    public int maxJumpCount = 1; // 1段ジャンプ
    private Animator anim;

    [SerializeField] AudioClip jumpSE;          // ← Inspector で設定
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
        m_rb.velocity = new Vector2(moveX * m_movePower,m_rb.velocity.y); //左右移動
        anim.SetBool("Run", moveX != 0f);　//アニメーション

        if(moveX > 0)//向き処理
        {
            transform.localScale = new Vector2(1, 1); // 右向き
        }
        else　if(moveX < 0) 
        {
            transform.localScale = new Vector2(-1, 1); // 左向き
        }


        if (Input.GetButtonDown("Jump"))
        {
            //Debug.Log("ここにジャンプする処理を書く。");


            if (jumpCount < maxJumpCount)
            {
                m_rb.AddForce(Vector2.up * m_jumpSpeed, ForceMode2D.Impulse);
                jumpCount++;
                anim.SetBool("Jump", true); // ジャンプアニメ開始

                // ジャンプSE再生
                if (jumpSE != null && audioSource != null)
                {
                    audioSource.PlayOneShot(jumpSE);
                    Debug.Log("ジャンプSEを再生します");
                }
               
            }
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // "Ground"タグが付いたオブジェクトに接しているかを判定
        if (collision.transform.CompareTag("Untagged"))
        {
            jumpCount = 0;
            anim.SetBool("Jump", false); // 着地アニメへ戻す

        }
    }
    }