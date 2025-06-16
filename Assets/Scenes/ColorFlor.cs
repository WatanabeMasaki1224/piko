using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ColorFlor : MonoBehaviour
{
    public Color platformColor; // InspectorÇ≈ê›íË
    private Collider2D platformCollider;

    private void Start()
    {
        platformCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerColor playerColor = other.GetComponent<PlayerColor>();
            if (playerColor != null)
            {
                if (ColorsMatch(playerColor.CurrentColor, platformColor))
                {
                    platformCollider.isTrigger = true; // Ç∑ÇËî≤ÇØÇÈ
                    Debug.Log("Colors match Å® Ç∑ÇËî≤ÇØ");
                }
                else
                {
                    platformCollider.isTrigger = false; // í èÌÇÃè∞
                    Debug.Log("Colors don't match Å® í èÌ");
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            platformCollider.isTrigger = false; // ó£ÇÍÇΩÇÁñﬂÇ∑
        }
    }

    private bool ColorsMatch(Color a, Color b)
    {
        return Mathf.Approximately(a.r, b.r)
            && Mathf.Approximately(a.g, b.g)
            && Mathf.Approximately(a.b, b.b);
    }
}