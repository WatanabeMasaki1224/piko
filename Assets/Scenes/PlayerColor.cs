using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer playerRenderer;
    private int colorIndex = 0;

    private Color[] colors = new Color[]
    {
        Color.red,
        Color.blue,
        Color.green,
        Color.yellow,

    };

    public Color CurrentColor => colors[colorIndex];
    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        if (playerRenderer == null)
        {
            playerRenderer.material.color = colors[colorIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            colorIndex = (colorIndex + 1) % colors.Length;
            playerRenderer.material.color = colors[colorIndex];

        }
    } 
}

    
