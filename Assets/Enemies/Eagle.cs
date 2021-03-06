﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    AudioSource screechSource;
    [SerializeField] float bounceFactor;
    [SerializeField] float _moveSpeed;
    [SerializeField] public float collectorDistanceFromPlayer = -3f;
    [SerializeField] public float warningScreechDistance;
    GameObject player;

   
   

    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    void SetTransformX(float n)
    {
        transform.position = new Vector3(n, transform.position.y, transform.position.z);
    }

    bool _play = true;
    
    void Update()
    {
        if ((transform.position.y - player.transform.position.y) <= collectorDistanceFromPlayer){
            Destroy(gameObject);
        }


        
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < warningScreechDistance) {
            
            if (_play){
            screechSource.Play();
            }
            _play = false;
            Debug.Log(dist);
        }

        
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
        screechSource = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    
}
