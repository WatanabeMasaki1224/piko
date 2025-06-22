using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    public Color[] colors; // 切り替え可能な色
    private int currentColorIndex = 0;
    private SpriteRenderer spriteRenderer;
    public Color CurrentColor { get; private set; }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor(colors[currentColorIndex]);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // 右クリック
        {
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
            SetColor(colors[currentColorIndex]);
        }
    }

    void SetColor(Color color)
    {
        CurrentColor = color;
        spriteRenderer.color = color;
    }
}
