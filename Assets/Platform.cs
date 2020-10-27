using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] public float bounceFactor = 10f;
    [SerializeField] public float difficulty = 10f;
    [SerializeField] GameObject platformSpawner;// = GameObject.Find("platformspawntrigger").;
    bool player = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f){
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null){
                Vector2 velocity = rb.velocity;
                velocity.y = bounceFactor;
                rb.velocity = velocity;
            }
            if (player == false){
                PlatformSpawner.platformCount += 1;
                // GameObject.Find
                player = true;
            }
        }
    }
}
