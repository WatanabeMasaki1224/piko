using TMPro;
using UnityEngine;

using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    public float speed = 1f; // 色が変化する速さ
    private TMP_Text text;

    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        float t = Time.time * speed;
        Color rainbowColor = Color.HSVToRGB(t % 1f, 1f, 1f);
        text.color = rainbowColor;
    }
}
