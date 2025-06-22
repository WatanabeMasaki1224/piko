using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class FallingRock : MonoBehaviour
{
    public Color platformColor;
    public Transform respawnPoint;

    public float fallDelay = 1.0f; // �����J�n�܂ł̑҂�����
    public float resetDelay = 3.0f; // ���Z�b�g�܂ł̑҂�����

    private bool hasFallen = false;
    private Rigidbody2D rb;
    private Vector3 initialPosition;

    void Start()
    {
 
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        initialPosition = transform.position; // �ŏ��̈ʒu��ۑ�
    }

    // �v���C���[���߂Â����痎������
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasFallen && other.CompareTag("Player"))
        {
            Debug.Log("�v���C���[�ڋߌ��m");
            hasFallen = true;
            Invoke(nameof(StartFalling), fallDelay);
        }
    }

    void StartFalling()
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // �����J�n
        StartCoroutine(ResetSpike()); // ���Z�b�g����
    }

    // �ڐG����i�F�ŕ���j
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ColorSwitcher switcher = collision.gameObject.GetComponent<ColorSwitcher>();

        if (switcher != null)
        {
            if (switcher.CurrentColor == platformColor)
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }
            else
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), false);

                collision.gameObject.transform.position = respawnPoint.position;

                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ColorSwitcher switcher = collision.gameObject.GetComponent<ColorSwitcher>();
        if (switcher != null)
        {
            Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>(), false);
        }
    }

    // �g�Q�����̏�Ԃɖ߂�
    IEnumerator ResetSpike()
    {
        yield return new WaitForSeconds(resetDelay);

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;

        transform.position = initialPosition;
        hasFallen = false;
    }
}
