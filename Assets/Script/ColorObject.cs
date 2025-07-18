using UnityEngine;

public class ColorObject : MonoBehaviour
{
    public Color objectColor;
    private Collider2D col;
    private ColorSwitcher playerColorSwitcher;

    void Start()
    {
        col = GetComponent<Collider2D>();
        GameObject player = GameObject.FindWithTag("Player");
        playerColorSwitcher = player.GetComponent<ColorSwitcher>();
    }

    void Update()
    {
        if (playerColorSwitcher != null)
        {
            if (playerColorSwitcher.CurrentColor == objectColor)
            {
                col.enabled = false; // すり抜ける
            }
            else
            {
                col.enabled = true; // 通常の当たり判定
            }
        }
    }
}
