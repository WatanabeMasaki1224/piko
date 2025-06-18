using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float moveDistance = 5f;
    private Vector2 startPops;
    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        startPops = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPops = transform.position;
        if (movingRight)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            if (currentPops.x >= startPops.x + moveDistance)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            if(currentPops.x <= startPops.x - moveDistance)
            {
                movingRight=true;
            }
        }
    }
}

