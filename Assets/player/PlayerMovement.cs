using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
   [SerializeField] public float moveSpeed = 10f;
   float _xMin;
   float _xMax;
   Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        _xMin = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        _xMax = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        
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

         if (transform.position.x < _xMin){
            SetTransformX(_xMax);
         }
         if (transform.position.x > _xMax){
            SetTransformX(_xMin);
         }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.tag == "Eagle") && (collision.relativeVelocity.y <= 0f)){
            anim.SetTrigger("HitEagle");
            Destroy(GetComponent<BoxCollider2D>());

        }
        if ((collision.collider.tag == "Eagle") && (collision.relativeVelocity.y >= 0f)){
            anim.SetTrigger("OnBounce");
            

        }

    }

}
