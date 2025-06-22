using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyController : MonoBehaviour
{
    public Color enemyColor; // Inspector �ŐF��ݒ�
    private SpriteRenderer spriteRenderer;
    private Transform respownPoint;
    private ColorSwitcher playerColorSwitcher;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // �v���C���[�擾�i"Player" �^�O���g�p�j
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerColorSwitcher = player.GetComponent<ColorSwitcher>();

        // �v���C���[�̃��X�|�[���ʒu��ݒ�i�����ł͒P���ɐe����T���j
        respownPoint = GameObject.Find("RespownPoint").transform;
    }

    void Update()
    {
        // �v���C���[�̐F�ƈ�v���Ă��邩�ŕ\���ؑ�
        spriteRenderer.enabled = ColorsAreEqual(playerColorSwitcher.CurrentColor, enemyColor);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ���X�|�[�������F�v���C���[�̈ʒu�����Z�b�g
            other.transform.position = respownPoint.position;
        }
    }

    // Unity �� Color �� == ���ƌ덷�̂����ŕs��v�ɂȂ邱�Ƃ�����̂ŁA�ߎ���r
    private bool ColorsAreEqual(Color a, Color b)
    {
        return Mathf.Approximately(a.r, b.r) &&
               Mathf.Approximately(a.g, b.g) &&
               Mathf.Approximately(a.b, b.b) &&
               Mathf.Approximately(a.a, b.a);
    }
}
