using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] public float bounceFactor = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {

        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 velocity = rb.velocity;
            velocity.y = bounceFactor;
            rb.velocity = velocity;
        }
        }
    }
}
