using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Inspector���畡���I���ł���悤��
    [SerializeField] private List<PlayerColor> selectedColors = new List<PlayerColor>();

    // ���݂̐F�̃C���f�b�N�X
    private int currentColorIndex = 0;

    // ���݂̐F���擾
    public PlayerColor CurrentPlayerColor => selectedColors[currentColorIndex];

    // �O������Ăяo���Ď��̐F�ɕύX
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
