﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject _platformPrefab;
    [SerializeField] float _platformScarcity;
    [SerializeField] GameObject player;
    Vector3 spawnpoint;
    float playerHeight;
    public static int platformCount = 0;
    int platformSpawned = 3;
    
    //public float spawnerYpos = transform.position.y;
  
    // Start is called before the first frame update
    void Start()
    {
        // _xMin = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        // _xMax = UnityEngine.Camera.main.ViewportToWorldPoint(new Vector3(1,0,0)).x;
        //int heightTracker = (Mathf.Round(playerHeight) % 5);
    }

    // Update is called once per frame
    void Update()
    {
        float randX = Random.Range(-3, 3);
        playerHeight = player.transform.position.y;
        if ((Mathf.Round(playerHeight) % 5) == 0){
            Debug.Log("Hi");
           //Instantiate(_platformPrefab, new Vector3((Random.Range(-3, 3)), transform.position.y, 0), Quaternion.identity);

        }
        if (platformCount == 1){
            Instantiate(_platformPrefab, new Vector3(randX, transform.position.y, 0), Quaternion.identity);
            platformCount = 0;
        }
    }
    // void OnCollisionEnter2D(Collision2D collision){
    //     Debug.Log("ouch");
    //     Instantiate(_platformPrefab, transform.position, Quaternion.identity);
            
    }
        
    

