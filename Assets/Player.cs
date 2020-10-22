using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
   [SerializeField] public float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
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

    }
}
