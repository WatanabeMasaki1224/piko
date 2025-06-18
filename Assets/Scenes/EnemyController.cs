using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyController : MonoBehaviour
{
    public Color enemyColor; // Inspector で色を設定
    private SpriteRenderer spriteRenderer;
    private Transform respownPoint;
    private ColorSwitcher playerColorSwitcher;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // プレイヤー取得（"Player" タグを使用）
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerColorSwitcher = player.GetComponent<ColorSwitcher>();

        // プレイヤーのリスポーン位置を設定（ここでは単純に親から探す）
        respownPoint = GameObject.Find("RespownPoint").transform;
    }

    void Update()
    {
        // プレイヤーの色と一致しているかで表示切替
        spriteRenderer.enabled = ColorsAreEqual(playerColorSwitcher.CurrentColor, enemyColor);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // リスポーン処理：プレイヤーの位置をリセット
            other.transform.position = respownPoint.position;
        }
    }

    // Unity の Color は == だと誤差のせいで不一致になることがあるので、近似比較
    private bool ColorsAreEqual(Color a, Color b)
    {
        return Mathf.Approximately(a.r, b.r) &&
               Mathf.Approximately(a.g, b.g) &&
               Mathf.Approximately(a.b, b.b) &&
               Mathf.Approximately(a.a, b.a);
    }
}
