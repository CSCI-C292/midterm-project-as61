using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    [SerializeField] float bounceFactor;
    [SerializeField] float moveSpeed;
    [SerializeField] public float collectorDistanceFromPlayer = -3f;
    GameObject player;
   

    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null){
                Vector2 velocity = rb.velocity;
                velocity.y = bounceFactor;
                rb.velocity = velocity;
            }
            Destroy(gameObject);

            
        }
      //  Destroy(Collision2D.otherCollider);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.y - player.transform.position.y) <= collectorDistanceFromPlayer)
        Destroy(gameObject);
    }
}
