﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
   [SerializeField] public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // _xMin = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        // _xMax = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        
    }

    void SetTransformX(float n)
    {
    transform.position = new Vector3(n, transform.position.y, transform.position.z);
    }




    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKey(KeyCode.A))
         {
             transform.position = transform.position += transform.right * -moveSpeed * Time.deltaTime;
             GetComponent<SpriteRenderer>().flipX = true;
         }
 
        if (Input.GetKey(KeyCode.D))
         { 
             transform.position = transform.position += transform.right * moveSpeed * Time.deltaTime;
             GetComponent<SpriteRenderer>().flipX = false;
         }

         if (transform.position.x < -3){
            SetTransformX(3.0f);
         }
         if (transform.position.x > 3){
            SetTransformX(-3.0f);
         }

             
        
         

    }

}
