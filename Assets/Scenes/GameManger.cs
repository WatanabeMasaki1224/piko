using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Inspectorから複数選択できるように
    [SerializeField] private List<PlayerColor> selectedColors = new List<PlayerColor>();

    // 現在の色のインデックス
    private int currentColorIndex = 0;

    // 現在の色を取得
    public PlayerColor CurrentPlayerColor => selectedColors[currentColorIndex];

    // 外部から呼び出して次の色に変更
    public void NextPlayerColor()
    {
        if (selectedColors.Count == 0) return;
        currentColorIndex = (currentColorIndex + 1) % selectedColors.Count;
    }

    public void SetColors(List<PlayerColor> colors)
    {
        selectedColors = colors;
        currentColorIndex = 0;
    }
}
