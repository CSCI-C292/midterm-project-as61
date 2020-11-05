using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public AudioSource whooshSource;
    [SerializeField] public float bounceFactor = 10f;
    [SerializeField] public float collectorDistanceFromPlayer = -3f;
    
   // [SerializeField] 
    GameObject player;
    Animator anim;
    // bool k = false;
    

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f){
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null){
                Vector2 velocity = rb.velocity;
                velocity.y = bounceFactor;
                rb.velocity = velocity;
            }

            anim.SetTrigger("OnBounce");
            // if (k == false){
            //     PlatformSpawner.platformCount += 1;
            //     // GameObject.Find
            //     k = true;
            // }
            whooshSource.Play();


           
        }
    }
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        anim = player.GetComponent<Animator>();
        whooshSource = GetComponent<AudioSource>();


    }
    void Update()
    {
        if ((transform.position.y - player.transform.position.y) <= collectorDistanceFromPlayer)
        Destroy(gameObject);
    }
}
