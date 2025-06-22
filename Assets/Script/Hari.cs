using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class Hari : MonoBehaviour
{
    public Color platformColor;
    public Transform respawnPoint;


    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        ColorSwitcher switcher = other.GetComponent<ColorSwitcher>();
        if (switcher != null)
        {
            if (switcher.CurrentColor != platformColor)
            {
                other.transform.position = respawnPoint.position;
                Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.velocity = Vector2.zero;
                    rb.angularVelocity = 0f;
                }
            }
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        ColorSwitcher switcher = collision.gameObject.GetComponent<ColorSwitcher>();
        if (switcher != null)
        {
            Physics2D.IgnoreCollision(collision.collider,GetComponent<Collider2D>(),false);

        }
    }
}
