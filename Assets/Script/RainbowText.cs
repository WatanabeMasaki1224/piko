using TMPro;
using UnityEngine;

using UnityEngine;
using TMPro;

public class RainbowText : MonoBehaviour
{
    public float speed = 1f; // �F���ω����鑬��
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
