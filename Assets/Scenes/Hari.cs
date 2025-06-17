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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ColorSwitcher switcher = collision.gameObject.GetComponent<ColorSwitcher>();

        if (switcher != null )
        {
            if ( switcher.CurrentColor == platformColor )
            {
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());

            }
            else
            {
                collision.gameObject.transform.position = respawnPoint.position;
                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                if ( rb != null )
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
