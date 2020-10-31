using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject _platformPrefab;
    [SerializeField] int howMany;
    [SerializeField] float distanceBetween;
    [SerializeField] GameObject player;
    
    float _xMin;
    float _xMax;
   
    
    
  
    // Start is called before the first frame update
    void Start()
    {
        _xMin = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        _xMax = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        float yPos = transform.position.y;
        int i;
        for (i = 0; i < howMany; i++){
            Instantiate(_platformPrefab, new Vector3(Random.Range(_xMin, _xMax), yPos, 0), Quaternion.identity);
            yPos += distanceBetween;
           
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        // float randX = Random.Range(_xMin, _xMax);
        // bool spawn = false;
        // playerHeight = player.transform.position.y;
        // if ((Mathf.Round(playerHeight) % 5) == 0){
        //    // Debug.Log("Hi");
         

        // }
        // if (platformCount == 1){
        //     Instantiate(_platformPrefab, new Vector3(randX, transform.position.y, 0), Quaternion.identity);
        //     platformCount = 0;
        // }
    }
    // void OnCollisionEnter2D(Collision2D collision){
    //     Debug.Log("ouch");
    //     Instantiate(_platformPrefab, transform.position, Quaternion.identity);
            
    }
        
    

