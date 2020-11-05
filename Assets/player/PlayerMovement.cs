using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public AudioSource[] sounds;
    public AudioSource freeFallSource;
    public AudioSource gruntSource;
    public GameObject restartMenu;
    public GameObject winScreen;
   [SerializeField] public float moveSpeed = 10f;
   float _xMin;
   float _xMax;
   Animator anim;
   Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
       // WinScreen = GameObject.FindWithTag("WinScreen");
        
    }
    void Start()
    {
        _xMin = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        _xMax = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;
       rb = GetComponent<Rigidbody2D>();
       
         sounds = GetComponents<AudioSource>();
         freeFallSource = sounds [0];
         gruntSource = sounds [1];
    
    }

    void SetTransformX(float n)
    {
        transform.position = new Vector3(n, transform.position.y, transform.position.z);
    }

    bool play = true;
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

        //  if (GameObject.GetComponent<RigidBody>().velocity.y <= -10){
        //     restartMenu.SetActive(true);
            

         
         if (rb.velocity.y <= -20){
            restartMenu.SetActive(true);
            if (play){
                freeFallSource.Play();
                play = false;
            }

        }

        if (transform.position.y >= 150){
            winScreen.SetActive(true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.collider.tag == "Eagle") && (collision.relativeVelocity.y <= 0f)){
            anim.SetTrigger("HitEagle");
            gruntSource.Play();
            Destroy(GetComponent<BoxCollider2D>());

        }
        if ((collision.collider.tag == "Eagle") && (collision.relativeVelocity.y >= 0f)){
            anim.SetTrigger("OnBounce");
            
            

        }

    }

}
